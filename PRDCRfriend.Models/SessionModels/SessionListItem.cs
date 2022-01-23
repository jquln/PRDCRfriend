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
        
        [Display(Name = "Recording Session")]
        public int Id { get; set; }

        
        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        
        [Display(Name = "Date")]
        public string Date { get; set; }


        
        [Display(Name = "Time")]
        public string Time { get; set; }

        public string Producer { get; set; }
        
        public string Artist { get; set; }

    }
}
