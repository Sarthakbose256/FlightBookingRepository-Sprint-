using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class Login
    {
        [Required(ErrorMessage = "email required")]
        [EmailAddress(ErrorMessage = "enter valid email")]
        public string Email { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "password required")]
        // [RegularExpression("^[A-Za-z\\d@]{6}$")]
        public string password { get; set; }
    }
}