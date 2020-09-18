using Institute.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class SqlInstituteData 
    {

        public void AddChapter(Course TargetCourse, Chapter newchapter)
        {
            if (newchapter == null)
            {
                throw new ArgumentNullException(nameof(newchapter));
            }

            newchapter.CourseId = TargetCourse.Id;
            _context.AddAsync(newchapter);
        }

        public async Task<IEnumerable<Chapter>> GetChapters(Course RefrenceCourse)
        {
            var chapteritems = from chap in await GetAllChapters()
                               where chap.CourseId == RefrenceCourse.Id
                               select chap;
            return chapteritems;
        }

        public async Task<IEnumerable<Chapter>> GetAllChapters()
        {
            var chapteritems = await _context.Chapters.ToListAsync();
            return chapteritems;
        }

        public async Task<Chapter> GetChapter(int chapterid)
        {
            var chapteritem = await _context.Chapters.FirstOrDefaultAsync(c => c.Id == chapterid);
            return chapteritem;
        }

        public void UpdateChapter(Chapter updatingchapter)
        {
            if(updatingchapter==null)
            {
                throw new ArgumentNullException(nameof(updatingchapter));
            }

            _context.Entry(updatingchapter).State = EntityState.Modified;
        }

        public void DeleteChapter(Chapter deletingchapter)
        {
            if (deletingchapter == null)
            {
                throw new ArgumentNullException(nameof(deletingchapter));
            }

            _context.Chapters.Remove(deletingchapter);
            
        }
    }
}
