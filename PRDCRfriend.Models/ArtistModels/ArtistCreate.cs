using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.ArtistModels
{
    public class ArtistCreate
    {
        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string ProjectTitle { get; set; }

        [Required]
        
        public string Email { get; set; }

        [Required]
        
        public string PhoneNumber { get; set; }
    }
}
