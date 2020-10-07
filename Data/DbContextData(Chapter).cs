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
        public async void CreateChapter(Chapter chapter)
        {
            await _context.Chapters.AddAsync(chapter);
        }

       

        public async Task<Chapter> GetChapterBySN(string courseid, int chapterSN)
        {
            var result = await _context.Chapters
                .Where(x => x.CourseId == courseid)
                .FirstOrDefaultAsync(x => x.SN == chapterSN);

            return result;
        }
    }
}
