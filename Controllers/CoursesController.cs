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
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Institute.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        //private readonly  IInstituteDataRepo _repository;
        private readonly IInstituteDataRepoCRUD _dataRepoCRUD;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoursesController
            (
            //IInstituteDataRepo repository,
            IInstituteDataRepoCRUD dataRepoCRUD,
            IMapper mapper,
            UserManager<ApplicationUser> userManager
            )
        {
            //_repository = repository;
            _dataRepoCRUD = dataRepoCRUD;
            _mapper = mapper;
            _userManager = userManager;
        }
        


        //General
        //get api/courses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CourseReadDTO>>> 
        //    SearchCourse()
        //{
        //    //var courseitems = await _dataRepoCRUD.GetAllRegisteredCourses();

        //    //if (courseitems != null)
        //    //{
        //    //    return Ok(_mapper.Map<IEnumerable<CourseReadDTO>>(courseitems));
        //    //}
        //    return NotFound();
        //}


        //get api/courses/{searchtext}
        //[HttpGet("{searchtext}")]
        //public async Task<ActionResult<IEnumerable<CourseReadDTO>>> 
        //    SearchCourse(string searchtext)
        //{
        //    //var rejistercoursesmodel =await _dataRepoCRUD.GetAllRegisteredCourses();

        //    //var allcourses = new List<Course>();
        //    //foreach(var x in rejistercoursesmodel)
        //    //{
        //    //    allcourses.Add(await _dataRepoCRUD.GetCourse(x.CourseId));
        //    //}

        //    //var searchedcourse = from x in allcourses
        //    //                     where x.Title.Contains(searchtext)
        //    //                     select x;

        //    //if(searchedcourse != null)
        //    //{
        //    //    return Ok(_mapper.Map<IEnumerable<CourseReadDTO>>(searchedcourse));
        //    //}
        //    return NotFound(new { Message = "No course found for this keyword." });
        //}


        //get api/courses/{id}
        //[HttpGet("{id}",Name ="GetCourseDetail")]
        //public async Task<ActionResult<CourseReadDTO>> GetCourseDetail(int id)
        //{
        //    var courseitem = await _dataRepoCRUD.GetCourse(id);

        //    if (courseitem != null)
        //    {
        //        return Ok(_mapper.Map<CourseReadDTO>(courseitem));
        //    }
        //    return NotFound();
        //}


        //get api/course/{courseId}/Chapter
        //[HttpGet("/{courseId}/chapter")]
        //public async Task<ActionResult<ChapterReadDTO>> GetChapters
        //    (int courseId)
        //{
        //    var chaptersmodel = await _dataRepoCRUD
        //        .GetChaptersByCourseId(courseId);

        //    if(chaptersmodel == null)
        //    {
        //        return Ok
        //            (_mapper.Map<IEnumerable<ChapterReadDTO>>
        //            (chaptersmodel));
        //    }

        //    return NotFound();
        //}


        //get api/course/chapter/{chapterid}/lesson
        //[HttpGet("/chapter/{chapterid}/lesson")]
        //public async Task<ActionResult<Lesson>> GetLessons
        //    (int chapterid)
        //{
        //    var lessonsmodel = await _dataRepoCRUD
        //        .GetLessonsByChapterId(chapterid);

        //    if(lessonsmodel != null)
        //    {
        //        return Ok(_mapper.Map<IEnumerable<Lesson>>(lessonsmodel));
        //    }

        //    return NotFound();
        //}



        //Tutor
        //get api/courses
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddNewCourse
            ([FromBody]DTO.CourseRequestForm coursedetail)
        {
            //Getting User from HttpContext
            var username = User.FindFirst(ClaimTypes.Name).Value;
            var userModel = await _userManager.FindByNameAsync(username);
            var tutorModel = await _dataRepoCRUD.GetTutor(userModel.Id);
            if (tutorModel == null)
            {
                return new BadRequestObjectResult(new
                { Message = "Request not completed. User is not subscribed as Tutor." });
            }

            //Map DTO to Model
            var courseModel = _mapper.Map<Course>(coursedetail);

            var tutorCourseModel = new RequestedTutorCourse()
            {
                Tutor = tutorModel,
                CourseDetail = courseModel,
                TutorShare = coursedetail.Tutorshare,
            };
            _dataRepoCRUD.CreateRequestedTutorCourse(tutorCourseModel);
            await _dataRepoCRUD.SaveChanges();

            return Ok(new {Message = "Sucessfully created your course. But other will only access it after approval from admin"});
            //Map Model to DTO
            //var courseReadDTO = _mapper.Map<CourseReadDTO>(courseModel);

            //return CreatedAtRoute(nameof(GetCourseDetail),
            //    new { Id = courseModel.Id }, courseReadDTO);
        }


        [Authorize]
        [HttpPost("{courseid}/chapter")]
        public async Task<ActionResult> AddCourseChapter
            (int courseId, DTO.ChapterCreateForm chapter)
        {
            //Getting User from HttpContext
            var username = User.FindFirst(ClaimTypes.Name).Value;
            var userModel = await _userManager.FindByNameAsync(username);
            var tutorModel = await _dataRepoCRUD.GetTutor(userModel.Id);
            if (tutorModel == null)
            {
                return new BadRequestObjectResult(new
                { Message = "Request not completed. User is not subscribed as Tutor." });
            }

            //Checking Correct Tutor
            var tutorcoursemodel = await _dataRepoCRUD.
                GetRequestedTutorCourse(courseId);
            if (tutorcoursemodel.TutorId != tutorModel.Id)
            {
                return new BadRequestObjectResult(new
                { Message = "You are not correct tutor." });
            }

            //Change to database
            var chaptermodel = _mapper.Map<Chapter>(chapter);
            var coursemodel =await _dataRepoCRUD.GetCourse(courseId);
            chaptermodel.Course = coursemodel;
            _dataRepoCRUD.CreateChapter(chaptermodel);
            await _dataRepoCRUD.SaveChanges();

            return Ok();
        }

        [Authorize]
        [HttpPost("{courseId}/Chapter/{chapterSN}/Lesson")]
        public async Task<ActionResult> AddLesson
            (int courseId, 
            int chapterSN, 
            [FromBody]DTO.LessonCreateForm lesson)
        {
            //Getting User from HttpContext
            var username = User.FindFirst(ClaimTypes.Name).Value;
            var userModel = await _userManager.FindByNameAsync(username);
            var tutorModel = await _dataRepoCRUD.GetTutor(userModel.Id);
            if (tutorModel == null)
            {
                return new BadRequestObjectResult(new
                { Message = "Request not completed. User is not subscribed as Tutor." });
            }

            //Checking Correct Tutor
            var tutorcoursemodel = await _dataRepoCRUD.
                GetRequestedTutorCourse(courseId);
            if (tutorcoursemodel.TutorId != tutorModel.Id)
            {
                return new BadRequestObjectResult(new
                { Message = "You are not correct tutor." });
            }

            //Change to database
            var lessonmodel = _mapper.Map<Lesson>(lesson);
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

            return Ok();
        }


        //[Authorize]
        //[HttpPost]
        //public async Task<ActionResult> AddCourseIntroVideo
        //    ([FromRoute] int courseid, [FromBody] VideoCreateDTO video)
        //{
        //    var videomodel = _mapper.Map<Video>(video);

        //    var coursemodel = await _dataRepoCRUD.GetCourse(courseid);
        //    coursemodel.IntroVideo = videomodel;

        //    _dataRepoCRUD.UpdateCourse(coursemodel);
        //    await _dataRepoCRUD.SaveChanges();

        //    return Ok();
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<ActionResult> AddChapterIntroVideo
        //    ([FromRoute] int chapterid, [FromBody] VideoCreateDTO video)
        //{
        //    var videomodel = _mapper.Map<Video>(video);

        //    var chaptermodel = await _dataRepoCRUD.GetChapter(chapterid);
        //    chaptermodel.IntroVideo = videomodel;

        //    _dataRepoCRUD.UpdateChapter(chaptermodel);
        //    await _dataRepoCRUD.SaveChanges();

        //    return Ok();
        //}

        //[Authorize]
        //[HttpPost]
        //public async Task<ActionResult> AddLessonTeachingVideo
        //    ([FromRoute] int lessonid, [FromBody] VideoCreateDTO video)
        //{
        //    var videomodel = _mapper.Map<Video>(video);

        //    var lessonmodel = await _dataRepoCRUD.GetLesson(lessonid);
        //    lessonmodel.TeachingVideo = videomodel;

        //    _dataRepoCRUD.UpdateLesson(lessonmodel);
        //    await _dataRepoCRUD.SaveChanges();

        //    return Ok();
        //}

        [Authorize]
        [HttpPost("{courseId}/pretest")]
        public async Task<ActionResult> AddCoursePreTest
            ([FromRoute] int courseId, 
            [FromBody] DTO.TestCreateForm test)
        {
            //Getting User from HttpContext
            var username = User.FindFirst(ClaimTypes.Name).Value;
            var userModel = await _userManager.FindByNameAsync(username);
            var tutorModel = await _dataRepoCRUD.GetTutor(userModel.Id);
            if (tutorModel == null)
            {
                return new BadRequestObjectResult(new
                { Message = "Request not completed. User is not subscribed as Tutor." });
            }

            //Checking Correct Tutor
            var tutorcoursemodel = await _dataRepoCRUD.
                GetRequestedTutorCourse(courseId);
            if (tutorcoursemodel.TutorId != tutorModel.Id)
            {
                return new BadRequestObjectResult(new
                { Message = "You are not correct tutor." });
            }

            //Creating Database
            var testmodel = _mapper.Map<Test>(test);
            var coursemodel = await _dataRepoCRUD.GetCourse(courseId);
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

            return Ok();
        }

        [Authorize]
        [HttpPost("{courseId}/posttest")]
        public async Task<ActionResult> AddCoursePostTest
            ([FromRoute] int courseId,
            [FromBody] DTO.TestCreateForm test)
        {
            //Getting User from HttpContext
            var username = User.FindFirst(ClaimTypes.Name).Value;
            var userModel = await _userManager.FindByNameAsync(username);
            var tutorModel = await _dataRepoCRUD.GetTutor(userModel.Id);
            if (tutorModel == null)
            {
                return new BadRequestObjectResult(new
                { Message = "Request not completed. User is not subscribed as Tutor." });
            }

            //Checking Correct Tutor
            var tutorcoursemodel = await _dataRepoCRUD.
                GetRequestedTutorCourse(courseId);
            if (tutorcoursemodel.TutorId != tutorModel.Id)
            {
                return new BadRequestObjectResult(new
                { Message = "You are not correct tutor." });
            }

            //Creating Database
            var testmodel = _mapper.Map<Test>(test);
            var coursemodel = await _dataRepoCRUD.GetCourse(courseId);
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

            return Ok();
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
