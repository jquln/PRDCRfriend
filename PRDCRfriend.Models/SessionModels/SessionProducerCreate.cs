using PRDCRfriend.Data;
using PRDCRfriend.Models.ArtistModels;
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
        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        //[Required]
        //[Display(Name = "Artists")]
        //public Artist SelectedArtist { get; set; } 
        //public IEnumerable<ArtistListItem> Artists { get; set; }
           

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

        

    }
}
