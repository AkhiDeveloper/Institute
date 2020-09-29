using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class TestCreateDTO
    {
        [Required]
        public string Title { get; set; }   
    }
}
