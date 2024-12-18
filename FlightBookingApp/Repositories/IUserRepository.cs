using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBookingApp.Entities;
using FlightBookingApp.Models;
namespace FlightBookingApp.Repositories
{
    internal interface IUserRepository
    {
        List<FlightScheduleDTO> GetFlights(string source, string destination);
        void AddUser(User user);
        void BookTicket(UserBooking bookings);
        void DeleteUser(string id);
        List<UserBooking> GetBookingHistory(string userid);
        void UpdateUser(User user);
        User GetUser(string userid);
        User Check(string email, string password);
        void CancelBooking(string bookingid);

        UserBooking GetBooking(string bookingid);

        FlightDetail Getflightdetails(string flightnumber);

    }
}
