using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models
{
    public class ProducerDetail
    {
        public int ProducerId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        //public virtual List<Equipment> Equipment { get; set; } = new List<Equipment>();
        
        public virtual List<Artist> Artists { get; set; }

    }
}
