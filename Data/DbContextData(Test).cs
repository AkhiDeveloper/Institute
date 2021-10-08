using Institute.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData
        : IInstituteDataRepoCRUD
    {
        public async Task CreateTestQuestion(TestQuestion testQuestion)
        {
            await _context.AddAsync<TestQuestion>(testQuestion);
        }

        public async Task<LessonPostTest> 
            GetLessonPostTest(string testid)
        {
            var result = await _context.LessonPostTests
                .FindAsync(testid);
            return result;
        }

        public async Task<LessonPreTest> 
            GetLessonPreTest(string testid)
        {
            var result = await _context.LessonPreTests
                .FindAsync(testid);
            return result;
        }

        public async Task<Test> GetTestByCode(string testcode)
        {
            var result = await _context.Tests
                .FirstOrDefaultAsync(x => x.Code == testcode);

            return result;
        }

        public async Task<TestQuestion> GetTestQuestion(string questionid)
        {
            var result = await _context.TestQuestions
                .FindAsync(questionid);
            return result;
        }
    }
}
