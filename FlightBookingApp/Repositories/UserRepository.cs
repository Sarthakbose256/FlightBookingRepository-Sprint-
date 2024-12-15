
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightBookingApp.Entities;

namespace FlightBookingApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private FlightContext context;
        public UserRepository()
        {
            context= new FlightContext();   
        }

        public void AddUser(User user)
        {
           context.users.Add(user);
            context.SaveChanges();
        }

        public void BookTicket(UserBooking bookings)
        {
            context.userBookings.Add(bookings);
            context.SaveChanges();
        }

        public void CancelBooking(string id)
        {
            var Booking = context.userBookings.SingleOrDefault(m => m.BookingId == id);
            context.userBookings.Remove(Booking);
            context.SaveChanges();
        }

        public void DeleteUser(string id)
        {
           var cust=context.users.SingleOrDefault(m => m.UserId == id);
            context.users.Remove(cust);
            context.SaveChanges();

        }

        public List<UserBooking> GetBookingHistory(string id)
        {
            var bookings = context.userBookings.Where(m=>m.UserId==id).ToList();
            return bookings;
        }

        public List<FlightSchedule> GetFlights(string source, string destination)
        {
            var flights = context.flightSchedules.Where(m => m.DepartureLoc == source && m.ArrivalLocation==destination).ToList();
            return flights;

        }

        public void UpdateUser(User user)
        {
            var cust = context.users.SingleOrDefault(m=>m.UserId==user.UserId);
            cust.password=user.password;
            cust.UserPhone=user.UserPhone;
            cust.UserName=user.UserName;
            cust.Email = user.Email;
            cust.UpdatedAt=DateTime.Now;
            context.SaveChanges();
        }

        
    }
}