using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace FlightBookingAppClient.Models
{
    public class UserBooking
    {

        [Key]
        [StringLength(5)]
        [DisplayName("Booking Id")]
        public string BookingId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }

        [ForeignKey("FlightDetails")]
        [DisplayName("Flight Number")]
        public string FlightNumber { get; set; }

        [DisplayName("Ticket Price")]
        public double TicketPrice { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Booking Date")]
        public DateTime BookingDate { get; set; }

        [DisplayName("Seat Number")]
        public string SeatNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Flight Date")]
        public DateTime FlightDate { get; set; }
        public User User { get; set; }
        public FlightDetail FlightDetails { get; set; }
    }
}