using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Data
{
    public class ProjectPlanner
    {
        [Key]
        public int PlannerId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public string ArtistFirstName { get; set; }
        public string ArtistLastName { get; set; }
       public string Artist { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int ProducerId { get; set; }

      

        public string ProjectTitle { get; set; }

        public DateTime Date { get; set; }

        public string FullName() => $"{ArtistLastName}  {ArtistFirstName}";


    }
}
