using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class CorrectAnswer
    {
        [Required]
        [Key]
        [ForeignKey("Answer")]
        public string AnswerId { get; set; }

        [Required]
        [ForeignKey("RefQsn")]
        public string RefQsnId { get; set; }

        //Navigation Property
        public Question RefQsn { get; set; }

        public Answer Answer { get; set; }
    }
}
