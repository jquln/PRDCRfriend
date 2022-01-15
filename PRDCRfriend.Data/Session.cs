﻿using System;
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

        [Required]
        public string ProjectTitle { get; set; }

        [Required]
        public DateTime CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [Required]
        //Request style "00:00:00" 
        public TimeSpan Duration { get; set; }



        [ForeignKey(nameof(Producer))]
        public int ProducerId { get; set; }

        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        public virtual List<Artist> Artists { get; set; }

    }
}