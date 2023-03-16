using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartReservation.Model
{
    public class Roles
    {
        [Required]
        public int RoleID { get; set; }

        [Required]
        public string Role { get; set; }

        public string Detail { get; set; }
    }
}
