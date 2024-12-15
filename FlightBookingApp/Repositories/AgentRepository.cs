using FlightBookingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FlightBookingApp.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private FlightContext context;
        public AgentRepository()
        {
            context = new FlightContext();
        }

        public void ApplyForAccount(AuthenticateAgent agent)
        {
            try
            {
                context.authenticateAgents.Add(agent);
                context.SaveChanges();
            }
            catch(Exception)
            {
                throw;
            }
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

        public void CancelBooking(string bookingId)
        {
            try
            {
                var booking = context.agentBookings.Find(bookingId);
                if (booking != null)
                {
                    context.agentBookings.Remove(booking);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<AgentBooking> GetBookingHistory(string agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var bookings = context.agentBookings.Where(x => x.AgentId == agentId && (x.BookingDate >= startDate 
                && x.BookingDate <= endDate)).ToList();
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
                    editBooking.UserName = agentBooking.UserName;
                    editBooking.SeatNumber = agentBooking.SeatNumber;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }
    }
}
