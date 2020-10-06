using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Institute.Data;
using Institute.Model;
using AutoMapper;
using Institute.DTOs;
using Institute.Repository.FileManager;
using System.Threading;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.AspNetCore.Authorization;

namespace Institute.Controllers
{
    [Route("api/chapters")]
    [ApiController]
    public class ChaptersController : ControllerBase
    {
        private readonly IInstituteDataRepoCRUD _datarepository;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public ChaptersController
            (IInstituteDataRepoCRUD repository, 
            IMapper mapper, 
            IFileManager fileManager)
        {
            _datarepository = repository;
            _mapper = mapper;
            _fileManager = fileManager;
        }

        //Tutor
        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("addintrovideo/{courseid}/{chaptersn}")]
        public async Task<IActionResult> PostIntroVideo(
            int courseId,
            int chapterSN,
            IFormFile uploadingfile,
            CancellationToken cancellationToken)
        {
            //Checking already exist introvideo
            var chaptermodel = await _datarepository
                .GetChapterBySN(courseId, chapterSN);
            if(chaptermodel.IntroVideoId.HasValue)
            {
                return BadRequest(new
                {
                    Message = "Already Intro Video is uploaded."
                });
            }

            //Checking recived file
            if(uploadingfile ==null)
            {
                return BadRequest(new
                {
                    Message = "Uploading File not found."
                });
            }

            //Creating folder
            string folder = System.IO.Path.Combine
                ("Courses", courseId.ToString(), "Chapters","Video");
            //Saving file to server
            var filepath = await _fileManager.SaveFileToDefaultFolder
                (folder, uploadingfile);

            //Creating filedata model
            var filemodel = new File()
            {
                FileName = chaptermodel.Title + "_" + "IntroVideo",
                Type = FileType.Video,
                FileUrl = filepath,
            };

            //Creating video data model
            var videomodel = new Video()
            {
                FileDetail = filemodel,
            };

            //Saving updates
            chaptermodel.IntroVideo = videomodel;
            await _datarepository.SaveChanges();

            return Ok();

        }



        
    }
}
