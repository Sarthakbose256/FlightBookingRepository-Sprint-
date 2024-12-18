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
    [RoutePrefix("User")]
    public class UserController : ApiController
    {
        private IUserRepository repository;

        public UserController()
        {
            repository = new UserRepository();
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

                return BadRequest("User cannot be removed");
            }
        }
        [HttpGet,Route("bookhistory/{userid}")]
        public IHttpActionResult GetBookingHistory(string userid)
        {
            try
            {
                var history = repository.GetBookingHistory(userid);
                return Ok(history);
            }
            catch (Exception)
            {

                return BadRequest("Booking history not found");
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

                return BadRequest("Flights not found");
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

                return BadRequest("User cannot be updated");
            }
        }

        [HttpGet,Route("check/{email}/{password}")]
        public IHttpActionResult Check(string email,string password)
        {
            try
            {
                var user = repository.Check(email, password);
                return Ok(user);
            }
            catch (Exception)
            {

                return BadRequest("No user found");
            }
        }

        [HttpDelete, Route("cancelbooking/{bookingid}")]
        public IHttpActionResult CancelBooking(string bookingid)
        {
            try
            {
                repository.CancelBooking(bookingid);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Booking cannot be cancelled");
            }
        }

        [HttpGet,Route("getbooking/{bookingid}")]
        public IHttpActionResult GetBooking(string bookingid)
        {
            try
            {
                var booking = repository.GetBooking(bookingid);
                return Ok(booking);
            }
            catch (Exception)
            {

                return BadRequest("Booking cannot be fetched");
            }
        }

        [HttpGet,Route("userdetails/{userid}")]
        public IHttpActionResult GetUser(string userid)
        {
            try
            {
                var user = repository.GetUser(userid);
                return Ok(user);
            }
            catch (Exception)
            {

                return BadRequest("User cannot be fetched");
            }
        }

        [HttpGet,Route("flightdetails/{flightnumber}")]
        public IHttpActionResult GetFlightDetails(string flightnumber)
        {
            try
            {
                var detail = repository.Getflightdetails(flightnumber);
                return Ok(detail);
            }
            catch (Exception)
            {

                return BadRequest("Flights cannot be fetched");
            } 
        }

        [HttpPost,Route("addbooking")]
        public IHttpActionResult AddBooking(UserBooking booking)
        {
            try
            {
                repository.BookTicket(booking);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Error while adding bookings");
            }
        }

        [HttpPost,Route("register")]
        public IHttpActionResult RegisterUser([FromBody]User user)
        {
            try
            {
                repository.AddUser(user);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("User cannot be registered");
            }
        }

     
    }
}
