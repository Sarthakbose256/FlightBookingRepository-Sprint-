using FlightBookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private FlightContext context;
        private Random random;
        public AdminRepository()
        {
            context = new FlightContext();
            random = new Random();
        }
        public void AgentApproval(AuthenticateAgent authenticateAgent)
        {
            Agent agent= new Agent();
            authenticateAgent.ApprovalStatus = "APPROVED";
            agent.agentId="A"+random.Next(500);
            agent.AgentName= authenticateAgent.ApplicantName;
            agent.AgentPhone= authenticateAgent.ApplicantPhone;
            agent.Email= authenticateAgent.ApplicantEmail;
            agent.City= authenticateAgent.ApplicantCity;
            agent.Location= authenticateAgent.ApplicantLocation;
            agent.password = authenticateAgent.password;
            agent.CommissionRate= authenticateAgent.CommissionRate;
            agent.CreatedAt = DateTime.Now;
            context.agents.Add(agent);
            context.SaveChanges();
        }
        public void AgentReject(int id)
        {
            var reject = context.authenticateAgents.Find(id);
            reject.ApprovalStatus = "REJECTED";
            context.SaveChanges();
            
        }

        public void CancelScheduleFlight(string id)
        {
            var cancel = context.flightSchedules.Find(id);
            context.flightSchedules.Remove(cancel);
        }

        public List<FlightSchedule> GetAllFlightSchedule()
        {
            var list = context.flightSchedules.ToList();
            return list;
        }

        public List<UserBooking> GetAllPassengers(string flightnumber)
        {
            var list = context.userBookings.Where(m=>m.FlightNumber==flightnumber).ToList();
            return list;
        }

        public void UpdateScheduleFlight(FlightSchedule flightSchedule)
        {
            var flight = context.flightSchedules.SingleOrDefault(m=>m.ScheduleId==flightSchedule.ScheduleId);
            flight.DepartureTime = flightSchedule.DepartureTime;
            flight.ArrivalTime = flightSchedule.ArrivalTime;
            flight.DepartureLoc = flightSchedule.DepartureLoc;
            flight.ArrivalLocation= flightSchedule.ArrivalLocation;
            flight.Duration= flightSchedule.Duration;
            context.SaveChanges();
        }
    }
}