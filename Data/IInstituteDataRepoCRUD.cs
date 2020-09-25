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






    }
}
