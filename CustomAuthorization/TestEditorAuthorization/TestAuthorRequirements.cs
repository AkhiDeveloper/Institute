using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.CustomAuthorization
{
    public class TestAuthorRequirements : IAuthorizationRequirement
    {
        public TestAuthorRequirements()
        {

        }
    }
}
