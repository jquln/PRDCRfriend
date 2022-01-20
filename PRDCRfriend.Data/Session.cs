using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Data
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        public Guid OwnerId { get; set; }

        [Required]
        public string ProjectTitle { get; set; }

        //public string ArtistFirstName { get; set; }

        //public string ArtistLastName { get; set; }


        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime Time { get; set; }
        

        [Required] 
        public TimeSpan Duration { get; set; }



        [ForeignKey(nameof(Producer))]
        public int ProducerId { get; set; }
        public Producer Producer {  get; set; }

        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        

        public virtual List<Artist> Artists { get; set; }
        public virtual List<Session> Sessions { get; set; } = new List<Session>();

    }
}
