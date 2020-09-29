using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class CoursePreTest
    {
        [Key]
        [ForeignKey("TestDetail")]
        public int TestId { get; set; }

        [Required]
        public int RefCourseId { get; set; }

        [Required]
        
        public int SN { get; set; }

        //Navigation Property
        public Test TestDetail { get; set; }

        public Course RefCourse { get; set; }
    }
}
