using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class AssignmentCreateForm
    {
        [Required]
        public int SN { get; set; }


        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Statement { get; set; }

    }
}
