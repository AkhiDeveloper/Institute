using Institute.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData
    {
        public async void CreateRequestedTutorCourse(RequestedTutorCourse tutorCourse)
        {
            await _context.RequestedTutorCourses.AddAsync(tutorCourse);
        }

        public async Task<RequestedTutorCourse> GetRequestedTutorCourse(string courseid)
        {
            var result = await _context.RequestedTutorCourses
                .Include(x => x.CourseDetail)
                .FirstOrDefaultAsync(x => x.CourseId == courseid);

            return result;
        }
    }
}
