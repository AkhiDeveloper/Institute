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
using DTO=Institute.DTOs;
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
        [HttpPost("lesson")]
        public async Task<ActionResult> AddLesson
           (string coursecode,
           int chapterSN,
           [FromBody] DTO.LessonCreateForm lesson)
        {
            //Getting course id
            var course = await _datarepository.GetCourse(coursecode);
            var courseId = course.Id;

            //Change to database
            var lessonmodel = _mapper.Map<Lesson>(lesson);
            var chaptermodel = await _datarepository.GetChapterBySN
                (courseId, chapterSN);
            if (chaptermodel == null)
            {
                return new NotFoundObjectResult(new
                {
                    Message = "Request not completed. Concerned Chapter not found."
                });
            }
            lessonmodel.Chapter = chaptermodel;
            _datarepository.CreateLesson(lessonmodel);
            await   _datarepository.SaveChanges();

            return Ok(lessonmodel);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("introvideo")]
        public async Task<IActionResult> AddIntroVideo(
            string coursecode,
            int chapterSN,
            IFormFile uploadingfile,
            CancellationToken cancellationToken)
        {
            //Getting course id
            var course = await _datarepository.GetCourse(coursecode);
            var courseId = course.Id;

            //Checking already exist introvideo
            var chaptermodel = await _datarepository
                .GetChapterBySN(courseId, chapterSN);
            if(!string.IsNullOrWhiteSpace(chaptermodel.IntroVideoId))
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
                ("Courses", coursecode, 
                "Chapters",chaptermodel.SN.ToString(),"Video");
            //Saving file to server
            var filepath = await _fileManager.SaveFileToDefaultFolder
                (folder, uploadingfile);

            //Creating filedata model
            var filemodel = new File()
            {
                FileName = (coursecode+"_"+ 
                    chaptermodel.SN.ToString()+ "_" + "IntroVideo"),
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

            return Ok(videomodel);

        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("pretest")]
        public async Task<IActionResult> AddPreTest(
            string coursecode,
            int chapterSN,
            DTO.TestCreateForm testform)
        {
            var testmodel = _mapper.Map<Test>(testform);
            var coursemodel = await _datarepository.GetCourse(coursecode);
            var chaptermodel = await _datarepository.GetChapterBySN
                (coursemodel.Id, chapterSN);
            if(chaptermodel == null)
            {
                return BadRequest(chaptermodel);
            }

            var chapterpretestmodel = new ChapterPreTest()
            {
                SN = testform.SN,
                TestDetail = testmodel,
                RefChapter = chaptermodel,
            };
            _datarepository.CreateChapterPreTest(chapterpretestmodel);
            await _datarepository.SaveChanges();

            return Ok(chapterpretestmodel);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("posttest")]
        public async Task<IActionResult> AddPostTest(
            string coursecode,
            int chapterSN,
            [FromBody] DTO.TestCreateForm testform)
        {
            var testmodel = _mapper.Map<Test>(testform);
            var coursemodel = await _datarepository.GetCourse(coursecode);
            var chaptermodel = await _datarepository.GetChapterBySN
                (coursemodel.Id, chapterSN);
            if (chaptermodel == null)
            {
                return BadRequest(chaptermodel);
            }

            var chapterposttestmodel = new ChapterPostTest()
            {
                SN = testform.SN,
                TestDetail = testmodel,
                RefChapter = chaptermodel,
            };
            _datarepository.CreateChapterPostTest(chapterposttestmodel);
            await _datarepository.SaveChanges();

            return Ok(chapterposttestmodel);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("preassignment")]
        public async Task<IActionResult> AddPreAssignment(
            string coursecode,
            int chapterSN,
            [FromBody] DTO.AssignmentCreateForm assignmentform)
        {
            var assignmentmodel = _mapper.Map<Assignment>(assignmentform);
            var coursemodel = await _datarepository.GetCourse(coursecode);
            var chaptermodel = await _datarepository.GetChapterBySN
                (coursemodel.Id, chapterSN);
            if (chaptermodel == null)
            {
                return BadRequest(chaptermodel);
            }

            var chapterpreassignmentmodel = new ChapterPreAssignment()
            {
                SN = assignmentform.SN,
                AssignmentDetail = assignmentmodel,
                RefChapter = chaptermodel,
            };
            _datarepository.CreateChapterPreAssignment
                (chapterpreassignmentmodel);
            await _datarepository.SaveChanges();

            return Ok(chapterpreassignmentmodel);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("postassignment")]
        public async Task<IActionResult> AddPostAssignment(
            string coursecode,
            int chapterSN,
            [FromBody] DTO.AssignmentCreateForm assignmentform)
        {
            var assignmentmodel = _mapper.Map<Assignment>(assignmentform);
            var coursemodel = await _datarepository.GetCourse(coursecode);
            var chaptermodel = await _datarepository.GetChapterBySN
                (coursemodel.Id, chapterSN);
            if (chaptermodel == null)
            {
                return BadRequest(chaptermodel);
            }

            var chapterpostassignmentmodel = new ChapterPostAssignment()
            {
                SN = assignmentform.SN,
                AssignmentDetail = assignmentmodel,
                RefChapter = chaptermodel,
            };
            _datarepository.CreateChapterPostAssignment
                (chapterpostassignmentmodel);
            await _datarepository.SaveChanges();

            return Ok(chapterpostassignmentmodel);
        }


    }
}
