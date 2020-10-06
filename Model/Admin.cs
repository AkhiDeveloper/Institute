using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Admin
    {
        [Key]
        [ForeignKey("UserDetail")]
        public string Id { get; set; }

        //Navigation Property
        public ApplicationUser UserDetail { get; set; }
    }
}
