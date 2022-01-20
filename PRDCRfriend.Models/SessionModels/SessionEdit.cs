using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.SessionModels
{
    public class SessionEdit
    {
        public int SessionId { get; set; }

        public int OwnerId { get; set; }

        public string ProjectTitle { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Time { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public int ArtistId { get; set; }

        

    }
}
