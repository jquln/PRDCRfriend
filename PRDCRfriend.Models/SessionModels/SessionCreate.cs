using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.SessionModels
{
    public class SessionCreate
    {
        [Required]
        public int SessionId { get; set; }

        [Required]
        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name ="Created")]
        public DateTime Time { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string ArtistFirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string ArtistLastName { get; set; }

       
        



    }
}
