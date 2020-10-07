using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class RequestedTutorCourse
    {
        [Required]
        [Key]
        [ForeignKey("CourseDetail")]
        public string CourseId { get; set; }

        [Required]
        public string TutorId { get; set; }

        [Required]
        [Column(TypeName ="decimal(4,2)")]
        public decimal TutorShare { get; set; }

        [DefaultValue(0)]
        public int NumberofReviews { get; set; }

        [DefaultValue("No Comment yet")]
        public string AdminComments { get; set; }

        //Navigation Property
        public Tutor Tutor { get; set; }
        public Course CourseDetail { get; set; }
    }
}
