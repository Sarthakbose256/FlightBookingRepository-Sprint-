using FlightBookingApp.Entities;
using FlightBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace FlightBookingApp.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private FlightContext context;
        private Random random;
        public AdminRepository()
        {
            context = new FlightContext();
            random = new Random();
        }
        public void AgentApproval(Agent agent)
        {
            var update = context.agents.SingleOrDefault(m => m.agentId == agent.agentId);
            update.status = "Approved";
            context.SaveChanges();
        }
        public void AgentReject(Agent agent)
        {

            var update = context.agents.SingleOrDefault(m => m.agentId == agent.agentId);
            update.status = "Rejected";
            context.SaveChanges();
        }

        public void CancelScheduleFlight(string id)
        {
            var cancel = context.flightSchedules.Find(id);
            context.flightSchedules.Remove(cancel);
        }

        public List<FlightScheduleDTO> GetAllFlightSchedule()
        {
            var list = (from flightSchedule in context.flightSchedules
                        join flightDetails in context.flightDetails
                        on flightSchedule.FlightNumber equals flightDetails.FlightNumber
                        select new FlightScheduleDTO()
                        {
                            ScheduleId= flightSchedule.ScheduleId,
                            FlightNumber=flightSchedule.FlightNumber,
                            Airline=flightDetails.Airline,
                            DepartureTime=flightSchedule.DepartureTime,
                            ArrivalTime=flightSchedule.ArrivalTime,
                            Duration=flightSchedule.Duration,
                            FlightDate=flightSchedule.FlightDate,
                            DepartureLoc=flightSchedule.DepartureLoc,
                            ArrivalLocation=flightSchedule.ArrivalLocation
                        }).ToList();
            return list;
        }

        public List<PassengerDTO> GetAllPassengers(string flightnumber)
        {
            var list = (from userbooking in context.userBookings
                        join
                        user in context.users on userbooking.UserId equals user.UserId
                        where  userbooking.FlightNumber==flightnumber
                        select new PassengerDTO()
                        {
                            BookingId = userbooking.BookingId,
                            FlightNumber = userbooking.FlightNumber,
                            SeatNumber = userbooking.SeatNumber,
                            UserName = user.UserName,
                            Email = user.Email,
                            BookingDate = userbooking.BookingDate
                            
                        }).ToList();
            return list;
        }

        public void UpdateScheduleFlight(FlightSchedule flightSchedule)
        {
            var flight = context.flightSchedules.SingleOrDefault(m=>m.ScheduleId==flightSchedule.ScheduleId);
            flight.DepartureTime = flightSchedule.DepartureTime;
            flight.ArrivalTime = flightSchedule.ArrivalTime;
            flight.DepartureLoc = flightSchedule.DepartureLoc;
            flight.ArrivalLocation= flightSchedule.ArrivalLocation;
            flight.Duration= flightSchedule.Duration;
            flight.FlightDate= flightSchedule.FlightDate;   
            context.SaveChanges();
        }
        public FlightSchedule GetFlightScheduleById(string scheduleid)
        {
            var flightschedule = context.flightSchedules.Find(scheduleid);
            return flightschedule;
        }

        public void AddSchedule(FlightSchedule flightSchedule)
        {
           context.flightSchedules.Add(flightSchedule);
            context.SaveChanges();
        }

        public List<Agent> GetAllAgents()
        {
            var agents= context.agents.ToList();
            return agents;
        }

        public Agent GetAgent(string agentid)
        {
            var applicant = context.agents.Find(agentid);
            return applicant;
        }

        public Admin Check(string email, string password)
        {
            var admin = context.admins.SingleOrDefault(m => m.AdminEmail== email && m.AdminPwd == password);
            return admin;
        }

        public List<FlightDetail> GetFlights()
        {
            var flights = context.flightDetails.ToList();
            return flights;
        }

        public FlightDetail Getflightdetails(string flightnumber)
        {
            var detail = context.flightDetails.Find(flightnumber);
            return detail;
        }

        public void DiscountAddtion(FlightDetail flightDetail)
        {
            var detail = context.flightDetails.Find(flightDetail.FlightNumber);
            detail.Discount= flightDetail.Discount;
            context.SaveChanges();
        }
    }
}