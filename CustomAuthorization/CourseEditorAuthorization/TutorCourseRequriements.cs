using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.CustomAuthorization
{
    public class TutorCourseRequriements : 
        IAuthorizationRequirement
    {
        public TutorCourseRequriements()
        {

        }
    }
}
