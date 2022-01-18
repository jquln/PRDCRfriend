using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.SessionModels
{
    public class SessionProducerCreate
    {
        [Key]
        public int SessionId { get; set; }

        [Required]
        [Display(Name ="Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }


        [Required]
        public int ProducerId { get; set; }

        public int ArtistId { get; set; }

        [Required]
        public string ArtistLastName { get; set; }

        [Required]
        public string ArtistFirstName { get; set; }

        [Required]
        public string ArtistPhoneNumber { get; set; }


    }
}
