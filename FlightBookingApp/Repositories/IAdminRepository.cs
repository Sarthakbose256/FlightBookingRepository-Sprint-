using FlightBookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBookingApp.Repositories
{
    internal interface IAdminRepository
    {
        void AgentApproval(AuthenticateAgent authenticateAgent);
        void AgentReject(int id);
        List<FlightSchedule> GetAllFlightSchedule();
        List<UserBooking> GetAllPassengers(string flightnumber);
        void CancelScheduleFlight(string id);
        void UpdateScheduleFlight(FlightSchedule flightSchedule);

    }
}
