using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class CoursePostTest
    {
        [Key]
        [ForeignKey("TestDetail")]
        public string TestId { get; set; }

        [Required]
        [ForeignKey("RefCourse")]
        public string RefCourseId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int SN { get; set; }

        //Navigation Property
        public Test TestDetail { get; set; }

        public Course RefCourse { get; set; }
    }
}
