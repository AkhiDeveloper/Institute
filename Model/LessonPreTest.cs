using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class LessonPreTest
    {
        [Key]
        [ForeignKey("TestDetail")]
        public string TestId { get; set; }

        [ForeignKey("RefLesson")]
        [Required]
        public string RefLessonId { get; set; }

        [Required]
        public int SN { get; set; }

        //Navigation Property
        public Test TestDetail { get; set; }

        public Lesson RefLesson { get; set; }
    }
}
