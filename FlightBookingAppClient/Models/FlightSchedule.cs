using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
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
        [DisplayName("Flight Number")]
        [Required(ErrorMessage ="Flight number is required")]
        public string FlightNumber { get; set; }
        [DataType(DataType.Time)]
        [DisplayName("Departure Time")]
        [Required(ErrorMessage = "Departure time is required")]
        public DateTime DepartureTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("Arrival Time")]
        [Required(ErrorMessage = "arrival time is required")]
        public DateTime ArrivalTime { get; set; }

        [DataType(DataType.Duration)]
        [DisplayName("Duration")]
        public TimeSpan Duration { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Flight Date")]
        [Required(ErrorMessage = "flight date is required")]
        public DateTime FlightDate { get; set; }

        [DisplayName("Departure")]
        [Required(ErrorMessage = "departure location is required")]
        public string DepartureLoc { get; set; }

        [DisplayName("Arrival")]
        [Required(ErrorMessage = "arrival location is required")]
        public string ArrivalLocation { get; set; }
        public FlightDetail FlightDetails { get; set; }

    }
}