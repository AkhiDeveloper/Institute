using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Tutor
    {
        [Key]
        [ForeignKey("UserDetail")]
        public string Id { get; set; }

        public ApplicationUser UserDetail { get; set; }
    }
}
