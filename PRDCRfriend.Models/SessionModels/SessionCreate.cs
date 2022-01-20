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
    public class SessionCreate
    {

        [Required]
        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }


        [Required]
        public TimeSpan Duration { get; set; }

        //[Required]
        //[Display(Name = "First Name")]
        //public string ArtistFirstName { get; set; }
        //[Required]
        //[Display(Name = "Last Name")]
        //public string ArtistLastName { get; set; }

        [Required]
        public int ProducerId { get; set; }

        [Required]
        public int ArtistId { get; set; }

        [Required]
        [Display(Name = "Artists")]
        public virtual List<Artist> Artists { get; set; } = new List<Artist>();





    }
}
