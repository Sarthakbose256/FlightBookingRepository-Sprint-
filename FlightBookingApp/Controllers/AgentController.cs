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
    [RoutePrefix("Agent")]
    public class AgentController : ApiController
    {
        private IAgentRepository agentRepository;
        public AgentController()
        {
            agentRepository = new AgentRepository();
        }


        [HttpPost, Route("addbooking")]
        public IHttpActionResult AddBooking(AgentBooking booking)
        {
            try
            {
                agentRepository.BookTicket(booking);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Booking cannot be added");
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
            catch (Exception)
            {
                return BadRequest("Booking cannot be updated");
            }
        }

        [HttpGet, Route("check/{email}/{password}")]
        public IHttpActionResult Check(string email, string password)
        {
            try
            {
                var agent = agentRepository.Check(email, password);
                return Ok(agent);
            }
            catch (Exception)
            {

                return BadRequest("Agent cannot be fetched");
            }
        }
        [HttpPost, Route("register")]
        public IHttpActionResult RegisterAgent([FromBody] Agent agent)
        {
            try
            {
                agentRepository.AddAgent(agent);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Agent cannnot be registered");
            }
        }

        [HttpGet, Route("bookhistory/{agentid}")]
        public IHttpActionResult GetBookingHistory(string agentid)
        {
            try
            {
                var history = agentRepository.GetBookingHistory(agentid);
                return Ok(history);
            }
            catch (Exception)
            {

                return BadRequest("Booking history cannot be fetched");
            }
        }

        [HttpDelete, Route("cancelbooking/{bookingid}")]
        public IHttpActionResult CancelBooking(string bookingid)
        {
            try
            {
                agentRepository.CancelBooking(bookingid);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Booking cannot be cancelled");
            }
        }


        [HttpGet, Route("getbooking/{bookingid}")]
        public IHttpActionResult GetBooking(string bookingid)
        {
            try
            {
                var booking = agentRepository.GetBooking(bookingid);
                return Ok(booking);
            }
            catch (Exception)
            {

                return BadRequest("Booking cannot be fetched");
            }
        }

        [HttpGet, Route("searchflights/{source}/{destination}")]
        public IHttpActionResult GetFlights(string source, string destination)
        {
            try
            {
                var flights = agentRepository.GetFlights(source, destination);
                return Ok(flights);
            }
            catch (Exception)
            {

                return BadRequest("Flights cannot be fetched");
            }
        }

        [HttpGet, Route("flightdetails/{flightnumber}")]
        public IHttpActionResult GetFlightDetails(string flightnumber)
        {
            try
            {
                var detail = agentRepository.Getflightdetails(flightnumber);
                return Ok(detail);
            }
            catch (Exception)
            {

                return BadRequest("Flight details cannot be fetched");
            }
        }

    }
}