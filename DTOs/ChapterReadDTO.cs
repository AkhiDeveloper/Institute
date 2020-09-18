using Institute.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class ChapterReadDTO
    {
        public int CourseId { get; set; }
        public int SN { get; set; }

        public string Title { get; set; }

        [DefaultValue("You had not mentioned any goals.")]
        public string Goal { get; set; }

        [DefaultValue("You had not mentioned any objectives.")]
        public string Objectives { get; set; }
    }
}
