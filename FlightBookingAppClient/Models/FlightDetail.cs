﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class FlightDetail
    {
        [Key]
        [StringLength(10)]
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public string FlightType { get; set;}
        public double TicketPrice { get; set; }
        public double Discount { get; set; }
    }
}