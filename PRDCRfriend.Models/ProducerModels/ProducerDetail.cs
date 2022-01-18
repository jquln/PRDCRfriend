using DocumentFormat.OpenXml.Bibliography;
using PRDCRfriend.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models
{
    public class ProducerDetail
    {
        public int ProducerId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //public virtual List<Equipment> Equipment { get; set; } = new List<Equipment>();

        [Required]
        [Display(Name = "Project Planner")]
        public string PlannerId { get; set; }
        

        [Required]
        [Display(Name = "Artists")]
        public virtual List<string> Artists { get; set; }

        public List<SessionListItem> Sessions { get; set; }

    }
}
