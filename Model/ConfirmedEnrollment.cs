using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class ConfirmedEnrollment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public int StudentId { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Completed { get; set; }

        //Navigation Property
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
