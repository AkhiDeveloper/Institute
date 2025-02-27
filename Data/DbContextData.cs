﻿using Institute.Model;
using Institute.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData
        
    {
        private readonly InstituteContext _context;

        public DbContextData(InstituteContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync() >= 0);
            
        }
    }
}
