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
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using Institute.Repository.FileManager;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Institute.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IInstituteDataRepoCRUD _dataRepoCRUD;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileManager _fileManager;

        public CoursesController
            (
            IInstituteDataRepoCRUD dataRepoCRUD,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IFileManager fileManager
            )
        {
            _dataRepoCRUD = dataRepoCRUD;
            _mapper = mapper;
            _userManager = userManager;
            _fileManager = fileManager;
        }



        //Tutor
        //get api/courses
        [Authorize(Roles = "Tutor")]
        [HttpPost]
        public async Task<ActionResult> AddNewCourse
            ([FromBody]DTO.CourseRequestForm coursedetail)
        {
           
            //Creating Course
            var courseModel = _mapper.Map<Course>(coursedetail);
            //_dataRepoCRUD.CreateCourse(courseModel);

            //Finding Tutor
            var userModel = await _userManager.FindByNameAsync
                (User.FindFirstValue(ClaimTypes.Name));
            var tutormodel = await _dataRepoCRUD.GetTutor(userModel.Id);
            if(tutormodel == null)
            {
                return BadRequest(new
                {
                    Message = "Unable to fetch tutor data"
                });
            }

            //Creating RequestedTutorcourse
            var tutorCourseModel = new RequestedTutorCourse()
            {
                TutorId = tutormodel.Id,
                CourseDetail = courseModel,
                TutorShare = coursedetail.Tutorshare,
            };
            _dataRepoCRUD.CreateRequestedTutorCourse(tutorCourseModel);
            await _dataRepoCRUD.SaveChanges();

            return Ok(new {Message = "Sucessfully created your course. But other will only access it after approval from admin", tutorCourseModel});
            //Map Model to DTO
            //var courseReadDTO = _mapper.Map<CourseReadDTO>(courseModel);

            //return CreatedAtRoute(nameof(GetCourseDetail),
            //    new { Id = courseModel.Id }, courseReadDTO);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("{coursecode}/chapter")]
        public async Task<ActionResult> AddCourseChapter
            (string coursecode, DTO.ChapterCreateForm chapter)
        {
            //Change to database
            var chaptermodel = _mapper.Map<Chapter>(chapter);
            var coursemodel =await _dataRepoCRUD.GetCourse(coursecode);
            chaptermodel.CourseId = coursemodel.Id;
            _dataRepoCRUD.CreateChapter(chaptermodel);
            await _dataRepoCRUD.SaveChanges();

            return Ok(chaptermodel);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy ="TutorCourseCheck")]
        [HttpPost("{coursecode}/Chapter/{chapterSN}/Lesson")]
        public async Task<ActionResult> AddLesson
            (string coursecode, 
            int chapterSN, 
            [FromBody]DTO.LessonCreateForm lesson)
        {
            //Getting course id
            var coursetask = _dataRepoCRUD.GetCourse(coursecode);

            //Change to database
            var lessonmodel = _mapper.Map<Lesson>(lesson);
            var course = await coursetask;
            var courseId = course.Id;
            var chaptermodel = await _dataRepoCRUD.GetChapterBySN
                (courseId, chapterSN);
            if(chaptermodel == null)
            {
                return new NotFoundObjectResult(new
                {
                    Message = "Request not completed. Concerned Chapter not found."
                });
            }
            lessonmodel.Chapter = chaptermodel;
            _dataRepoCRUD.CreateLesson(lessonmodel);
            await _dataRepoCRUD.SaveChanges();

            return Ok(lessonmodel);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("introvideo/{coursecode}")]
        public async Task<ActionResult> AddCourseIntroVideo
            (string coursecode,
            IFormFile uploadingfile,
            CancellationToken cancellationToken)
        {
            //Checking already exist introvideo
            var coursemodel = await _dataRepoCRUD.GetCourse(coursecode);
            if (!string.IsNullOrWhiteSpace(coursemodel.IntroVideoId))
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
                ("Course",coursecode, "Videos");
            //Saving file to server
            var filepath = await _fileManager.SaveFileToDefaultFolder
                (folder, uploadingfile);
            
            //Creating filedatab model
            var filemodel = new File()
            {
                FileName = coursemodel.Title + "_" + "IntroVideo",
                Type = FileType.Video,
                FileUrl = filepath,
            };

            //Creating video data model
            var videomodel = new Video()
            {
                FileDetail = filemodel,
            };

            //Saving updates
            coursemodel.IntroVideo = videomodel;
            await _dataRepoCRUD.SaveChanges();

            return Ok(videomodel);

        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("{coursecode}/pretest")]
        public async Task<ActionResult> AddCoursePreTest
            ([FromRoute] string coursecode, 
            [FromBody] DTO.TestCreateForm test)
        {
            //Creating Database
            var testmodel = _mapper.Map<Test>(test);
            var coursemodel = await _dataRepoCRUD.GetCourse(coursecode);
            if(coursemodel == null)
            {
                return new NotFoundObjectResult(new
                { Message = "Request not completed. Course not found." });
            }
            var coursepretestmodel = new CoursePreTest()
            {
                SN = test.SN,
                TestDetail = testmodel,
                RefCourse = coursemodel,
            };
            _dataRepoCRUD.CreateCoursePreTest(coursepretestmodel);
            await _dataRepoCRUD.SaveChanges();

            return Ok(testmodel);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("{coursecode}/posttest")]
        public async Task<ActionResult> AddCoursePostTest
            ([FromRoute] string coursecode,
            [FromBody] DTO.TestCreateForm test)
        {
            //Creating Data
            var testmodel = _mapper.Map<Test>(test);
            var coursemodel = await _dataRepoCRUD.GetCourse(coursecode);
            if (coursemodel == null)
            {
                return new NotFoundObjectResult(new
                { Message = "Request not completed. Course not found." });
            }
            var courseposttestmodel = new CoursePostTest()
            {
                SN = test.SN,
                TestDetail = testmodel,
                RefCourse = coursemodel,
            };
            _dataRepoCRUD.CreateCoursePostTest(courseposttestmodel);
            await _dataRepoCRUD.SaveChanges();

            return Ok(testmodel);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("{coursecode}/preassignment")]
        public async Task<IActionResult> AddCoursePreAssignment(
            [FromRoute]string coursecode,
            [FromBody] DTO.AssignmentCreateForm assignmentform)
        {
            //Creating Data
            var assignmentmodel = _mapper.Map<Assignment>(assignmentform);
            var coursemodel = await _dataRepoCRUD.GetCourse(coursecode);
            if (coursemodel == null)
            {
                return new NotFoundObjectResult(new
                { Message = "Request not completed. Course not found." });
            }

            var courseassignment = new CoursePreAssignment()
            {
                RefCourse = coursemodel,
                AssignmentDetail = assignmentmodel,
            };
            _mapper.Map(assignmentform, courseassignment);
            _dataRepoCRUD.CreateCoursePreAssignment(courseassignment);
            await _dataRepoCRUD.SaveChanges();
            return Ok(courseassignment);
        }


        [Authorize(Roles = "Tutor")]
        [Authorize(Policy = "TutorCourseCheck")]
        [HttpPost("{coursecode}/postassignment")]
        public async Task<IActionResult> AddCoursePostAssignment(
            [FromRoute] string coursecode,
            [FromBody] DTO.AssignmentCreateForm assignmentform)
        {
            //Creating Data
            var assignmentmodel = _mapper.Map<Assignment>(assignmentform);
            var coursemodel = await _dataRepoCRUD.GetCourse(coursecode);
            if (coursemodel == null)
            {
                return new NotFoundObjectResult(new
                { Message = "Request not completed. Course not found." });
            }

            var courseassignment = new CoursePostAssignment()
            {
                RefCourse = coursemodel,
                AssignmentDetail = assignmentmodel,
            };
            _mapper.Map(assignmentform, courseassignment);
            _dataRepoCRUD.CreateCoursePostAssignment(courseassignment);
            await _dataRepoCRUD.SaveChanges();
            return Ok(courseassignment);
        }





        ////PUT api/courses/{id}
        //[HttpPut("{id}")]
        //public async Task<ActionResult> UpdateCourse(int id,CourseUpdateDTO courseUpdate)
        //{
        //    var courseolditem = await _repository.GetCourseById(id);
        //    if(courseolditem==null)
        //    {
        //        return NotFound();
        //    }
        //    _mapper.Map(courseUpdate, courseolditem);

        //    _repository.UpdateCourse(courseolditem);

        //    await _repository.SaveChanges();

        //    return NoContent();
        //}

        ////Patch api/courses/{id}
        //[HttpPatch("{id}")]
        //public async Task<ActionResult> PartialCourseUpdate
        //    (int id, JsonPatchDocument<CourseUpdateDTO> patchDocument)
        //{
        //    var courseolditem = await _repository.GetCourseById(id);
        //    if (courseolditem == null)
        //    {
        //        return NotFound();
        //    }

        //    var courseToPatch = _mapper.Map<CourseUpdateDTO>(courseolditem);

        //    //Update specific attributes
        //    patchDocument.ApplyTo(courseToPatch, ModelState);

        //    if(!TryValidateModel(courseToPatch))
        //    {
        //        return ValidationProblem(ModelState);
        //    }

        //    _mapper.Map(courseToPatch, courseolditem);

        //    _repository.UpdateCourse(courseolditem);

        //    await _repository.SaveChanges();

        //    return NoContent();
        //}

        ////Delete api/courses/{id}
        //[HttpDelete("{id}")]
        //public async Task<ActionResult> DeleteCourse(int id)
        //{
        //    var courseitem = await _repository.GetCourseById(id);
        //    if (courseitem == null)
        //    {
        //        return NotFound();
        //    }

        //    _repository.DeleteCourse(courseitem);
        //    await _repository.SaveChanges();

        //    return NoContent();
        //}

    }
}
