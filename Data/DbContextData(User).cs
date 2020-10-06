using Institute.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Data
{
    public partial class DbContextData : IInstituteDataRepoCRUD
    {
        public async void CreateRole(IdentityRole role)
        {
            await _context.Roles.AddAsync(role);
        }

        public void CreateRoles(ICollection<IdentityRole> roles)
        {
            throw new NotImplementedException();
        }

        public async void CreateTutor(Tutor tutor)
        {
            await _context.Tutors.AddAsync(tutor);
        }

        public async Task<Tutor> GetTutor(string tutorid)
        {
            return await _context.Tutors.FirstOrDefaultAsync
                (x => x.Id == tutorid);
        }


    }
}
