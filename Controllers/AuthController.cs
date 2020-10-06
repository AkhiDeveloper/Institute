using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Institute.DTOs;
using Institute.Model;
using Institute.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Institute.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtBearerTokenSetting _jwttokensetting;
        private readonly IMapper _mapper;

        public AuthController
            (UserManager<ApplicationUser> userManager,
            IOptions<JwtBearerTokenSetting> jwtsettingoptions,
            IMapper mapper)
        {
            _userManager = userManager;
            _jwttokensetting = jwtsettingoptions.Value;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisteration user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return new BadRequestObjectResult(new 
                { Message = "You sent wrong data model" });
            }

            var appUser = new ApplicationUser() 
                { UserName = user.Email, Email = user.Email };
            var result = await _userManager.CreateAsync(appUser, user.Password);
            await _userManager.AddToRoleAsync(appUser, "User");

            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }

                return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
            }

            return Ok(new { Message = "User Reigstration Successful" });
        }
        

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin credentials)
        {
            ApplicationUser userModel;

            if (!ModelState.IsValid
                || credentials == null
                || (userModel = await ValidateUser(credentials)) == null)
            {
                return new BadRequestObjectResult(new { Message = "Login failed" });
            }

            var userroles = await _userManager.GetRolesAsync(userModel);
            if(userroles == null)
            {
                return BadRequest(new
                {
                    Message = "Any role of user is not recognized. Please reregister yourself or contact admin."
                });
            }

            var token = GenerateToken(userModel,userroles);
            return Ok(new { Token = token, Message = "Success" });
        }

        private async Task<ApplicationUser> ValidateUser(UserLogin credentials)
        {
            var userModel = await _userManager.FindByNameAsync(credentials.Email);
            if (userModel != null)
            {
                var result = _userManager.PasswordHasher.VerifyHashedPassword(userModel, userModel.PasswordHash, credentials.Password);
                return result == PasswordVerificationResult.Failed ? null:userModel;
            }

            return null;
        }


        private object GenerateToken(ApplicationUser appUser,IList<string> roles)
        {
            //Creating claims list
            var roleclaims = new List<Claim>();
            //Adding role claims
            foreach(var role in roles)
            {
                roleclaims.Add(new Claim
                    (ClaimTypes.Role, role));
            }
            //Adding General Claims
            roleclaims.AddRange(new Claim[]
                {
                    new Claim
                        ("Id", appUser.Id.ToString()),
                    new Claim
                        (ClaimTypes.Name, appUser.UserName.ToString()),
                    new Claim
                        (ClaimTypes.Email, appUser.Email),
                });

            //Creating token discriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(roleclaims),

                Expires = DateTime.UtcNow.AddSeconds
                    (_jwttokensetting.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials
                    (_jwttokensetting.SecurityKey, 
                SecurityAlgorithms.HmacSha256Signature),
                    Audience = _jwttokensetting.Audience,
                Issuer = _jwttokensetting.Issuer
            };

            //creating token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
