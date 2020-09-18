using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class RequestedCourse
    {
        [Key]
        [ForeignKey("CourseDetail")]
        public int CourseId { get; set; }

        [StringLength(200,MinimumLength = 3)]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal RequestedShare { get; set; }

        [DefaultValue(false)]
        public bool IsRejected { get; set; }

        [DefaultValue(0)]
        public int NumofEdites { get; set; }

        //Navigation Property
        public Course CourseDetail { get; set; }

    }
}
