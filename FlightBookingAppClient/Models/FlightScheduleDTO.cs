using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class FlightScheduleDTO
    {
        public string ScheduleId { get; set; }

        [DisplayName("Flight Number")]
        public string FlightNumber { get; set; }

        [DisplayName("Airline")]
        public string Airline { get; set; }

        [DisplayName("Departure Time")]
        public DateTime DepartureTime { get; set; }

        [DisplayName("Arrival Time")]
        public DateTime ArrivalTime { get; set; }

        [DisplayName("Duration")]
        public TimeSpan Duration { get; set; }

        [DisplayName("Flight Date")]
        public DateTime FlightDate { get; set; }

        [DisplayName("Departure")]
        public string DepartureLoc { get; set; }

        [DisplayName("Departure Location")]
        public string ArrivalLocation { get; set; }
    }
}