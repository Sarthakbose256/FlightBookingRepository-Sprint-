using FlightBookingAppClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FlightBookingAppClient.Services
{
    public class AgentServices
    {
        HttpClient client;
        Random random;
        public AgentServices()
        {
            random = new Random();
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62120/");
        }

        public Agent Check(string email, string password)
        {
            HttpResponseMessage response = client.GetAsync("Agent/check/" + email + "/" + password).Result;
            Agent agent = JsonConvert.DeserializeObject<Agent>(response.Content.ReadAsStringAsync().Result);
            return agent;
        }

        public void RegisterAgent(Agent agent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(agent), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Agent/register", content).Result;
        }

        public List<AgentBooking> GetBookings(string agentid)
        {
            HttpResponseMessage response = client.GetAsync("Agent/bookhistory/" + agentid).Result;
            List<AgentBooking> bookings = JsonConvert.DeserializeObject<List<AgentBooking>>(response.Content.ReadAsStringAsync().Result);
            return bookings;
        }

        public void CancelBooking(string bookingId)
        {
            HttpResponseMessage response = client.DeleteAsync("Agent/cancelbooking/" + bookingId).Result;
        }

        public AgentBooking GetBooking(string bookingid)
        {
            HttpResponseMessage response = client.GetAsync("Agent/getbooking/" + bookingid).Result;
            AgentBooking booking = JsonConvert.DeserializeObject<AgentBooking>(response.Content.ReadAsStringAsync().Result);
            return booking;

        }

        public void UpdateBooking(AgentBooking booking)
        {
            var content = new StringContent(JsonConvert.SerializeObject(booking), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("Agent/UpdateBooking", content).Result;
        }

        public List<FlightScheduleDTO> GetFlights(string source, string destination)
        {
            HttpResponseMessage response = client.GetAsync("Agent/searchflights/" + source + "/" + destination).Result;
            List<FlightScheduleDTO> schedules = JsonConvert.DeserializeObject<List<FlightScheduleDTO>>(response.Content.ReadAsStringAsync().Result);
            return schedules;
        }

        public FlightDetail flightdetails(string flightnumber)
        {
            HttpResponseMessage response = client.GetAsync("Agent/flightdetails/" + flightnumber).Result;
            FlightDetail flight = JsonConvert.DeserializeObject<FlightDetail>(response.Content.ReadAsStringAsync().Result);
            return flight;
        }

        public void AddBooking(Customer customer,string flightnumber, double ticketprice, double discount, DateTime flightdate, string agentid)
        {
            AgentBooking booking = new AgentBooking();
            double totalprice = ticketprice - (ticketprice * discount / 100);
            booking.CustomerName = customer.CustName;
            booking.Email = customer.Email;
            booking.Mobile = customer.Number;
            booking.BookingDate = DateTime.Now;
            booking.FlightDate = flightdate;
            booking.FlightNumber = flightnumber;
            booking.SeatNumber = "SN" + random.Next(100);
            booking.TicketPrice = totalprice;
            booking.BookingId = "B" + random.Next(1000);
            booking.AgentId = agentid;
            booking.CommissionEarned = totalprice * 0.9 / 100;
            var content = new StringContent(JsonConvert.SerializeObject(booking), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Agent/addbooking", content).Result;
        }

    }
}