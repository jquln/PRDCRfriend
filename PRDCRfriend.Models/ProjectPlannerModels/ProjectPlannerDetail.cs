using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.PlannerModels
{
    public class PlannerDetail
    {
        public int PlannerId { get; set; }

        public string ProjectTitle { get; set; }

        public string ArtistName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int ProducerId { get; set; }

        public string PreProduction { get; set; }

        public string Recording { get; set; }

        public string Editing { get; set; }

        public string Vocals { get; set; }

        public string MixingMastering { get; set; }

    }
}
