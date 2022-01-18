using DocumentFormat.OpenXml.Bibliography;
using PRDCRfriend.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models
{
    public class ProducerDetail
    {
        public int OwnerId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        //public virtual List<Equipment> Equipment { get; set; } = new List<Equipment>();

        
        public string PlannerId { get; set; }

        public virtual List<string> Artists { get; set; }

        public List<SessionListItem> Sessions { get; set; }

    }
}
