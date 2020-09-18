using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RefQsnId { get; set; }

        [Required]
        public int SN { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool IsCorrect { get; set; }

        //Navigation Property
        public QA RefQsn { get; set; }
    }
}
