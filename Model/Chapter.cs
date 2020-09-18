using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Chapter
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }

        
        [Required]
        [Range(1,50)]
        public int SN { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 10)]
        [DefaultValue("You had not mentioned any goals.")]
        public string Goal { get; set; }

        [DisplayFormat(NullDisplayText = "No Objectives")]
        [StringLength(200)]
        [DefaultValue("You had not mentioned any objectives.")]
        public string Objectives { get; set; }

        public int IntroVideoId { get; set; }

        //Navigation Property
        public ICollection<Lesson> Lessons { get; set; }

        public Course Course { get; set; }

        public ICollection<ChapterTest> ChapterTests { get; set; }

        public ICollection<ChapterTask> ChapterTasks { get; set; }
    }
}
