using Institute.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class SqlInstituteData 
    {
        public void CreateCourse(Course newcourse)
        {
            if (newcourse == null)
            {
                throw new ArgumentNullException(nameof(newcourse));
            }

            _context.Courses.AddAsync(newcourse);   
        }

        public void AssignCourse(Tutor uploader, Course refCourse, decimal uploaderShare)
        {
            if (refCourse == null)
            {
                throw new ArgumentNullException(nameof(refCourse));
            }

            if(uploader==null)
            {
                throw new ArgumentNullException(nameof(uploader));
            }

            _context.TutorCourses.AddAsync(new RequestedTutorCourse
            {
                TutorId = uploader.Id,
                CourseId = refCourse.Id,
                TutorShare = uploaderShare
            });
        }



        public void DeleteCourse(Course deletingCourse)
        {
            if (deletingCourse == null)
            {
                throw new ArgumentNullException(nameof(deletingCourse));
            }

            _context.Courses.Remove(deletingCourse);
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public Task<IEnumerable<Course>> GetAllRejisteredCourses()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAllRequestedCourses()
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetCourseById(int Id)
        {
            return await _context.Courses.
                FirstOrDefaultAsync(p => p.Id == Id);
        }

        public void UpdateCourse(Course updatingcourse)
        {
            //nothing
        }

        

        public void DeleteFromRequestedCourse(Course refCourse)
        {
            throw new NotImplementedException();
        }

        public void LoadToRegisteredCourse(Course refCourse)
        {
            throw new NotImplementedException();
        }

        public void DeleteFromRegisteredCourse(Course refCourse)
        {
            throw new NotImplementedException();
        }
    } 
    
}
