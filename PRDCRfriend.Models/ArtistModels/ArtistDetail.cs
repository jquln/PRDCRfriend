using PRDCRfriend.Models.SessionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.ArtistModels
{
    public class ArtistDetail
    {
        public int ArtistId { get; set; }
        
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string ProjectTitle { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public List<SessionListItem> Sessions { get; set; }

    }
}
