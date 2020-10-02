using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class CoursePostAssignment
    {
        [Key]
        [ForeignKey("AssignmentDetail")]
        public int AssignmentId { get; set; }

        [Required]
        public int RefCourseId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public int SN { get; set; }


        //public int TaskDetailId { get; set; } 

        public Assignment AssignmentDetail { get; set; }

        public Course RefCourse { get; set; }
    }
}
