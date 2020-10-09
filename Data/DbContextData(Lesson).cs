using Institute.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData : IInstituteDataRepoCRUD
    {
        public async void CreateLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
        }

        public async void CreateLessonPostAssignment
            (LessonPostAssignment lessonPostAssignment)
        {
            await _context.LessonPostAssignments.AddAsync(lessonPostAssignment);
        }

        public async void CreateLessonPostTest
            (LessonPostTest lessonPostTest)
        {
            await _context.LessonPostTests.AddAsync(lessonPostTest);
        }
    

        public async void CreateLessonPreAssignment
            (LessonPreAssignment lessonPreAssignment)
        {
            await _context.LessonPreAssignments.AddAsync(lessonPreAssignment);
        }

        public async void CreateLessonPreTest
            (LessonPreTest lessonpretest)
        {
            await _context.LessonPreTests.AddAsync(lessonpretest);
        }

        public async Task<Lesson> GetLesson(string id)
        {
            var lessonmodel =
                await _context.Lessons.FirstOrDefaultAsync(x => x.Id == id);

            return lessonmodel;
        }

        public async Task<Lesson> GetLessonBySN(string chapterid, int lessonSN)
        {
            var lessonmodel =
                await _context.Lessons
                .Where(x => x.ChapterId == chapterid)
                .FirstOrDefaultAsync(x => x.SN == lessonSN);

            return lessonmodel;
        }
    }
}
