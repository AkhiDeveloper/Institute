using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class TaskMaterial
    {
        [Key]
        [ForeignKey("FileDetail")]
        public int FileId { get; set; }

        [Required]
        public int SN { get; set; }

        public int? RefTaskId { get; set; }

        //Navigation Property
        public File FileDetail { get; set; }

        public Lesson RefTask { get; set; }
    }
}
