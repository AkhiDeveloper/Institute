using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Institute.Data;
using Institute.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace Institute.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IInstituteDataRepoCRUD _dataRepoCRUD;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(
            IInstituteDataRepoCRUD dataRepoCRUD,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _dataRepoCRUD = dataRepoCRUD;
            _mapper = mapper;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                return BadRequest(new
                {
                    Message = "Please Input role.",
                });
            }
            var rolemodel = new IdentityRole()
            {
                Name = role,
                NormalizedName = role.ToUpper(),
            };
            _dataRepoCRUD.CreateRole(rolemodel);
            await _dataRepoCRUD.SaveChanges();
            return Ok(rolemodel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("setrole/{username}")]
        public async Task<IActionResult> SetRole
            (string username, string role)
        {
            var user = await _userManager.FindByNameAsync(username);
            if(user == null)
            {
                return BadRequest(new
                {
                    Message = "User not found",
                });
            }
            if (role == null)
            {
                return BadRequest(new
                {
                    Message = "Invalid role",
                });
            }

            await _userManager.AddToRoleAsync(user, role);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("initialize")]
        public async Task<IActionResult> Initialize()
        {
            string adminusername = "akhi_3466";
            string email = "ashishcurocity@gmail.com";
            string password = "^}F4z,>-cmqK%/Uw";
            string[] roles = { "Admin", "User" };

            //creating Application user
            var appUser = new ApplicationUser()
            {
                UserName = adminusername,
                Email = email,
            };
            var result = await _userManager
                .CreateAsync(appUser, password);
            if (!result.Succeeded)
            {
                var dictionary = new ModelStateDictionary();
                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }
                    return new BadRequestObjectResult(new
                    { Message = "User Registration Failed", 
                        Errors = dictionary });
                             
            }

            //Creating role          
            foreach (var role in roles)
            {
                var rolemodel = new IdentityRole()
                {
                    Name = role,
                    NormalizedName = role.ToUpper(),
                };
                _dataRepoCRUD.CreateRole(rolemodel);
                await _dataRepoCRUD.SaveChanges();
            }

            //Creating tutor
            var tutor = new Tutor
            {
                UserDetail = appUser,
            };
            _dataRepoCRUD.CreateTutor(tutor);
            await _dataRepoCRUD.SaveChanges();

            //Assigning role to user
            await _userManager.AddToRolesAsync(appUser, roles);

            return Ok(new { Message = "First Admin Sucessfully Reigstration Successful" });
        }

    }
}
