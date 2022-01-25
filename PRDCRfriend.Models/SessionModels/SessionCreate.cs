using PRDCRfriend.Data;
using PRDCRfriend.Models.ArtistModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PRDCRfriend.Models.SessionModels
{
    public class SessionCreate
    {
        [Required]
        public int Id { get; set; }

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

        public int ProducerId { get; set; }
      
        public int ArtistId { get; set; }

       
        [Display(Name = "Artist Name")]
        public string Name { get; set; }
       





    }
}
