using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class TestQuestion
    {
        [Key]
        [ForeignKey("Question")]
        public string QuestionId { get; set; }

        [Required]
        public string RefTestId { get; set; }

        //Navigation Property
        public Question Question { get; set; }

        public Test RefTest { get; set; }
    }
}
