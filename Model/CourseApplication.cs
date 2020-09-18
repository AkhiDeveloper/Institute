using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class CourseApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int ApplicantId { get; set; }

        //Navigation Property
        public Course Course { get; set; }
        public Student Aplicant { get; set; }

    }
}
