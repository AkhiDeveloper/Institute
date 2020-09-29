using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200,MinimumLength =5)]
        public string Statement { get; set; }

        //Navigation Property
        public IEnumerable<TaskMaterial> Files{get;set;}
    }
}
