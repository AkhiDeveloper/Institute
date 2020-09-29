using Institute.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.DTOs
{
    public class VideoCreateDTO
    {
        [Required]
        public FileCreateDTO FileDetail { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        public DateTime VideoDuration { get; set; }
    }
}
