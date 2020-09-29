using Institute.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class SqlInstituteData 
    {
        public async Task<Tutor> GetTutorById(int id)
        {
            return await _context.Tutors.FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
