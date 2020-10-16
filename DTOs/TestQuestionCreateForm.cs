using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class TestQuestionCreateForm
    {
        [Required]
        public string Statement { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
