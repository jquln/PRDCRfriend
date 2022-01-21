using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.SessionModels
{
    public class SessionListItem
    {
        [Required]
        [Display(Name = "Recording Session")]
        public int SessionId { get; set; }

        [Required]
        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name = "Date")]
        public string Date { get; set; }


        [Required]
        [Display(Name = "Time")]
        public string Time { get; set; }

        public string Producer { get; set; }
        [Required]
        public string Artist { get; set; }

    }
}
