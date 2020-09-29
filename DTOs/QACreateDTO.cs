using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class QACreateDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Question { get; set; }

        [StringLength(100, MinimumLength = 1)]
        public string CorrectAnswer { get; set; }

        //Navigation Property
        public ICollection<AnswerCreateDTO> AnsweOptions { get; set; }
    }
}
