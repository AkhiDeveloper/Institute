using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class QA
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100,MinimumLength = 3)]
        public string Question { get; set; }

        [StringLength(100,MinimumLength = 1)]
        public string CorrectAnswer { get; set; }

        //Navigation Property
        public ICollection<Answer> AnsweOptions { get; set; }
    }
}
