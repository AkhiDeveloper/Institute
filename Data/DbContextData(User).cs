using Institute.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData 
    {
        public async Task<Tutor> GetTutor(int tutorid)
        {
            return await _context.Tutors.FirstOrDefaultAsync
                (x => x.Id == tutorid);
        }
    }
}
