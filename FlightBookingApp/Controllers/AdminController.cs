using FlightBookingApp.Entities;
using FlightBookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;

namespace FlightBookingApp.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : ApiController
    {
        private IAdminRepository repository;
        public AdminController()
        {
            repository = new AdminRepository();
        }
        [HttpPost,Route("approval")]
        public IHttpActionResult Approval(Agent agent)
        {
            try
            {
                repository.AgentApproval(agent);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Approval failed"); 
            }
        }

        [HttpPost,Route("reject")]
        public IHttpActionResult Reject(Agent agent)
        {
            try
            {
                repository.AgentReject(agent);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Rejection failed");
            }
        }

        [HttpPut,Route("updateschedule")]
        public IHttpActionResult Update([FromBody] FlightSchedule flightSchedule)
        {
            try
            {
                repository.UpdateScheduleFlight(flightSchedule);
                return Ok(flightSchedule);
            }
            catch (Exception)
            {

                return BadRequest("Updation failed");
            }
        }

        [HttpPost,Route("addschedule")]
        public IHttpActionResult AddSchedule([FromBody]FlightSchedule flightSchedule)
        {
            try
            {
                repository.AddSchedule(flightSchedule);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Schedule addition failed");
            }
        }

        [HttpGet,Route("schedule")]
        public IHttpActionResult GetAllSchedule()
        {
            try
            {
                var schedules = repository.GetAllFlightSchedule();
                return Ok(schedules);
            }
            catch (Exception)
            {

                return BadRequest("Schedule fetching failed");
            }
        }

        [HttpGet,Route("flightpassengers/{flightnumber}")]
        public IHttpActionResult GetFlightPassengers(string flightnumber)
        {
            try
            {
                var passengers = repository.GetAllPassengers(flightnumber);
                return Ok(passengers);
            }
            catch (Exception)
            {

                return BadRequest("Passengers cannot be fetched"); 
            }
        }
        [HttpGet,Route("schedulebyid/{scheduleid}")]
        public IHttpActionResult GetScheduleById(string scheduleid)
        {
            try
            {
                var flightschedule = repository.GetFlightScheduleById(scheduleid);
                return Ok(flightschedule);
            }
            catch (Exception)
            {

                return BadRequest("Error in fetching flight schedule"); 
            }
        }
        [HttpGet,Route("getagents")]
        public IHttpActionResult GetAgents()
        {
            try
            {
                var agents = repository.GetAllAgents();
                return Ok(agents);
            }
            catch (Exception)
            {

                return BadRequest("Agents cannot be fetched");
            }
        }
        [HttpGet,Route("agent/{id}")]
        public IHttpActionResult GetAgent(string id)
        {
            try
            {
                var applicant = repository.GetAgent(id);
                return Ok(applicant);
            }
            catch (Exception)
            {

                return BadRequest("Agent fetch failed");
            }
        }

        [HttpGet, Route("check/{email}/{password}")]
        public IHttpActionResult Check(string email, string password)
        {
            try
            {
                var admin = repository.Check(email, password);
                return Ok(admin);
            }
            catch (Exception)
            {
                return BadRequest("Admin not found");
            }
        }

        [HttpGet,Route("allflights")]
        public IHttpActionResult GetFlights()
        {
            try
            {
                var flights = repository.GetFlights();
                return Ok(flights);
            }
            catch (Exception)
            {

                return BadRequest("Flights fetching failed");
            }
        }

        [HttpGet, Route("flightdetails/{flightnumber}")]
        public IHttpActionResult GetFlightDetails(string flightnumber)
        {
            try
            {
                var detail = repository.Getflightdetails(flightnumber);
                return Ok(detail);
            }
            catch (Exception)
            {

                return BadRequest("Details fetching failed");
            }
        }

        [HttpPut,Route("addDiscount")]
        public IHttpActionResult AddDiscount(FlightDetail flightDetail)
        {
            try
            {
                repository.DiscountAddtion(flightDetail);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Discount adding failed");
            }
        }
    }
}
