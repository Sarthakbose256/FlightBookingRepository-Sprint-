using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class AgentBooking
    {
        [Key]
        [StringLength(5)]
        public string BookingId { get; set; }
        [ForeignKey("Agent")]
        public string AgentId { get; set; }
        public string UserName { get; set; }

        [ForeignKey("FlightDetails")]
        public string FlightNumber { get; set; }
        public string SeatNumber { get; set; }
        public double TicketPrice { get; set; }
        public DateTime BookingDate { get; set; }
        public double CommissionEarned { get; set; }
        public string Bookingstatus { get; set; }
        public FlightDetail FlightDetails { get; set; }
        public Agent Agent { get; set; }
    }
}