using Institute.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData 
    {
        public async void CreateLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
        }
    }
}
