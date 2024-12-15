using FlightBookingApp.Entities;
using FlightBookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FlightBookingApp.Controllers
{
    [RoutePrefix("AgentController")]
    public class AgentController : ApiController
    {
        private IAgentRepository agentRepository;
        public AgentController()
        {
            agentRepository = new AgentRepository();
        }
        [HttpPost,Route("registeragent")]
        public IHttpActionResult ApplyForAccount([FromBody]AuthenticateAgent agent)
        {
            try
            {
                agentRepository.ApplyForAccount(agent);
                return Ok(agent);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost,Route("bookticket")]
        public IHttpActionResult BookTicket([FromBody]AgentBooking agentBooking)
        {
            try
            {
                agentRepository.BookTicket(agentBooking);
                return Ok(agentBooking);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet,Route("totalcommission")]
        public IHttpActionResult CalculateCommission(string agentId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var totalcommission=agentRepository.CalculateCommission(agentId, startDate, endDate);
                return Ok(totalcommission);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete, Route("CancelBooking/{bookingId}")]
        public IHttpActionResult CancelBooking(string bookingId)
        {
            try
            {
                agentRepository.CancelBooking(bookingId);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet, Route("BookingHistory/{agentId}/{startDate}/{endDate}")]
        public IHttpActionResult GetBookingHistory(string agentId, DateTime startDate,  DateTime endDate)
        {
            try
            {
                var bookings = agentRepository.GetBookingHistory(agentId, startDate, endDate);
                return Ok(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut, Route("UpdateBooking")]
        public IHttpActionResult UpdateBooking([FromBody] AgentBooking agentBooking)
        {
            try
            {
                agentRepository.UpdateBooking(agentBooking);
                return Ok(agentBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
