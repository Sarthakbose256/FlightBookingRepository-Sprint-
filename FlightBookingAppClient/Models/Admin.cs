using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class Admin
    {

        [Key]
        [StringLength(5)]
        public string AdminId { get; set; }
        public string AdminName { get; set; }
        public string AdminPwd { get; set; }
        public string AdminEmail { get; set; }

    }
}