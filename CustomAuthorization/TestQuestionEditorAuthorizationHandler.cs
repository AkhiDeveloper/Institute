using Institute.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.CustomAuthorization
{
    public class TestQuestionEditorAuthorizationHandler
        : AuthorizationHandler<QuestionEditorRequriement>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IInstituteDataRepoCRUD _instituteData;

        public TestQuestionEditorAuthorizationHandler(
            IHttpContextAccessor httpContextAccessor,
            IInstituteDataRepoCRUD instituteData)
        {
            _httpContextAccessor = httpContextAccessor;
            _instituteData = instituteData;
        }


        protected override Task HandleRequirementAsync
            (AuthorizationHandlerContext context, 
            QuestionEditorRequriement requirement)
        {
            try
            {
                //Getting UserId
                var useridclaim = context.User.Claims
                    .SingleOrDefault(x => x.Type == "Id");
                var userid = useridclaim.Value;
                var tutorid = userid;

                //Getting questioncode from from httprequest
                var routeValue = _httpContextAccessor
                    .HttpContext
                    .Request
                    .RouteValues;
                object rawquestioncode;
                routeValue.TryGetValue("questioncode", out rawquestioncode);
                if (rawquestioncode == null)
                {
                    var querystring = _httpContextAccessor
                        .HttpContext.Request.Query;
                    rawquestioncode = querystring["questioncode"];
                }
                var questioncode = rawquestioncode.ToString();

                //Getting QsnId
                var question = _instituteData
                    .GetQuestionByCode(questioncode)
                    .GetAwaiter()
                    .GetResult();
                var questionid = question.Id;

                //Getting TestQsn Author
                var testquesntion = _instituteData
                    .GetTestQuestion(questionid)
                    .GetAwaiter()
                    .GetResult();
                var test
                    
            }
        }
    }
}
