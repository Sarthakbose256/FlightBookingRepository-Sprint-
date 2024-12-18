using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Models
{
    public class FlightScheduleDTO
    {
        public string ScheduleId { get; set; }
        public string FlightNumber { get; set; }
        public string Airline { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime FlightDate { get; set; }
        public string DepartureLoc { get; set; }
        public string ArrivalLocation { get; set; }
    }
}