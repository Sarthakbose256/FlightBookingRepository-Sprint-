using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class Agent
    {
        [Key]
        [StringLength(4)]
        [DisplayName("Agent Id")]
        public string agentId { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "password required")]
        public string password { get; set; }

        [DisplayName("Agent Name")]
        [Required(ErrorMessage = "agent name required")]
        public string AgentName { get; set; }

        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "enter valid email")]
        public string Email { get; set; }

        [StringLength(10)]
        [DisplayName("Contact Number")]
        [Required(ErrorMessage = "mobile no required")]
        public string AgentPhone { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "city required")]
        public string City { get; set; }

        [DisplayName("Location")]
        [Required(ErrorMessage = "location required")]
        public string Location { get; set; }

        [DisplayName("Status")]
        public string status { get; set; }

        [DisplayName("Applied Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Updated Date")]
        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }
    }
}