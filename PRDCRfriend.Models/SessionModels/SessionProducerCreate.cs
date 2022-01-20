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
        [Display(Name = "Date/Time")]
        public DateTime Time { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Display(Name = "Artists")]
        public virtual List<string> Artists { get; set; }

        [Required]
        [Display(Name = "Artist: Last Name")]
        public string ArtistLastName { get; set; }

        [Required]
        [Display(Name = "Artist: First Name")]
        public string ArtistFirstName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string ArtistPhoneNumber { get; set; }

        public int ProducerId { get; set; }

        public int ArtistId { get; set; }


    }
}
