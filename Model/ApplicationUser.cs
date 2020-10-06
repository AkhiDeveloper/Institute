using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(20,MinimumLength = 2)]
        [AllowNull]
        public string FName { get; set; }

        [StringLength(20,MinimumLength = 2)]
        [AllowNull]
        public string MName { get; set; }

        [StringLength(20,MinimumLength = 2)]
        [AllowNull]
        public string LName { get; set; }

#nullable enable
        public string? FullName
        {
            get
            {
                if (FName == null) return null;
                return (MName == null) ? $"{FName.PadRight(1)}+{LName}" : $"{FName.PadRight(1)}+{MName.PadRight(1)}+{LName}";
            }
#nullable disable
        }
    }
}
