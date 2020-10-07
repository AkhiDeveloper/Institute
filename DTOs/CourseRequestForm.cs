using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class CourseRequestForm
    {
        [Required]
        public string code { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
#nullable enable
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal? Fee { get; set; }

        [StringLength(150, MinimumLength = 10)]
        [DisplayFormat(NullDisplayText = "No Goals")]
        public string? Goals { get; set; }

        [DisplayFormat(NullDisplayText = "No Objectives")]
        [StringLength(200)]
        public string? Objectives { get; set; }

        [DisplayFormat(NullDisplayText = "Just You Requried")]
        [StringLength(200)]
        public string? Requriements { get; set; }
#nullable disable

        public decimal Tutorshare;
    }
}
