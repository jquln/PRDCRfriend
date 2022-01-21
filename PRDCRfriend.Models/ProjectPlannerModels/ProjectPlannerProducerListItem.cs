using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.PlannerModels
{
    public class PlannerProducerListItem
    {
        public int PlannerId { get; set; }

        public int ProducerId { get; set; }

        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name = "Date")]
        public string Date { get; set; }

        public string ArtistName { get; set; }

        public Content PlannerContent { get; set; }

    }

    public enum Content
    {
        PreProduction,
        Recording,
        Editing,
        Vocals,
        MixingMastering
    }
}
