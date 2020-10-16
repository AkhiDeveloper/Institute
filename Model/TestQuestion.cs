using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class TestQuestion
    {
        [Key]
        public int QuestionId { get; set; }

        [Required]
        public int RefTestId { get; set; }

        //Navigation Property
        public Question Question { get; set; }

        public Test RefTest { get; set; }
    }
}
