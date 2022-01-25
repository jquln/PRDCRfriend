using PRDCRfriend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.ProjectPlannerModels
{
    public class ProjectPlannerEdit
    {
        public int Id { get; set; }

        public string ProjectTitle { get; set; }

        public int ProducerId { get; set; }

        public DateTime Date { get; set; }

        public Contents Content { get; set; }

        public string Artist { get; set; }


    }
}
