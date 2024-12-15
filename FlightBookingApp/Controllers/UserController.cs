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
    [RoutePrefix("UserController")]
    public class UserController : ApiController
    {
        private IUserRepository repository;

        public UserController()
        {
            repository = new UserRepository();
        }
        [HttpPost,Route("adduser")]
        public IHttpActionResult CreateUser([FromBody] User user)
        {
            try
            {
                repository.AddUser(user);
                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost,Route("ticketbooking")]
        public IHttpActionResult BookTicket([FromBody] UserBooking userbooking)
        {
            try
            {
                repository.BookTicket(userbooking);
                return Ok(userbooking);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete,Route("cancelBooking/{id}")]
        public IHttpActionResult CancelBooking(string id)
        {
            try
            {
                repository.CancelBooking(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpDelete,Route("removeuser/{id}")]
        public IHttpActionResult RemoveUser(string id)
        {
            try
            {
                repository.DeleteUser(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet,Route("bookhistory/{id}")]
        public IHttpActionResult GetBookingHistory(string id)
        {
            try
            {
                var history = repository.GetBookingHistory(id);
                return Ok(history);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet,Route("searchflights/{source}/{destination}")]
        public IHttpActionResult GetFlights(string source, string destination)
        {
            try
            {
                var flights = repository.GetFlights(source, destination);
                return Ok(flights);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut,Route("userupdate")]
        public IHttpActionResult UpdateUser([FromBody]User user)
        {
            try
            {
                repository.UpdateUser(user);
                return Ok(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
