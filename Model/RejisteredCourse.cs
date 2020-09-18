using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class RejisteredCourse
    {
        [Key]
        [ForeignKey("CourseDetail")]
        public int CourseId { get; set; }

        [Required]
        [Column(TypeName ="decimal(4,2)")]
        public decimal share { get; set; }

        //Navigation Property
        public Course CourseDetail { get; set; }
    }
}
