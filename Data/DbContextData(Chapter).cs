using Institute.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData : IInstituteDataRepoCRUD
    {
        public async void CreateChapter(Chapter chapter)
        {
            await _context.Chapters.AddAsync(chapter);
        }
    }
}
