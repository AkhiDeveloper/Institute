using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class TestQA
    {
        [Key]
        public int QAId { get; set; }

        [Required]
        public int RefTestId { get; set; }

        [Required]
        public int SN { get; set; }

        //Navigation Property
        public QA QA { get; set; }

        public Test RefTest { get; set; }
    }
}
