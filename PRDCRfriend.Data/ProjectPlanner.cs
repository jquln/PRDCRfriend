using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Data
{
    public enum Contents
    {
        [Display(Name ="Pre-Production")]
        PreProduction,
        Recording,
        Editing,
        Vocals,
        [Display(Name = "Mixing Mastering")]
        MixingMastering
    }
    public class ProjectPlanner
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public Guid OwnerId { get; set; }


        [Required]
        public string Content { get; set; }

        [Required]
        public int ProducerId { get; set; }
        public string Artist { get; set; }
        public string ArtistLastName { get; set; }
        public string ArtistFirstName { get; set; }
       
        public string ProjectTitle { get; set; }

        public DateTime Date { get; set; }

        public string FullName() => $"{ArtistLastName}  {ArtistFirstName}";

        public Contents PlannerContent { get; set; }

    }
}
