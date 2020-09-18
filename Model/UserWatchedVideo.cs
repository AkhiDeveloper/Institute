using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Institute.Model
{
    public class UserWatchedVideo
    {
        [Key]
        [Required]
        public int UserWatchedId { get; set; }

        [Key]
        [Required]
        public int WatchedVideoId { get; set; }

        [Required]
        [DataType(DataType.Duration)]
        [DefaultValue(0)]
        public TimeSpan WatchedDuration { get; set; }

        [Required]
        [DefaultValue(0)]
        public int NumofTimeCompletlyWatched { get; set; }

        //Navigation Property
        public ApplicationUser UserWatched { get; set; }
        public Video WatchedVideo { get; set; }

    }
}
