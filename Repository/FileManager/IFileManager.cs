using Institute.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Repository.FileManager
{
    public interface IFileManager
    {
        //All save methods returns the file path of saved file
        Task<string> SaveFile(IFormFile uploadingfile);
        Task<string> SaveFile(string folder, IFormFile uploadingfile);
        Task<string> SaveFileToDefaultFolder(IFormFile uploadingfile);
        Task<string> SaveFileToDefaultFolder(string subfolder, IFormFile uploadingfile);
    }
}
