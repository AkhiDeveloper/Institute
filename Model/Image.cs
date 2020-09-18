using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Image
    {
        [Key]
        [ForeignKey("FileDetail")]
        public int FileId { get; set; }

        [Required]
        public File FileDetail { get; set; }
    }
}
