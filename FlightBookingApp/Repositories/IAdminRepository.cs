using FlightBookingApp.Entities;
using FlightBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Repositories
{
    internal interface IAdminRepository
    {
        void AgentApproval(Agent agent);
        void AgentReject(Agent agent);
        Admin Check(string email, string password);

        void AddSchedule(FlightSchedule flightSchedule);
        List<FlightScheduleDTO> GetAllFlightSchedule();
        List<PassengerDTO> GetAllPassengers(string flightnumber);
        void CancelScheduleFlight(string id);
        void UpdateScheduleFlight(FlightSchedule flightSchedule);
        FlightSchedule GetFlightScheduleById(string scheduleid);
        List<Agent> GetAllAgents();
        Agent GetAgent(string agentid);

        List<FlightDetail> GetFlights();
        FlightDetail Getflightdetails(string flightnumber);

        void DiscountAddtion(FlightDetail flightDetail);

    }
}
