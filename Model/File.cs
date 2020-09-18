using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public enum FileType { Text,Image,Document,Video}
    public class File
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 1)]
        public string FileName { get; set; }

        [Required]
        public FileType Type { get; set; }

        [Required]
        public string Format { get; set; }

        [Required]
        [DataType(DataType.Url)]
        public string FileUrl { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Column(TypeName ="DateTime")]
        public DateTime UploadDateTime { get; set; }
    }
}
