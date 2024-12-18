using FlightBookingAppClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace FlightBookingAppClient.Services
{
    public class AdminServices
    {
        HttpClient client;
        public AdminServices()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:62120/");
        }
        public List<FlightScheduleDTO> FlightSchedules()
        {
            HttpResponseMessage response = client.GetAsync("Admin/schedule").Result;
            List<FlightScheduleDTO> schedules = JsonConvert.DeserializeObject<List<FlightScheduleDTO>>(response.Content.ReadAsStringAsync().Result);
            return schedules;
        }
        public List<PassengerDTO> GetFlightPassengers(string flightnumber)
        {
            HttpResponseMessage response = client.GetAsync("Admin/flightpassengers/"+flightnumber).Result;
            List<PassengerDTO> bookings = JsonConvert.DeserializeObject<List<PassengerDTO>>(response.Content.ReadAsStringAsync().Result);
            return bookings;
        }

        public void UpdateSchedule(FlightSchedule flightSchedule)
        {
            var content = new StringContent(JsonConvert.SerializeObject(flightSchedule), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("Admin/updateschedule", content).Result;
        }
        public FlightSchedule GetScheduleById(string scheduleid)
        {
            HttpResponseMessage response = client.GetAsync("Admin/schedulebyid/" +scheduleid).Result;
            FlightSchedule flightSchedule = JsonConvert.DeserializeObject<FlightSchedule>(response.Content.ReadAsStringAsync().Result);
            return flightSchedule;
        }
        public void AddFlightSchedule(FlightSchedule flightSchedule)
        {
            var content = new StringContent(JsonConvert.SerializeObject(flightSchedule), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Admin/addschedule", content).Result;
        }
        public List<Agent> GetAllAgents()
        {
            HttpResponseMessage response = client.GetAsync("Admin/getagents").Result;
            List<Agent> agents = JsonConvert.DeserializeObject<List<Agent>>(response.Content.ReadAsStringAsync().Result);
            return agents;
        }
        public void ApproveAgent(Agent agent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(agent), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Admin/approval", content).Result;
        }
        public void RejectAgent(Agent agent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(agent), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync("Admin/reject", content).Result;

        }
        public Agent GetAgent(string agentid)
        {
            HttpResponseMessage response = client.GetAsync("Admin/agent/" + agentid).Result;
            Agent applicant = JsonConvert.DeserializeObject<Agent>(response.Content.ReadAsStringAsync().Result);
            return applicant;

        }

        public Admin Check(string email, string password)
        {
            HttpResponseMessage response = client.GetAsync("Admin/check/" + email + "/" + password).Result;
            Admin admin = JsonConvert.DeserializeObject<Admin>(response.Content.ReadAsStringAsync().Result);
            return admin;
        }

        public List<FlightDetail> Flights()
        {
            HttpResponseMessage response = client.GetAsync("Admin/allflights").Result;
            List<FlightDetail> flights = JsonConvert.DeserializeObject<List<FlightDetail>>(response.Content.ReadAsStringAsync().Result);
            return flights;
        }

        public FlightDetail flightdetails(string flightnumber)
        {
            HttpResponseMessage response = client.GetAsync("Admin/flightdetails/" + flightnumber).Result;
            FlightDetail flight = JsonConvert.DeserializeObject<FlightDetail>(response.Content.ReadAsStringAsync().Result);
            return flight;
        }

        public void AddDiscount(FlightDetail flightDetail)
        {
            var content = new StringContent(JsonConvert.SerializeObject(flightDetail), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync("Admin/addDiscount", content).Result;
        }
    }
}