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
        [Required]
        [Display(Name ="Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        public DateTime CreatedUtc { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public string PlannerId { get; set; }

        [Required]
        public string PlannerContent { get; set; }

        [Required]
        public int ProducerId { get; set; }

        [Required]
        public string ArtistLastName { get; set; }

        [Required]
        public string ArtistFirstName { get; set; }

        [Required]
        public string ArtistPhoneNumber { get; set; }


    }
}
