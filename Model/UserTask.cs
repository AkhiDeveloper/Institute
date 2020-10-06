using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class UserTask
    {
        [Key]
        public string PerformerId { get; set; }

        [Key]
        public int GivenTaskId { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Submitted { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Checked { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [DefaultValue("No Comment")]
        [StringLength(200, MinimumLength =3)]
        public string Comments { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Passed { get; set; }

        public string CheckerId { get; set; }

        //Navigation Property
        public Assignment GivenTask { get; set; }
        public ApplicationUser Performer { get; set; }
        public ApplicationUser Checker { get; set; }
    }

}
