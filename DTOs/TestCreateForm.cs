using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class TestCreateForm
    {
        [Required]
        public string Title { get; set; } 
        
        [Required]
        public int SN { get; set; }
    }
}
