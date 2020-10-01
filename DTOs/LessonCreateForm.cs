using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class LessonCreateForm
    {
        [Required]
        [Range(1, 50)]
        [Index(IsUnique = true)]
        public int SN { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10)]
        public string Goal { get; set; }


        [DefaultValue("False")]
        public bool IsFree { get; set; }
    }
}
