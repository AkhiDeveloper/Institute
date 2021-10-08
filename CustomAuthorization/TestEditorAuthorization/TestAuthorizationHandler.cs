using Institute.Data;
using Institute.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.CustomAuthorization
{
    public class TestAuthorizationHandler 
        : AuthorizationHandler<TestAuthorRequirements>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInstituteDataRepoCRUD _instituteData;

        public TestAuthorizationHandler(
            IHttpContextAccessor httpContextAccessor,
            IInstituteDataRepoCRUD instituteData)
        {
            _httpContextAccessor = httpContextAccessor;
            _instituteData = instituteData;
        }

        protected override Task HandleRequirementAsync
            (AuthorizationHandlerContext context, 
            TestAuthorRequirements requirement)
        {
            //Getting UserId
            var useridclaim = context.User.Claims
                .SingleOrDefault(x => x.Type == "Id");
            if (useridclaim == null)
            {
                return Task.CompletedTask;
            }
            var userid = useridclaim.Value;
            var tutorid = userid;


            //Getting testcode from from httprequest
            var routeValue = _httpContextAccessor
                .HttpContext
                .Request
                .RouteValues;
            object rawtestcode;
            routeValue.TryGetValue("testcode", out rawtestcode);
            if(rawtestcode==null)
            {
                var querystring = _httpContextAccessor
                    .HttpContext.Request.Query;
                rawtestcode=querystring["testcode"];
            }
            var testcode = rawtestcode.ToString();


            //getting testid from database
            var testmodeltask = _instituteData.GetTestByCode(testcode);
            var testmodel = testmodeltask.Result;
            if(testmodel == null)
            {
                return Task.CompletedTask;
            }
            var testid = testmodel.Id;


            //Getting courseids
            var lessonpretestmodeltask = _instituteData
                .GetLessonPreTest(testid);
            var lessonposttestmodeltask = _instituteData
                .GetLessonPostTest(testid);
            var chapterpretestmodeltask = _instituteData
                .GetChapterPreTest(testid);
            var chapterposttestmodeltask = _instituteData
                .GetChapterPostTest(testid);
            var coursepretestmodeltask = _instituteData
                .GetCoursePreTest(testid);
            var courseposttestmodeltask = _instituteData
                .GetCoursePostTest(testid);

            ICollection<Task<Lesson>> lessonmodelstask =
                new List<Task<Lesson>>();
            ICollection<Task<Chapter>> chaptermodelstask =
                new List<Task<Chapter>>();

            ICollection<string> asscourseids = new List<string>();

            lessonmodelstask
                .Add(_instituteData
                .GetLesson(lessonpretestmodeltask
                .GetAwaiter()
                .GetResult().RefLessonId));
            lessonmodelstask
                .Add(_instituteData
                .GetLesson(lessonposttestmodeltask
                .GetAwaiter()
                .GetResult().RefLessonId));

            chaptermodelstask
                .Add(_instituteData.
                GetChapter(chapterpretestmodeltask
                .GetAwaiter()
                .GetResult()
                .RefChapterId));
            chaptermodelstask
                .Add(_instituteData.
                GetChapter(chapterposttestmodeltask
                .GetAwaiter()
                .GetResult()
                .RefChapterId));

            asscourseids.Add(coursepretestmodeltask
                .GetAwaiter()
                .GetResult()
                .RefCourseId);
            asscourseids.Add(courseposttestmodeltask
                .GetAwaiter()
                .GetResult()
                .RefCourseId);
            
            foreach(var lessontask in lessonmodelstask)
            {
                chaptermodelstask
                    .Add(_instituteData
                    .GetChapter(lessontask
                    .GetAwaiter()
                    .GetResult()
                    .ChapterId));
            }

            foreach(var chaptertask in chaptermodelstask)
            {
                asscourseids
                    .Add(chaptertask
                    .GetAwaiter()
                    .GetResult()
                    .CourseId);
            }


            //Check ass. courseids author
            foreach(var courseid in asscourseids)
            {
                var coursetutorid = _instituteData
                    .GetRequestedTutorCourse(courseid)
                    .GetAwaiter()
                    .GetResult()
                    .TutorId;
                if(tutorid == coursetutorid)
                {
                    context.Succeed(requirement);
                    break;
                }                   
            }

            return Task.CompletedTask;
        }
    }
}
