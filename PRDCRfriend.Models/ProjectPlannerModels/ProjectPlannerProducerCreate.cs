using PRDCRfriend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.PlannerModels
{
    public class PlannerProducerCreate
    {
        [Required]
        public int PlannerId { get; set; }

        [Required]
        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [Display(Name ="Content and Notes")]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public virtual List<ProjectPlanner> ProjectPlanners { get; set; }


        [Required]
        public int ProducerId { get; set; }

        [Required]
        public string Artist { get; set; }

       

    }
}
