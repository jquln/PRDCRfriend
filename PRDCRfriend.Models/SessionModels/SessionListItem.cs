using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRDCRfriend.Models.SessionModels
{
    public class SessionListItem
    {
        public int SessionId { get; set; }

        public string ProjectTitle { get; set; }

        
        public string Time { get; set; }

        public string Producer { get; set; }

        public string Artist { get; set; }

    }
}
