using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }

        public int ChapterId { get; set; }

        [Required]
        [Range(1, 50)]
        public int SN { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10)]
        public string Goal { get; set; }

        public int TeachingVideoId { get; set; }

        
        [DefaultValue("False")]
        public bool IsFree { get; set; }

        //Navigation Property
        public Chapter Chapter { get; set; }
        public Video TeachingVideo { get; set; }
        public ICollection<LessonMaterial> LessonMaterials { get; set; }

        public ICollection<LessonTest> Tests { get; set; }

        public ICollection<LessonAssignment> Tasks { get; set; }

        //public ICollection<LessonTopic> LessonTopics { get; set; }
    }
}
