using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Repository.FileManager
{
    public class DefaultFileManager : IFileManager
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _defaultFolder;

        //Constructors
        public DefaultFileManager(
            IWebHostEnvironment webHostEnvironment,
            string defaultFolder)
        {
            _webHostEnvironment = webHostEnvironment;
            _defaultFolder = defaultFolder;
        }

        public DefaultFileManager(
            IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _defaultFolder = "Files";
        }

        //Methods
        public async Task<string> SaveFile
            (IFormFile uploadingfile)
        {
            if (uploadingfile == null)
            {
                return null;
            }

            bool successFlag = false;
            string rootpath = _webHostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(rootpath))
            {
                rootpath = Directory.GetCurrentDirectory();
            }

            var uploadfolder = Path.Combine(rootpath);

            var uniquefilename = Guid.NewGuid().ToString()
                + "_" + uploadingfile.FileName;

            if (!Directory.Exists(uploadfolder))
            {
                Directory.CreateDirectory(uploadfolder);
            }

            var filepath = Path.Combine(uploadfolder, uniquefilename);

            using (var filestream = new
                FileStream(filepath, FileMode.CreateNew))
            {
                await uploadingfile.CopyToAsync(filestream);
                successFlag = true;
            }

            if (successFlag == false)
            {
                return null;
            }

            return filepath;
        }

        public async Task<string> SaveFile
            (string folder, IFormFile uploadingfile)
        {
            if (uploadingfile == null)
            {
                return null;
            }

            bool successFlag = false;
            string rootpath = _webHostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(rootpath))
            {
                rootpath = Directory.GetCurrentDirectory();
            }

            var uploadfolder = Path.Combine(rootpath, folder);

            var uniquefilename = Guid.NewGuid().ToString()
                + "_" + uploadingfile.FileName;

            if (!Directory.Exists(uploadfolder))
            {
                Directory.CreateDirectory(uploadfolder);
            }

            var filepath = Path.Combine(uploadfolder, uniquefilename);

            using (var filestream = new
                FileStream(filepath, FileMode.CreateNew))
            {
                await uploadingfile.CopyToAsync(filestream);
                successFlag = true;
            }

            if (successFlag == false)
            {
                return null;
            }

            return filepath;
        }

        public async Task<string> SaveFileToDefaultFolder
            (IFormFile uploadingfile)
        {
            if(uploadingfile == null)
            {
                return null;
            }

            bool successFlag = false;
            string rootpath = _webHostEnvironment.WebRootPath;
            if(string.IsNullOrEmpty(rootpath))
            {
                rootpath = Directory.GetCurrentDirectory();
            }

            var uploadfolder = Path.Combine(rootpath, _defaultFolder);

            var uniquefilename = Guid.NewGuid().ToString()
                + "_" + uploadingfile.FileName;

            if(!Directory.Exists(uploadfolder))
            {
                Directory.CreateDirectory(uploadfolder);
            }

            var filepath = Path.Combine(uploadfolder, uniquefilename);

            using(var filestream = new
                FileStream(filepath, FileMode.CreateNew))
            {
                await uploadingfile.CopyToAsync(filestream);
                successFlag = true;
            }

            if(successFlag == false)
            {
                return null;
            }

            return filepath;
        }

        public async Task<string> SaveFileToDefaultFolder
            (string subfolder, IFormFile uploadingfile)
        {
            if (uploadingfile == null)
            {
                return null;
            }

            bool successFlag = false;
            string rootpath = _webHostEnvironment.WebRootPath;
            if (string.IsNullOrEmpty(rootpath))
            {
                rootpath = Directory.GetCurrentDirectory();
            }

            var uploadfolder = Path.Combine(rootpath, _defaultFolder, subfolder);

            var uniquefilename = Guid.NewGuid().ToString()
                + "_" + uploadingfile.FileName;

            if (!Directory.Exists(uploadfolder))
            {
                Directory.CreateDirectory(uploadfolder);
            }

            var filepath = Path.Combine(uploadfolder, uniquefilename);

            using (var filestream = new
                FileStream(filepath, FileMode.CreateNew))
            {
                await uploadingfile.CopyToAsync(filestream);
                successFlag = true;
            }

            if (successFlag == false)
            {
                return null;
            }

            return filepath;
        }
    }
}
