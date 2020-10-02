using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Repository.FileManager
{
    public class DefaultFileManager : IFileManager
    {
        public Task<string> SaveFile(IFormFile uploadingfile)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFile(string folder, IFormFile uploadingfile)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFileToDefaultFolder(IFormFile uploadingfile)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFileToDefaultFolder(string subfolder, IFormFile uploadingfile)
        {
            throw new NotImplementedException();
        }
    }
}
