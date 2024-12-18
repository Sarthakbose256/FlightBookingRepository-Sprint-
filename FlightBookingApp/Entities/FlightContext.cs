using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Entities
{
    public class FlightContext:DbContext
    {
        public FlightContext():base("FlightContext")
        {
            
        }
        public DbSet<User> users { get; set; }
        public DbSet<Admin> admins { get; set; }    
        public DbSet<Agent>agents { get; set; }
        public DbSet<AgentBooking> agentBookings { get; set; } 
        public DbSet<UserBooking>userBookings { get; set; }
        public DbSet<FlightDetail>flightDetails    { get; set; }
        public DbSet<FlightSchedule>flightSchedules { get; set; }

    }
}