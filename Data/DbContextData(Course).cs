using Institute.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData 
    {
        public async void CreateCoursePreTest(CoursePreTest coursePreTest)
        {
            await _context.CoursePreTests.AddAsync(coursePreTest);
        }

        public async void CreateCoursePostTest(CoursePostTest coursePostTest)
        {
            await _context.CoursePostTests.AddAsync(coursePostTest);
        }

        public async void CreateCoursePreAssignment
            (CoursePreAssignment coursePreAssignment)
        {
            await _context.CoursePreAssignments.AddAsync(coursePreAssignment);
        }

        public async void CreateCoursePostAssignment
            (CoursePostAssignment coursePostAssignment)
        {
            await _context.CoursePostAssignments.AddAsync(coursePostAssignment);
        }

        public async Task<Course> GetCourse(int courseid)
        {
            var result = await _context.Courses
                .FirstOrDefaultAsync(x => x.Id == courseid);
               
            return result;
        }
    }
}
