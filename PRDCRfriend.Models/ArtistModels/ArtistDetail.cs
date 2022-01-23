using PRDCRfriend.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.ArtistModels
{
    public class ArtistDetail
    {
        public int Id { get; set; }
        
        public string LastName { get; set; }

        public string FirstName { get; set; }

        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public List<SessionListItem> Sessions { get; set; }

    }
}
