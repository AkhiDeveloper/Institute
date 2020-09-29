using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class SqlInstituteData 
    {
        private readonly InstituteContext _context;

        public SqlInstituteData(InstituteContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        { 

            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
