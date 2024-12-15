using System;
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
        public string FlightType { get; set; }
        public double PriceEconomy { get; set; }
        public double PriceBusiness { get; set; }
        public double PriceFirst { get; set; }
        public int TotalSeats { get; set; }
    }
}