using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Chapter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Id { get; set; }

        public string CourseId { get; set; }

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

        [ForeignKey("IntroVideo")]
        public string IntroVideoId { get; set; }



        //Navigation Property
        public Video IntroVideo { get; set; }
        //public ICollection<Lesson> Lessons { get; set; }
        public Course Course { get; set; }
        //public ICollection<ChapterPreTest> ChapterPreTests { get; set; }
        //public ICollection<ChapterPostTest> ChapterPostTests { get; set; }
        //public ICollection<ChapterPreAssignment> ChapterPreAssignments { get; set; }
        //public ICollection<ChapterPostAssignment> ChapterPostTasks { get; set; }
    }
}
