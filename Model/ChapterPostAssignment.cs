﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class ChapterPostAssignment
    {
        [Key]
        [ForeignKey("TaskDetail")]
        public int TaskId { get; set; }

        [Required]
        public string RefChapterId { get; set; }

        [Required]
        public int SN { get; set; }

        //Navigation Property
        public Assignment AssignmentDetail { get; set; }

        public Chapter RefChapter { get; set; }
    }
}
