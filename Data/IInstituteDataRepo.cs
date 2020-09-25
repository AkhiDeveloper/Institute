using Institute.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppTask = Institute.Model.Task;

namespace Institute.Data
{
    public interface IInstituteDataRepo
    {
        //Save Changes to database
        Task<bool> SaveChanges();

        //Courses
        //gives all courses in database
        Task<IEnumerable<Course>> GetAllCourses();
        Task<IEnumerable<Course>> GetAllRejisteredCourses();
        Task<IEnumerable<Course>> GetAllRequestedCourses();
        //returns course of givrn Id
        Task<Course> GetCourseById(int Id);
        //Create a new course
        void CreateCourse(Course newcourse);
        //Assign Course to the tutor
        void AssignCourse(Tutor uploader, Course refCourse, decimal uploaderShare);

        void LoadToRequestedCourse(Course refCourse);
        void DeleteFromRequestedCourse(Course refCourse);

        void LoadToRegisteredCourse(Course refCourse);
        void DeleteFromRegisteredCourse(Course refCourse);

        //Update changed attributes of given course
        void UpdateCourse(Course updatingcourse);
        //delete given course
        void DeleteCourse(Course deletingCourse);


        //Chapter
        //Add new chapter to given course
        void AddChapter(Course TargetCourse, Chapter newchapter);
        //returns chapters of given course
        Task<IEnumerable<Chapter>> GetChapters(Course RefrenceCourse);
        //returns all chapters of database
        Task<IEnumerable<Chapter>> GetAllChapters();
        //returns chapter belong to given Id
        Task<Chapter> GetChapter(int chapterid);
        //Update given chapter
        void UpdateChapter(Chapter updatingchapter);
        //Delete given chapter
        void DeleteChapter(Chapter deletingchapter);


        //Lessons
        //add lesson to the chapter
        void AddLesson(Chapter targetchapter, Lesson newlesson);
        //returns all lessons of refrence chapter
        Task<IEnumerable<Lesson>> GetLessons(Chapter refrencechapter);
        //returns all lessons of database
        Task<IEnumerable<Lesson>> GetAllLessons();
        //get a lesson by Id
        Task<Lesson> GetLesson(int lessonId);
        //Update given lesson
        void UpdateLesson(Lesson updatinglesson);
        //delete lesson
        void DeleteLesson(Lesson deletinglesson);


        //Tasks
        void AddTask(AppTask newtask);
        void AddTask<T>(T Target, AppTask newtask);
        Task<IEnumerable<AppTask>> GetAllTasks();
        Task<IEnumerable<AppTask>> GetTasks<T>(T Target);
        Task<AppTask> GetTaskById(int taskid);
        void UpdateTask(AppTask updatingtask);
        void DeleteTask(AppTask deleteTask);


        //Tests
        void AddTest(Test newtest);
        void AddTest<T>(T Target, Test newtask);
        Task<IEnumerable<Test>> GetAllTests();
        Task<IEnumerable<Test>> GetTests<T>(T Target);
        Task<AppTask> GetTestById(int testid);
        void UpdateTest(Test updatingtest);
        void DeleteTest(AppTask deleteTest);


        //Question Answer
        void AddQA(QA newQA);
        void AddQA<T>(QA newQA);
        Task<IEnumerable<QA>> GetAllQAs();
        Task<IEnumerable<QA>> GetAllQAs<T>();
        Task<QA> GetQAById(int qAId);
        void UpdateQA(QA updatingQA);
        void DeleteQA(QA deletingQA);


        //User Detail
        Task<Tutor> GetTutorById(int id); 





    }
}
