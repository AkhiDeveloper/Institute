using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class UserGivenTest
    {
        [Key]
        public int PerformerId { get; set; }

        [Key]
        public int ConductedTestId { get; set; }

        [Required]
        [DefaultValue(0)]
        public int FacedQsns { get; set; }

        [Required]
        [DefaultValue(0)]
        public int CorrectlyAnswered { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Completed { get; set; }

        //Navigation Property
        public ApplicationUser Performer { get; set; }
        public Test ConductedTest { get; set; }
    }
}
