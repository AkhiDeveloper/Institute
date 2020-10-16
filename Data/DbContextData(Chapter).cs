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
        public async void CreateChapter
            (Chapter chapter)
        {
            await _context.Chapters.AddAsync(chapter);
        }

        public async void CreateChapterPostAssignment
            (ChapterPostAssignment chapterpostassignment)
        {
            await _context.ChapterPostAssignments.AddAsync(chapterpostassignment);
        }

        public async void CreateChapterPostTest
            (ChapterPostTest chapterposttestmodel)
        {
            await _context.ChapterPostTests.AddAsync(chapterposttestmodel);
        }

        public async void CreateChapterPreAssignment
            (ChapterPreAssignment chapterpreassignment)
        {
            await _context.ChapterPreAssignments.AddAsync(chapterpreassignment);
        }

        public async void CreateChapterPreTest
            (ChapterPreTest chapterpretestmodel)
        {
            await _context.ChapterPreTests.AddAsync(chapterpretestmodel);
        }

        public async Task<Chapter> GetChapter(string id)
        {
            var result = await _context.Chapters.FindAsync(id);
            return result;
        }

        public async Task<Chapter> GetChapterBySN
            (string courseid, int chapterSN)
        {
            var result = await _context.Chapters
                .Where(x => x.CourseId == courseid)
                .FirstOrDefaultAsync(x => x.SN == chapterSN);

            return result;
        }

        public async Task<ChapterPostTest> GetChapterPostTest(string testid)
        {
            var result = await _context.ChapterPostTests
                .FindAsync(testid);
            return result;
        }

        public async Task<ChapterPreTest> GetChapterPreTest(string testid)
        {
            var result = await _context.ChapterPreTests
                .FindAsync(testid);
            return result;
        }

        
    }
}
