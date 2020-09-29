using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class TestQACreateDTO
    {
        [Required]
        public int SN { get; set; }

        //Navigation Property
        public QACreateDTO QA { get; set; }
    }
}
