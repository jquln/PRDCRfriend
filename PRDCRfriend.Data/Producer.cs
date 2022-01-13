using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Data
{
    public class Producer
    {
        [Key]
        public int ProducerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }



        //public virtual List<Equipment> Equipment { get; set; } = new List<Equipment>();


    }
}
