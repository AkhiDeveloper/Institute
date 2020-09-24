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
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace Institute.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly  IInstituteDataRepo _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoursesController
            (
            IInstituteDataRepo repository, 
            IMapper mapper,
            UserManager<ApplicationUser> userManager
            )
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }
        
        //get api/courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseReadDTO>>> GetAllCourses()
        {
            var courseitems = await _repository.GetAllCourses();
            if (courseitems != null)
            {
                return Ok(_mapper.Map<IEnumerable<CourseReadDTO>>(courseitems));
            }
            return NotFound();
        }

        //get api/courses/{id}
        [HttpGet("{id}",Name ="GetCourseById")]
        public async Task<ActionResult<CourseReadDTO>> GetCourseById(int id)
        {
            var courseitem = await _repository.GetCourseById(id);
            if (courseitem != null)
            {
                return Ok(_mapper.Map<CourseReadDTO>(courseitem));
            }
            return NotFound();
        }

        //POST api/courses
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CourseReadDTO>> AddNewCourse
            (CourseCreateDTO newcourse)
        {
            //Map DTO to Model
            var courseModel = _mapper.Map<Course>(newcourse);

            //Getting User from HttpContext
            var username = User.FindFirst(ClaimTypes.Name).Value;
            var userModel = await _userManager.FindByNameAsync(username);
            var tutorModel = await _repository.GetTutorById(userModel.Id);
            if(tutorModel==null)
            {
                return new BadRequestObjectResult(new
                { Message = "Request not completed. User is not subscribed as Tutor." });
            }

            //Change to database
            _repository.CreateCourse(courseModel);
            await _repository.SaveChanges();

            _repository.AssignCourse(tutorModel, courseModel,newcourse.TutorShare);
            await _repository.SaveChanges();

            _repository.LoadToRequestedCourse(courseModel, newcourse.TutorShare);
            await _repository.SaveChanges();
            

            //Map Model to DTO
            var courseReadDTO = _mapper.Map<CourseReadDTO>(courseModel);

            return CreatedAtRoute(nameof(GetCourseById),
                new { Id = courseModel.Id }, courseReadDTO);
        }

        //PUT api/courses/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCourse(int id,CourseUpdateDTO courseUpdate)
        {
            var courseolditem = await _repository.GetCourseById(id);
            if(courseolditem==null)
            {
                return NotFound();
            }
            _mapper.Map(courseUpdate, courseolditem);

            _repository.UpdateCourse(courseolditem);

            await _repository.SaveChanges();

            return NoContent();
        }

        //Patch api/courses/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialCourseUpdate
            (int id, JsonPatchDocument<CourseUpdateDTO> patchDocument)
        {
            var courseolditem = await _repository.GetCourseById(id);
            if (courseolditem == null)
            {
                return NotFound();
            }

            var courseToPatch = _mapper.Map<CourseUpdateDTO>(courseolditem);

            //Update specific attributes
            patchDocument.ApplyTo(courseToPatch, ModelState);

            if(!TryValidateModel(courseToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(courseToPatch, courseolditem);

            _repository.UpdateCourse(courseolditem);

            await _repository.SaveChanges();

            return NoContent();
        }

        //Delete api/courses/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var courseitem = await _repository.GetCourseById(id);
            if (courseitem == null)
            {
                return NotFound();
            }

            _repository.DeleteCourse(courseitem);
            await _repository.SaveChanges();

            return NoContent();
        }

    }
}
