using Institute.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.CustomAuthorization
{
    public class ChapterPostTestRequriements
        : IAuthorizationRequirement
    {
        public ChapterPostTestRequriements()
        {

        }

    }


    public class ChapterPostTestAuthorizationHandler
        : AuthorizationHandler<TestAuthorRequirements>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInstituteDataRepoCRUD _instituteData;

        public ChapterPostTestAuthorizationHandler(
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
            try
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
                if (rawtestcode == null)
                {
                    var querystring = _httpContextAccessor
                        .HttpContext.Request.Query;
                    rawtestcode = querystring["testcode"];
                }
                if (rawtestcode == null)
                {
                    return Task.CompletedTask;
                }
                var testcode = rawtestcode.ToString();

                //Getting Testid
                var test = _instituteData
                    .GetTestByCode(testcode)
                    .GetAwaiter()
                    .GetResult();
                if (test == null)
                {
                    return Task.CompletedTask;
                }
                var testid = test.Id;

                //Geting ChapterPostTest Author
                var chapterposttest = _instituteData
                    .GetChapterPostTest(testid)
                    .GetAwaiter()
                    .GetResult();
                var chapterid = chapterposttest.RefChapterId;
                var chapter = _instituteData
                    .GetChapter(chapterid)
                    .GetAwaiter()
                    .GetResult();
                var courseid = chapter.CourseId;
                var requestedcourse = _instituteData
                    .GetRequestedTutorCourse(courseid)
                    .GetAwaiter()
                    .GetResult();
                var author = _instituteData
                    .GetTutor(requestedcourse.TutorId)
                    .GetAwaiter()
                    .GetResult();

                //Checking Author with user
                if (author.Id == userid)
                {
                    context.Succeed(requirement);
                }

                return Task.CompletedTask;
            }
            catch
            {
                return Task.CompletedTask;
            }
        }
    }
}
