using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class LessonMaterial
    {
        [Key]
        [ForeignKey("FileDetail")]
        public string FileId { get; set; }

        [Required]
        public int SN { get; set; }

        public string RefLessonId { get; set; }

        //Navigation Property
        public File FileDetail { get; set; }

        public Lesson RefLesson { get; set; }
    }
}
