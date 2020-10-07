using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class RegisteredTutorCourse
    {
        [Required]
        public string TutorId { get; set; }

        [Required]
        [Key]
        public string CourseId { get; set; }

        [Required]
        [Column(TypeName ="decimal(4,2)")]
        public decimal TutorShare { get; set; }

        //Navigation Property
        public Tutor Tutor { get; set; }
        public Course Course { get; set; }
    }
}
