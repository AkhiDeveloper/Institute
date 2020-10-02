using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Institute.Data;
using Institute.DTOs;
using Institute.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Institute.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IInstituteDataRepoCRUD _dataRepoCRUD;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController
            (
            //IInstituteDataRepo repository,
            IInstituteDataRepoCRUD dataRepoCRUD,
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment webHostEnvironment
            )
        {
            //_repository = repository;
            _dataRepoCRUD = dataRepoCRUD;
            _mapper = mapper;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Post
            (IFormFile uploadedfile, CancellationToken token)
        {
            if (uploadedfile != null)
            {
                //foreach (var uploadedfile in uploadedfiles)
                {
                    string webrootpath = _webHostEnvironment.WebRootPath;
                    if(string.IsNullOrEmpty(webrootpath))
                    {
                        webrootpath = Directory.GetCurrentDirectory();
                    }
                    string uploadsFolder = Path.Combine
                            (webrootpath,
                            "Files");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_"
                            + uploadedfile.FileName;
                    var filepath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var filestream = new FileStream(filepath, FileMode.Create))
                    {
                        await uploadedfile.CopyToAsync(filestream);
                    }
                }
                return Ok();
            }
            return NotFound();
        }
    }
}
