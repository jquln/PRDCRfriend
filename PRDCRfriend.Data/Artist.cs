using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Data
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        public string Session { get; set; }

        public Guid OwnerId { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string ProjectTitle { get; set; }

        [Required]
        
        public string Email { get; set; }

        [Required]
        
        public string PhoneNumber { get; set; }

        public virtual List<Session> Sessions { get; set; } = new List<Session>();

        //public virtual List<Equipment> Equipment { get; set; } = new List<Equipment>();

        public string FullName() => $"{LastName}  {FirstName}";
    }
}
