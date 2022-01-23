using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.ArtistModels
{
    public class ArtistListItem
    {

        [Required]
        [Display(Name = "Artist No.")]
        public int Id { get; set; }

        [Display(Name = "Artist")]
        public string Name { get; set; }

        [Display(Name ="Project Title")]
        public string ProjectTitle { get; set; }

        
    }
}
