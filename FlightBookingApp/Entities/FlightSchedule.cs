﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Entities
{
    public class FlightSchedule
    {
        [Key]
        [StringLength(5)]
        public string ScheduleId {  get; set; }

        [ForeignKey("FlightDetails")]
        public string FlightNumber {  get; set; }
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }  

        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }

        [DataType(DataType.Date)]
        public DateTime FlightDate { get; set; }
        public string DepartureLoc {  get; set; }
        public string ArrivalLocation {  get; set; }
        public FlightDetail FlightDetails { get; set; }

    }
}