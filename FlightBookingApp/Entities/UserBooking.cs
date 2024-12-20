﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Entities
{
    public class UserBooking
    {
        [Key]
        [StringLength(5)]
        public string BookingId {  get; set; }
        [ForeignKey("User")]
        public string UserId {  get; set; }

        [ForeignKey("FlightDetails")]
        public string FlightNumber {  get; set; }
        public double TicketPrice {  get; set; }  
        public DateTime BookingDate { get; set; }   
        public string SeatNumber {  get; set; }
        public DateTime FlightDate { get; set; }    
        public User User { get; set; }
        public FlightDetail FlightDetails { get; set; }    


    }
}