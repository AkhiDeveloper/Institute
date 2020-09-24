using Institute.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class CourseReadDTO
    {
        public string Title { get; set; }

#nullable enable
        public decimal? Fee { get; set; }
        public string? Goals { get; set; }
        public string? Objectives { get; set; }
        public string? Requriements { get; set; }
#nullable disable

        public decimal TutorShare { get; set; }

    }
}
