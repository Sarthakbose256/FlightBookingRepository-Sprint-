﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FlightBookingAppClient.Models
{
    public class Agent
    {
        [Key]
        [StringLength(4)]
        public string agentId { get; set; }

        [StringLength(10)]
        public string password { get; set; }
        public string AgentName { get; set; }
        public string Email { get; set; }

        [StringLength(10)]
        public string AgentPhone { get; set; }
        public string City { get; set; }
        public string Location { get; set; }
        public double CommissionRate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}