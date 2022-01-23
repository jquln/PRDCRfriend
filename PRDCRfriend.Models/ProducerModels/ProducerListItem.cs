using PRDCRfriend.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models
{
    public class ProducerListItem
    {
        [Required]
        public int Id { get; set; }
       
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name ="Project Planner")]
        public int PlannerId { get; set; }

        [Required]
        [Display(Name = "Artists")]
        public virtual List<string> Artists { get; set; }

        public List<SessionListItem> Sessions { get; set; }
    }
}
