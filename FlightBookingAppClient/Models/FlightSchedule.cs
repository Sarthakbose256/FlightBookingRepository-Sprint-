using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class FlightSchedule
    {
        [Key]
        [StringLength(5)]
        public string ScheduleId { get; set; }

        [ForeignKey("FlightDetails")]
        public string FlightNumber { get; set; }
        [DataType(DataType.Time)]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime ArrivalTime { get; set; }

        [DataType(DataType.Duration)]
        public DateTime Duration { get; set; }
        public string DepartureLoc { get; set; }
        public string ArrivalLocation { get; set; }
        public FlightDetail FlightDetails { get; set; }

    }
}