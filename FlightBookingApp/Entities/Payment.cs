using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Entities
{
    public class Payment
    {
        [Key]
        [StringLength(5)]
        public string PaymentId {  get; set; }
        [ForeignKey("Bookings")]
        public string BookingId {  get; set; }
        public double PaymentAmount {  get; set; }
        public DateTime PaymentDate { get; set; }   
        public string PaymentMethod { get; set; }
        public UserBooking Bookings { get; set; }  
    }
}