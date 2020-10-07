using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class LessonPostTest
    {
        [Key]
        [ForeignKey("TestDetail")]
        public int TestId { get; set; }

        [Required]
        public string RefLessonId { get; set; }

        [Required]
        public int SN { get; set; }

        //Navigation Property
        public Test TestDetail { get; set; }

        public Lesson RefLesson { get; set; }
    }
}
