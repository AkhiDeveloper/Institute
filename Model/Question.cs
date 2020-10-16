using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Question
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 3)]
        public string Statement { get; set; }

        [Required]
        public string Code { get; set; }

        //Navigation Property
        public ICollection<CorrectAnswer> CorrectAnswers { get; set; }
        public ICollection<WrongAnswer> WrongAnswers { get; set; }
    }
}
