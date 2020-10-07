using Institute.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.CustomAuthorization
{
    public class TutorCourseAuthorizationHandler :
        AuthorizationHandler<TutorCourseRequriements>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInstituteDataRepoCRUD _instituteData;

        public TutorCourseAuthorizationHandler
            (IHttpContextAccessor httpContextAccessor, 
            IInstituteDataRepoCRUD instituteData)
        {
            _httpContextAccessor = httpContextAccessor;
            _instituteData = instituteData;
        }

        protected override Task HandleRequirementAsync
            (AuthorizationHandlerContext context, 
            TutorCourseRequriements requirement)
        {
            //Getting UserId
            var useridclaim = context.User.Claims
                .SingleOrDefault(x => x.Type == "Id");
            if(useridclaim == null)
            {
                return Task.CompletedTask;
            }
            var userid = useridclaim.Value;


            //getting courseid
            var routeValue = _httpContextAccessor
                .HttpContext
                .Request
                .RouteValues;
            object rawcoursecode;
            routeValue.TryGetValue("coursecode", out rawcoursecode);
            if(rawcoursecode == null)
            {
                var querystring = _httpContextAccessor
                    .HttpContext
                    .Request
                    .Query;
                rawcoursecode = querystring["coursecode"];
            }
            var coursecode = rawcoursecode.ToString();
            var course = _instituteData.GetCourse(coursecode).Result;
            if(course == null)
            {
                return Task.CompletedTask;
            }
            var coureid = course.Id;

            //Checking association
            var tutorcoursemodel = _instituteData.
                GetRequestedTutorCourse(coureid).Result;
            if (tutorcoursemodel == null)
            {
                return Task.CompletedTask;
            }

            if (tutorcoursemodel.TutorId == userid)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
