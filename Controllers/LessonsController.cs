using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Institute.Data;
using Institute.Model;
using Institute.Repository.FileManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Institute.Controllers
{
    [Route("api/lessons")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly IInstituteDataRepoCRUD _datarepository;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public LessonsController
            (IInstituteDataRepoCRUD repository,
            IMapper mapper,
            IFileManager fileManager)
        {
            _datarepository = repository;
            _mapper = mapper;
            _fileManager = fileManager;
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("teachingvideo")]
        public async Task<IActionResult> AddIntroVideo(
            string coursecode,
            int chapterSN,
            int lessonSN,
            IFormFile uploadingfile,
            CancellationToken cancellationToken)
        {
            //Getting course id
            var coursemodel = await _datarepository
                .GetCourse(coursecode);
            var chaptermodel = await _datarepository
                .GetChapterBySN(coursemodel.Id, chapterSN);

            //Checking already exist introvideo
            var lessonmodel = await _datarepository
                .GetLessonBySN(chaptermodel.Id, lessonSN);
            if (!string.IsNullOrWhiteSpace(lessonmodel.TeachingVideoId))
            {
                return BadRequest(new
                {
                    Message = "Already Intro Video is uploaded."
                });
            }

            //Checking recived file
            if (uploadingfile == null)
            {
                return BadRequest(new
                {
                    Message = "Uploading File not found."
                });
            }

            //Creating folder
            string folder = System.IO.Path.Combine
                ("Courses", coursecode,
                "Chapters", chapterSN.ToString(),
                "Lessons", lessonSN.ToString(), "Video");
            //Saving file to server
            var filepath = await _fileManager.SaveFileToDefaultFolder
                (folder, uploadingfile);

            //Creating filedata model
            var filemodel = new File()
            {
                FileName = (coursecode + "_" +
                    chapterSN + "_" +
                    lessonSN + "_" + "IntroVideo"),
                Type = FileType.Video,
                FileUrl = filepath,
            };

            //Creating video data model
            var videomodel = new Video()
            {
                FileDetail = filemodel,
            };

            //Saving updates
            lessonmodel.TeachingVideo = videomodel;
            await _datarepository.SaveChanges();

            return Ok(videomodel);

        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("pretest")]
        public async Task<IActionResult> AddPreTest(
            string coursecode,
            int chapterSN,
            int lessonsn,
            [FromBody]DTOs.TestCreateForm testform)
        {
            var testmodel = _mapper.Map<Test>(testform);
            var coursemodel = await _datarepository.GetCourse(coursecode);
            var chaptermodel = await _datarepository.GetChapterBySN
                (coursemodel.Id, chapterSN);
            if (chaptermodel == null)
            {
                return BadRequest(chaptermodel);
            }
            var lessonmodel = await _datarepository.GetLessonBySN
                (chaptermodel.Id, lessonsn);
            if(lessonmodel == null)
            {
                return BadRequest(new
                {
                    Message = "Relative lesson not found",
                });
            }

            var lessonpretestmodel = new LessonPreTest()
            {
                SN = testform.SN,
                TestDetail = testmodel,
                RefLessonId = lessonmodel.Id,
            };
            _datarepository.CreateLessonPreTest(lessonpretestmodel);
            await _datarepository.SaveChanges();

            return Ok(lessonpretestmodel);
        }

        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("posttest")]
        public async Task<IActionResult> AddPostTest(
            string coursecode,
            int chapterSN,
            int lessonsn,
            [FromBody] DTOs.TestCreateForm testform)
        {
            var testmodel = _mapper.Map<Test>(testform);
            var coursemodel = await _datarepository.GetCourse(coursecode);
            var chaptermodel = await _datarepository.GetChapterBySN
                (coursemodel.Id, chapterSN);
            if (chaptermodel == null)
            {
                return BadRequest(chaptermodel);
            }
            var lessonmodel = await _datarepository.GetLessonBySN
                (chaptermodel.Id, lessonsn);

            var lessonposttestmodel = new LessonPostTest()
            {
                SN = testform.SN,
                TestDetail = testmodel,
                RefLesson = lessonmodel,
            };
            _datarepository.CreateLessonPostTest(lessonposttestmodel);
            await _datarepository.SaveChanges();

            return Ok(lessonposttestmodel);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("preassignment")]
        public async Task<IActionResult> AddPreAssignment(
            string coursecode,
            int chapterSN,
            int lessonsn,
            [FromBody] DTOs.AssignmentCreateForm assignmentform)
        {
            var assignmentmodel = _mapper.Map<Assignment>(assignmentform);
            var coursemodel = await _datarepository.GetCourse(coursecode);
            var chaptermodel = await _datarepository.GetChapterBySN
                (coursemodel.Id, chapterSN);
            if (chaptermodel == null)
            {
                return BadRequest(chaptermodel);
            }
            var lessonmodel = await _datarepository.GetLessonBySN
                 (chaptermodel.Id, lessonsn);

            var lessonPreAssignment = new LessonPreAssignment()
            {
                SN = assignmentform.SN,
                TaskDetail = assignmentmodel,
                RefLesson = lessonmodel,
            };
            _datarepository.CreateLessonPreAssignment(lessonPreAssignment);
            await _datarepository.SaveChanges();

            return Ok(lessonPreAssignment);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("postassignment")]
        public async Task<IActionResult> AddPostAssignment(
            string coursecode,
            int chapterSN,
            int lessonsn,
            [FromBody] DTOs.AssignmentCreateForm assignmentform)
        {
            var assignmentmodel = _mapper.Map<Assignment>(assignmentform);
            var coursemodel = await _datarepository.GetCourse(coursecode);
            var chaptermodel = await _datarepository.GetChapterBySN
                (coursemodel.Id, chapterSN);
            if (chaptermodel == null)
            {
                return BadRequest(chaptermodel);
            }
            var lessonmodel = await _datarepository.GetLessonBySN
                (chaptermodel.Id, lessonsn);

            var lessonPostAssignment = new LessonPostAssignment()
            {
                SN = assignmentform.SN,
                TaskDetail = assignmentmodel,
                RefLesson = lessonmodel,
            };
            _datarepository.CreateLessonPostAssignment(lessonPostAssignment);
            await _datarepository.SaveChanges();

            return Ok(lessonPostAssignment);
        }
    }


}

