using Institute.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Repository
{
    interface IUserAuthorizeRepo
    {
        public enum Role { User, Student, Tutor, Admin}

        public Task<string> GetBearerToken(ApplicationUser loginUser);

        public Task<ApplicationUser> GetLoginUser();

        public void SetRole(Role newrole);

        public Task<bool> ValidateUser(string userName, string password);

        public Task<IdentityResult> RegisterUser(
            ApplicationUser newUser, string newpassword, string confirmedPassword);
    }
}
