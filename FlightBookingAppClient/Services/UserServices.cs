using FlightBookingAppClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Helpers;

namespace FlightBookingAppClient.Services
{
    public class UserServices
    {
        HttpClient client;
        UserBooking booking;
        Random random;
        public UserServices()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62120/");
            booking = new UserBooking();
            random = new Random();
        }

        public List<FlightScheduleDTO> GetFlights(string source, string destination)
        {
            HttpResponseMessage response = client.GetAsync("User/searchflights/" + source + "/" + destination).Result;
            List<FlightScheduleDTO> schedules = JsonConvert.DeserializeObject<List<FlightScheduleDTO>>(response.Content.ReadAsStringAsync().Result);
            return schedules;
        }
        public User Check(string email, string password)
        {
            HttpResponseMessage response = client.GetAsync("User/check/" + email + "/" + password).Result;
            User user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
            return user;
        }
        public List<UserBooking> GetBookings(string userid)
        {
            HttpResponseMessage response = client.GetAsync("User/bookhistory/" + userid).Result;
            List<UserBooking> bookings = JsonConvert.DeserializeObject<List<UserBooking>>(response.Content.ReadAsStringAsync().Result);
            return bookings;
        }

        public void CancelBooking(string bookingId)
        { 
            HttpResponseMessage response = client.DeleteAsync("User/cancelbooking/"+bookingId).Result;

        }
        public UserBooking GetBooking(string bookingid)
        {
            HttpResponseMessage response = client.GetAsync("User/getbooking/" + bookingid).Result;
            UserBooking booking = JsonConvert.DeserializeObject<UserBooking>(response.Content.ReadAsStringAsync().Result);
            return booking;
        }
        public User GetUser(string userid)
        {
            HttpResponseMessage response = client.GetAsync("User/userdetails/" + userid).Result;
            User user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
            return user;
        }

        public void UpdateUser(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("User/userupdate", content).Result;
        }

        public FlightDetail flightdetails(string flightnumber)
        {
            HttpResponseMessage response = client.GetAsync("User/flightdetails/" + flightnumber).Result;
            FlightDetail flight = JsonConvert.DeserializeObject<FlightDetail>(response.Content.ReadAsStringAsync().Result);
            return flight;
        }

        public void AddBooking(string flightnumber, double ticketprice,double discount, DateTime flightdate, string userid)
        {
            UserBooking booking= new UserBooking();
            double totalprice = ticketprice - (ticketprice * discount / 100);
            booking.BookingDate = DateTime.Now;
            booking.FlightDate = flightdate;
            booking.FlightNumber = flightnumber;
            booking.SeatNumber = "SN"+random.Next(100);
            booking.TicketPrice = totalprice;
            booking.BookingId = "B" + random.Next(1000);
            booking.UserId = userid;
            var content = new StringContent(JsonConvert.SerializeObject(booking), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("User/addbooking", content).Result;
        }

        public void RegisterUser(User user)
        {
            var content = new StringContent(JsonConvert.SerializeObject(user), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("User/register", content).Result;
        }
    }
}