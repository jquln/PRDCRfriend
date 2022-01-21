using PRDCRfriend.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace PRDCRfriend.Models.PlannerModels
{
    public class PlannerCreate
    {
        [Required]
        public int PlannerId { get; set; }

        [Required]
        [Display(Name = "Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string Content { get; set; }
        public List<ProjectPlanner> ProjectPlanners { get; set; }

        [Required]
        public int ProducerId { get; set; }

        [Required]
        [Display(Name = "Artist Name")]
        public string Artist { get; set; }

    }
}
