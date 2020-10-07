using Institute.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public interface IInstituteDataRepoCRUD
    {
        Task<bool> SaveChanges();

        //UserContext
        Task<Tutor> GetTutor(string tutorid);


        //CourseContext
        //TutorCourse
        void CreateRequestedTutorCourse(RequestedTutorCourse tutorCourse);

        Task<RequestedTutorCourse> GetRequestedTutorCourse(string courseid);

        //Course
        void CreateCourse(Course courseModel);
        Task<Course> GetCourse(string coursecode);
        void CreateCoursePreTest(CoursePreTest coursePreTest);
        void CreateCoursePostTest(CoursePostTest coursePostTest);
        void CreateCoursePreAssignment(CoursePreAssignment coursePreAssignment);
        void CreateCoursePostAssignment(CoursePostAssignment coursePostAssignment);

        //Chapter
        void CreateChapter(Chapter chapter);
        Task<Chapter> GetChapterBySN(string courseid, int chapterSN);

        //Lesson
        void CreateLesson(Lesson lesson);

        //User
        void CreateTutor(Tutor tutor);
        void CreateRoles(ICollection<IdentityRole> roles);
        void CreateRole(IdentityRole role);
        

        //void CreateCourse(Course newCourse);
        //Task<Course> GetCourse(int id);
        //Task<IEnumerable<Course>> GetAllCourses();
        //void UpdateCourse(Course updatingCourse);
        //void DeleteCourse(Course deletingCourse);

        ////TutorCourse
        //void CreateTutorCourse(RequestedTutorCourse newtutorCourse);
        //Task<RequestedTutorCourse> GetTutorCourse(int tutorId, int courseId);
        //Task<IEnumerable<RequestedTutorCourse>> GetTutorCourseByTutorId(int tutorid);
        //Task<IEnumerable<RequestedTutorCourse>> GetTutorCourseByCourseId(int courseid);
        //void UpdateCourse(RequestedTutorCourse updatingtutorCourse);
        //void DeleteCourse(RequestedTutorCourse deletingtutorCourse);



        ////CourseTest
        //void CreateCourseTest(CourseTest newcourseTest);
        //Task<CourseTest> GetCourseTest(int testid);
        //Task<IEnumerable<CourseTest>> GetAllCourseTests();
        //Task<IEnumerable<CourseTest>> GetCourseTestsByCourseId(int courseid);
        //void UpdateCourseTest(CourseTest updatingcourseTest);
        //void DeleteCourseTest(CourseTest deletingcourseTest);

        ////CourseTask
        //void CreateCourseTask(CourseAssignment newcourseTask);
        //Task<CourseAssignment> GetCourseTask(int taskid);
        //Task<IEnumerable<CourseAssignment>> GetAllCourseTasks();
        //Task<IEnumerable<CourseAssignment>> GetCourseTasksByCourseId(int courseid);
        //void UpdateCourseTask(CourseAssignment updatingCourseTask);
        //void DeleteCourseTask(CourseAssignment deletingCourseTask);



        ////ChapterContext
        ////Chapter
        //void CreateChapter(Chapter chapter);
        //Task<Chapter> GetChapter(int id);
        //Task<IEnumerable<Chapter>> GetAllChapters();
        //Task<IEnumerable<Chapter>> GetChaptersByCourseId(int courseId);
        //void UpdateChapter(Chapter updatingChapter);
        //void DeleteChapter(Chapter deletingchapter);

        ////ChapterTest
        //void CreateChapterTest(ChapterTest newChapterTest);
        //Task<ChapterTest> GetChapterTest(int testid);
        //Task<IEnumerable<ChapterTest>> GetAllChapterTests();
        //Task<IEnumerable<ChapterTest>> GetChapterTestsByChapterId(int Chapterid);
        //void UpdateChapterTest(ChapterTest updatingChapterTest);
        //void DeleteChapterTest(ChapterTest deletingChapterTest);

        ////ChapterTask
        //void CreateChapterTask(ChapterAssignment newChapterTask);
        //Task<ChapterAssignment> GetChapterTask(int taskid);
        //Task<IEnumerable<ChapterAssignment>> GetAllChapterTasks();
        //Task<IEnumerable<ChapterAssignment>> GetChapterTasksByChapterId(int Chapterid);
        //void UpdateChapterTask(ChapterAssignment updatingChapterTask);
        //void DeleteChapterTask(ChapterAssignment deletingChapterTask);



        ////LessonContext
        ////Lesson
        //void CreateLesson(Lesson Lesson);
        //Task<Lesson> GetLesson(int id);
        //Task<IEnumerable<Lesson>> GetAllLessons();
        //Task<IEnumerable<Lesson>> GetLessonsByChapterId(int chapterId);
        //void UpdateLesson(Lesson updatingLesson);
        //void DeleteLesson(Lesson deletingLesson);

        ////LessonTest
        //void CreateLessonTest(LessonTest newLessonTest);
        //Task<LessonTest> GetLessonTest(int testid);
        //Task<IEnumerable<LessonTest>> GetAllLessonTests();
        //Task<IEnumerable<LessonTest>> GetLessonTestsByLessonId(int Lessonid);
        //void UpdateLessonTest(LessonTest updatingLessonTest);
        //void DeleteLessonTest(LessonTest deletingLessonTest);

        ////LessonTask
        //void CreateLessonTask(LessonAssignment newLessonTask);
        //Task<LessonAssignment> GetLessonTask(int taskid);
        //Task<IEnumerable<LessonAssignment>> GetAllLessonTasks();
        //Task<IEnumerable<LessonAssignment>> GetLessonTasksByLessonId(int Lessonid);
        //void UpdateLessonTask(LessonAssignment updatingLessonTask);
        //void DeleteLessonTask(LessonAssignment deletingLessonTask);



    }
}
