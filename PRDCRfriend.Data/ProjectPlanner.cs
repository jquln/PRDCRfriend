using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Data
{
    public class ProjectPlanner
    {
        [Key]
        public int PlannerId { get; set; }

        public string Content { get; set; }

        public string PreProduction { get; set; }

        public string Recording { get; set; }

        public string Editing { get; set; }

        public string Vocals { get; set; }

        public string MixingMastering { get; set; }

        public int ProducerId { get; set; }

        public int SessionId { get; set; }

        public string ProjectTitle { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

    }
}
