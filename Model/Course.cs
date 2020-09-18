using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName ="money")]
        [DefaultValue(0)]       
        public decimal Fee { get; set; }

        [Required]
        [StringLength(150,MinimumLength =5)]
        [DefaultValue("No Goals")]
        public string Goals { get; set; }

        [Required]
        [StringLength(200,MinimumLength = 5)]
        public string Objectives { get; set; }

        [Required]
        [StringLength(200,MinimumLength = 5)]
        public string Requriements { get; set; }

        public int? IntroVideoId { get; set; }

        public Video IntroVideo { get; set; }

        public ICollection<Chapter> Chapters { get; set; }

        public ICollection<CourseTest> Tests { get; set; }

        public ICollection<CourseTask> Tasks { get; set; }
    }
}
