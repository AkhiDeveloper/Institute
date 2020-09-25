using Institute.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public interface IInstituteDataRepoCRUD
    {
        Task<bool> SaveChanges();


        //CourseContext
        //Course
        void CreateCourse(Course newCourse);
        Task<Course> GetCourse(int id);
        Task<IEnumerable<Course>> GetAllCourses();
        void UpdateCourse(Course updatingCourse);
        void DeleteCourse(Course deletingCourse);

        //TutorCourse
        void CreateTutorCourse(TutorCourse newtutorCourse);
        Task<TutorCourse> GetTutorCourse(int tutorId, int courseId);
        Task<IEnumerable<TutorCourse>> GetTutorCourseByTutorId(int tutorid);
        Task<IEnumerable<TutorCourse>> GetTutorCourseByCourseId(int courseid);
        void UpdateCourse(TutorCourse updatingtutorCourse);
        void DeleteCourse(TutorCourse deletingtutorCourse);

        //RequestedCourse
        void CreateRequestedCourse(RequestedCourse newrequestedCourse);
        Task<RequestedCourse> GetRequestedCourse(int courseId);
        Task<IEnumerable<RequestedCourse>> GetAllRequestedCourses();
        void UpdateCourse(RequestedCourse updatingrequestedCourse);
        void DeleteCourse(RequestedCourse deletingrequestedCourse);

        //RegisteredCourse
        void CreateRegisteredCourse(RejisteredCourse newrregisteredCourse);
        Task<RejisteredCourse> GetRegisteredCourse(int courseId);
        Task<IEnumerable<RejisteredCourse>> GetAllRegisteredCourses();
        void UpdateRegisteredCourse(RejisteredCourse updatingrejisteredCourse);
        void DeleteRegisteredCourse(RejisteredCourse deletingrejisteredCourse);

        //CourseTest
        void CreateCourseTest(CourseTest newcourseTest);
        Task<CourseTest> GetCourseTest(int testid);
        Task<IEnumerable<CourseTest>> GetAllCourseTests();
        Task<IEnumerable<CourseTest>> GetCourseTestsByCourseId(int courseid);
        void UpdateCourseTest(CourseTest updatingcourseTest);
        void DeleteCourseTest(CourseTest deletingcourseTest);

        //CourseTask
        void CreateCourseTask(CourseTask newcourseTask);
        Task<CourseTask> GetCourseTask(int taskid);
        Task<IEnumerable<CourseTask>> GetAllCourseTasks();
        Task<IEnumerable<CourseTask>> GetCourseTasksByCourseId(int courseid);
        void UpdateCourseTask(CourseTask updatingCourseTask);
        void DeleteCourseTask(CourseTask deletingCourseTask);



        //ChapterContext
        //Chapter
        void CreateChapter(Chapter chapter);
        Task<Chapter> GetChapter(int id);
        Task<IEnumerable<Chapter>> GetAllChapters();
        Task<IEnumerable<Chapter>> GetChaptersByCourseId(int courseId);
        void UpdateChapter(Chapter updatingChapter);
        void DeleteChapter(Chapter deletingchapter);

        //ChapterTest
        void CreateChapterTest(ChapterTest newChapterTest);
        Task<ChapterTest> GetChapterTest(int testid);
        Task<IEnumerable<ChapterTest>> GetAllChapterTests();
        Task<IEnumerable<ChapterTest>> GetChapterTestsByChapterId(int Chapterid);
        void UpdateChapterTest(ChapterTest updatingChapterTest);
        void DeleteChapterTest(ChapterTest deletingChapterTest);

        //ChapterTask
        void CreateChapterTask(ChapterTask newChapterTask);
        Task<ChapterTask> GetChapterTask(int taskid);
        Task<IEnumerable<ChapterTask>> GetAllChapterTasks();
        Task<IEnumerable<ChapterTask>> GetChapterTasksByChapterId(int Chapterid);
        void UpdateChapterTask(ChapterTask updatingChapterTask);
        void DeleteChapterTask(ChapterTask deletingChapterTask);



        //LessonContext
        //Lesson
        void CreateLesson(Lesson Lesson);
        Task<Lesson> GetLesson(int id);
        Task<IEnumerable<Lesson>> GetAllLessons();
        Task<IEnumerable<Lesson>> GetLessonsByChapterId(int chapterId);
        void UpdateLesson(Lesson updatingLesson);
        void DeleteLesson(Lesson deletingLesson);

        //LessonTest
        void CreateLessonTest(LessonTest newLessonTest);
        Task<LessonTest> GetLessonTest(int testid);
        Task<IEnumerable<LessonTest>> GetAllLessonTests();
        Task<IEnumerable<LessonTest>> GetLessonTestsByLessonId(int Lessonid);
        void UpdateLessonTest(LessonTest updatingLessonTest);
        void DeleteLessonTest(LessonTest deletingLessonTest);

        //LessonTask
        void CreateLessonTask(LessonTask newLessonTask);
        Task<LessonTask> GetLessonTask(int taskid);
        Task<IEnumerable<LessonTask>> GetAllLessonTasks();
        Task<IEnumerable<LessonTask>> GetLessonTasksByLessonId(int Lessonid);
        void UpdateLessonTask(LessonTask updatingLessonTask);
        void DeleteLessonTask(LessonTask deletingLessonTask);



    }
}
