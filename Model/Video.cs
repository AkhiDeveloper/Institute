using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class Video
    {
        [Key]
        [ForeignKey("FileDetail")]
        public string FileId { get; set; }

        public File FileDetail { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Duration)]
        public DateTime VideoDuration { get; set; }
    }
}
