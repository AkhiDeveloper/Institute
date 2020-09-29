using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class ChapterAssignment
    {
        [Key]
        [ForeignKey("TaskDetail")]
        public int TaskId { get; set; }

        [Required]
        public int RefChapterId { get; set; }

        [Required]
        public int SN { get; set; }

        //Navigation Property
        public Assignment TaskDetail { get; set; }

        public Chapter RefChapter { get; set; }
    }
}
