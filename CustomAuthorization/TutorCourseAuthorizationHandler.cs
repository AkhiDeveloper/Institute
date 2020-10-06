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
            object rawcourseId;
            routeValue.TryGetValue("courseId", out rawcourseId);
            if(rawcourseId == null)
            {
                return Task.CompletedTask;
            }
            var courseid = Int32.Parse(rawcourseId.ToString());


            //Checking association
            var tutorcoursemodel = _instituteData.
                GetRequestedTutorCourse(courseid).Result;
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
