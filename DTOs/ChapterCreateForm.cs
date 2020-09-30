using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class ChapterCreateForm
    {
        [Required]
        [Range(1, 50)]
        public int SN { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(150, MinimumLength = 10)]
        [DefaultValue("You had not mentioned any goals.")]
        public string Goal { get; set; } 

        [StringLength(200)]
        [DefaultValue("You had not mentioned any objectives.")]
        public string Objectives { get; set; }
    }
}
