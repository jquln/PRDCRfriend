using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.SessionModels
{
    public class SessionDetail
    {
        public int SessionId { get; set; }

        public string ProjectTitle { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Duration { get; set; }

        public int ProducerId { get; set; }

        public int ArtistId { get; set; }

        public string Artist { get; set; }
        public string Producer { get; set; }

    }
}
