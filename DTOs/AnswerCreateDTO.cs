using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class AnswerCreateDTO
    {
        public int SN { get; set; }

        public string answertext { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsCorrect { get; set; }
    }
}
