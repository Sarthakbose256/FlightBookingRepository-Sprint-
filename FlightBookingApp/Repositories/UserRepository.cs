
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlightBookingApp.Entities;
using FlightBookingApp.Models;

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



        public void DeleteUser(string id)
        {
           var cust=context.users.SingleOrDefault(m => m.UserId == id);
            context.users.Remove(cust);
            context.SaveChanges();

        }

        public List<UserBooking> GetBookingHistory(string userid)
        {
            var bookings = context.userBookings.Where(m=>m.UserId==userid).ToList();
            return bookings;
        }

        public List<FlightScheduleDTO> GetFlights(string source, string destination)
        {
            var list = (from flightSchedule in context.flightSchedules
                        join flightDetails in context.flightDetails
                        on flightSchedule.FlightNumber equals flightDetails.FlightNumber
                        where (flightSchedule.DepartureLoc == source && flightSchedule.ArrivalLocation == destination)
                        select new FlightScheduleDTO()
                        {
                            ScheduleId = flightSchedule.ScheduleId,
                            FlightNumber = flightSchedule.FlightNumber,
                            Airline = flightDetails.Airline,
                            DepartureTime = flightSchedule.DepartureTime,
                            ArrivalTime = flightSchedule.ArrivalTime,
                            Duration = flightSchedule.Duration,
                            FlightDate = flightSchedule.FlightDate,
                            DepartureLoc = flightSchedule.DepartureLoc,
                            ArrivalLocation = flightSchedule.ArrivalLocation
                        }).ToList();
            return list;

        }

        public User GetUser(string userid)
        {
            var user = context.users.Find(userid);
            return user;
        }

        public User Check(string email, string password)
        {
            var user = context.users.SingleOrDefault(m => m.Email == email && m.password == password);
            return user;
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

        public void CancelBooking(string bookingid)
        {
            var booking=context.userBookings.Find(bookingid);
            context.userBookings.Remove(booking);
            context.SaveChanges();
        }

        public UserBooking GetBooking(string bookingid)
        {
            var booking = context.userBookings.Find(bookingid);
            return booking;
        }

        public FlightDetail Getflightdetails(string flightnumber)
        {
            var detail = context.flightDetails.Find(flightnumber);
            return detail;
        }

    }
}