using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class User
    {
        [Key]
        [StringLength(4)]
        public string UserId { get; set; }

        [StringLength(10)]
        public string password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        [StringLength(10)]
        public string UserPhone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}