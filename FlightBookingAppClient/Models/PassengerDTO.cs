using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class PassengerDTO
    {
        public string BookingId { get; set; }
        public string FlightNumber { get; set; }
        public string SeatNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime BookingDate { get; set; }

    }
}