using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBookingApp.Entities;
namespace FlightBookingApp.Repositories
{
    internal interface IUserRepository
    {
        List<FlightSchedule> GetFlights(string source, string destination);
        void AddUser(User user);
        void BookTicket(UserBooking bookings);
        void DeleteUser(string id);
        List<UserBooking> GetBookingHistory(string id);
        void CancelBooking(string id);
        void UpdateUser(User user);

    }
}
