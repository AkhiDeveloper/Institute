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
                return new BadRequestObjectResult(new { Message = "You sent wrong data model" });
            }

            var appUser = new ApplicationUser() { UserName = user.Email, Email = user.Email };
            var result = await _userManager.CreateAsync(appUser, user.Password);

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

            var token = GenerateToken(userModel);
            return Ok(new { Token = token, Message = "Success" });
        }

        [Authorize]
        [HttpGet]
        [Route("Detail")]
        public async Task<ActionResult<ApplicationUser>> GetLoginUser()
        {
            var userName = User.FindFirst(ClaimTypes.Name).Value;
            var userDetail = await _userManager.FindByNameAsync(userName);
            return Ok(userDetail);
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


        private object GenerateToken(ApplicationUser appUser)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = _jwttokensetting.SecurityKey;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Id",appUser.Id.ToString()),
                    new Claim(ClaimTypes.Name, appUser.UserName.ToString()),
                    new Claim(ClaimTypes.Email, appUser.Email),
                }),

                Expires = DateTime.UtcNow.AddSeconds(_jwttokensetting.ExpiryTimeInSeconds),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Audience = _jwttokensetting.Audience,
                Issuer = _jwttokensetting.Issuer
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


    }
}
