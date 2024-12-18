using FlightBookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using FlightBookingApp.Models;

namespace FlightBookingApp.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private FlightContext context;
        public AgentRepository()
        {
            context = new FlightContext();
        }



        public void BookTicket(AgentBooking agentBooking)
        {
            try
            {
                context.agentBookings.Add(agentBooking);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public double CalculateCommission(string agentId, DateTime startDate, DateTime endDate)
        {
            double totalcommission=0;
            var bookings = context.agentBookings.Where(m => m.AgentId == agentId).ToList();
            var  records = bookings.Where(p => p.BookingDate >= startDate && p.BookingDate <= endDate).ToList();
            foreach(var item in records)
            {
                totalcommission = totalcommission + item.CommissionEarned;
            }
            return totalcommission;

        }

        public void CancelBooking(string bookingid)
        {
            var booking = context.agentBookings.Find(bookingid);
            context.agentBookings.Remove(booking);
            context.SaveChanges();
        }

        public List<AgentBooking> GetBookingHistory(string agentId)
        {
            try
            {
                var bookings = context.agentBookings.Where(x => x.AgentId == agentId).ToList();
                return bookings;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateBooking(AgentBooking agentBooking)
        {
            try
            {

                var editBooking = context.agentBookings.Find(agentBooking.BookingId);
                if (editBooking != null)
                {
                    editBooking.CustomerName = agentBooking.CustomerName;
                    editBooking.SeatNumber = agentBooking.SeatNumber;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Agent Check(string email, string password)
        {
            var agent = context.agents.SingleOrDefault(m => m.Email == email && m.password == password);
            return agent;
        }
        public void AddAgent(Agent agent)
        {
            context.agents.Add(agent);
            context.SaveChanges();
        }

        public AgentBooking GetBooking(string bookingid)
        {
            var booking = context.agentBookings.Find(bookingid);
            return booking;
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

        public FlightDetail Getflightdetails(string flightnumber)
        {
            var detail = context.flightDetails.Find(flightnumber);
            return detail;
        }
    }
}
