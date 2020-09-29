using Institute.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class SqlInstituteData
    {
        public void AddLesson(Chapter targetchapter, Lesson newlesson)
        {
            if (newlesson == null)
            {
                throw new ArgumentNullException(nameof(newlesson));
            }
            newlesson.ChapterId = targetchapter.Id;
            _context.Lessons.AddAsync(newlesson);
        }

        public void DeleteLesson(Lesson deletinglesson)
        {
            if (deletinglesson == null)
            {
                throw new ArgumentNullException(nameof(deletinglesson));
            }
            _context.Lessons.Remove(deletinglesson);
        }

        public async Task<IEnumerable<Lesson>> GetLessons(Chapter refrencechapter)
        {
            var lessonitems = from l in await GetAllLessons()
                              where l.ChapterId == refrencechapter.Id
                              select l;

            return lessonitems;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessons()
        {
            var lessonitems = await _context.Lessons.ToListAsync();
            return lessonitems;
        }

        public async Task<Lesson> GetLesson(int lessonId)
        {
            var lessonitem = await _context.Lessons.FirstOrDefaultAsync();
            return lessonitem;
        }

        public void UpdateLesson(Lesson updatinglesson)
        {
            if (updatinglesson == null)
            {
                throw new ArgumentNullException(nameof(updatinglesson));
            }

            _context.Entry(updatinglesson).State = EntityState.Modified;
        }
    }
}
