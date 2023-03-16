using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartReservation.Models
{
    public class MessageModel
    {
        [Required] public string Title { get; set; }

        [Required] public string Message { get; set; }

        public string Icon { get; set; }

        [Required] public string Controller { get; set; }

        [Required] public string Route { get; set; }

        public string ButttonText { get; set; } = "Continue";

        public string Type { get; set; }

        public string Url { get; set; }
    }
}
