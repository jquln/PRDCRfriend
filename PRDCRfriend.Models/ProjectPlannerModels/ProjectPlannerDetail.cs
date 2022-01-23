using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PRDCRfriend.Models.PlannerModels
{
    public class PlannerDetail
    {

        public string ProjectTitle { get; set; }

        public string Artist { get; set; }

        public DateTime Date { get; set; }

        

        public int ProducerId { get; set; }

        public string Content { get; set; }

        public List<Content> ContentList { get; set; }
       

        public string PreProduction { get; set; }

        public string Recording { get; set; }

        public string Editing { get; set; }

        public string Vocals { get; set; }

        public string MixingMastering { get; set; }

    }
}
