using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.SessionModels
{
    public class SessionEdit
    {
        public int SessionId { get; set; }

        public string ProjectTitle { get; set; }

        public DateTime Time { get; set; }

        [Required]
        //Request style "00:00:00" 
        public TimeSpan Duration { get; set; }

        public int ArtistId { get; set; }

    }
}
