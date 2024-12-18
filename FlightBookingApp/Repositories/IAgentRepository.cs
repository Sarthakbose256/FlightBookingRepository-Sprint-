using FlightBookingApp.Entities;
using FlightBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Repositories
{
    internal interface IAgentRepository
    {
        void BookTicket(AgentBooking agentBooking); // Method for travel agent to book tickets for others
        double CalculateCommission(string agentId, DateTime startDate, DateTime endDate); // Method to calculate commission earned over a period
        List<AgentBooking> GetBookingHistory(string agentId); // Method to view booking history over a period
        void CancelBooking(string bookingId); // Method to cancel a booking
        void UpdateBooking(AgentBooking agentBooking); // Method to update a booking
        Agent Check(string email, string password);

        void AddAgent(Agent agent);

        AgentBooking GetBooking(string bookingid);

        List<FlightScheduleDTO> GetFlights(string source, string destination);
        FlightDetail Getflightdetails(string flightnumber);
    }

}

