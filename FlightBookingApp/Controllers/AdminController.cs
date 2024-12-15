using FlightBookingApp.Entities;
using FlightBookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;

namespace FlightBookingApp.Controllers
{
    [RoutePrefix("AdminController")]
    public class AdminController : ApiController
    {
        private IAdminRepository repository;
        public AdminController()
        {
            repository = new AdminRepository();
        }
        [HttpPost,Route("approval")]
        public IHttpActionResult Approval([FromBody]AuthenticateAgent authenticateAgent)
        {
            repository.AgentApproval(authenticateAgent);
            return Ok(authenticateAgent);
        }

        [HttpPut,Route("reject/{id}")]
        public IHttpActionResult Reject(int id)
        {
            repository.AgentReject(id);
            return Ok();
        }

        [HttpPut,Route("updateschedule")]
        public IHttpActionResult Update([FromBody] FlightSchedule flightSchedule)
        {
            repository.UpdateScheduleFlight(flightSchedule);
            return Ok(flightSchedule);
        }

        [HttpPost,Route("cancelschedule/{id}")]
        public IHttpActionResult CancelScheduleFlight(string id)
        {
            repository.CancelScheduleFlight(id);
            return Ok();
        }

        [HttpGet,Route("schedule")]
        public IHttpActionResult GetAllSchedule()
        {
            var schedules = repository.GetAllFlightSchedule();
            return Ok(schedules);
        }

        [HttpGet,Route("flightpassengers/{flightnumber}")]
        public IHttpActionResult GetFlightPassengers(string flightnumber)
        {
            var passengers = repository.GetAllPassengers(flightnumber);
            return Ok(passengers);
        }

    }
}
