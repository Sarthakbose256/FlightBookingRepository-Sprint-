using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Entities
{
    public class AgentBooking
    {
        [Key]
        [StringLength(5)]
        public string BookingId {  get; set; }
        [ForeignKey("Agent")]
        public string AgentId {  get; set; }
        public string CustomerName {  get; set; }

        public string Email {  get; set; }  
        public string Mobile {  get; set; } 

        [ForeignKey("FlightDetails")]
        public string FlightNumber { get; set; }
        public string SeatNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public double TicketPrice { get; set; }
        public DateTime BookingDate { get; set; } 
        public double CommissionEarned { get; set; }
        public FlightDetail FlightDetails { get; set; }
        public Agent Agent { get; set; }    
    }
}