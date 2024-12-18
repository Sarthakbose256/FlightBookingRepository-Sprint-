using FlightBookingAppClient.Models;
using FlightBookingAppClient.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FlightBookingAppClient.Controllers
{
    [RoutePrefix("User")]
    public class UserController : Controller
    {
        UserServices userServices;
        Random random;
        public UserController()
        {
            userServices = new UserServices();
            random = new Random();

        }

        // GET: User
        public ActionResult UserDashboard()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View("Error");
            }
        }



        [HttpGet, Route("bookhistory")]
        public ActionResult BookHistory()
        {
            try
            {
                string userid = Session["userid"].ToString();
                var bookings = userServices.GetBookings(userid);
                return View(bookings);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }
        [HttpGet, Route("cancel/{bookingid}")]
        public ActionResult CancelBooking(string bookingid)
        {
            try
            {

                userServices.CancelBooking(bookingid);
                return RedirectToAction("BookHistory");
            }
            catch (Exception)
            {

                return View("Error");
            }

        }
        [Route("searchflights")]
        public ActionResult Searchflights()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("flights")]
        public ActionResult GetFlights(string source, string destination)
        {
            try
            {
                var flights = userServices.GetFlights(source, destination);
                return View(flights);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("Login")]
        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpPost, Route("Login")]
        public ActionResult Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = userServices.Check(login.Email, login.password);
                    if (user != null)
                    {
                        Session["userid"] = user.UserId;
                        return RedirectToAction("UserDashboard");
                    }
                    else
                    {
                        ViewBag.message = "No user found";
                        return View();
                    }
                }
                else
                {
                    ViewBag.message = "No user found";
                    return View();
                }
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("userdetails")]
        public ActionResult GetDetails()
        {
            try
            {
                string userid = Session["userid"].ToString();
                var user = userServices.GetUser(userid);
                return View(user);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("updatedetails")]
        public ActionResult Update()
        {
            try
            {
                string userid = Session["userid"].ToString();
                var user = userServices.GetUser(userid);
                return View(user);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpPost, Route("updatedetails")]
        public ActionResult Update(User user)
        {
            try
            {
                userServices.UpdateUser(user);
                return RedirectToAction("GetDetails");
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("registeruser")]
        public ActionResult Register()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpPost, Route("registeruser")]
        public ActionResult Register(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.UserId = "U" + random.Next(1000);
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    userServices.RegisterUser(user);
                    return RedirectToAction("RegisterConfirmation");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("registerconfirm")]
        public ActionResult RegisterConfirmation()
        {
            try
            {
                ViewBag.message = "You have been successfully registered";
                return View();
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("flightdetail")]
        public ActionResult FlightDetail(string flightnumber, DateTime flightdate)
        {
            try
            {
                Session["flightdate"] = flightdate;
                var flight = userServices.flightdetails(flightnumber);
                return View(flight);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("payment")]
        public ActionResult PaymentPage(string flightnumber, double price, double discount)
        {
            try
            {
                DateTime flightdate = (DateTime)Session["flightdate"];
                string userid = Session["userid"].ToString();
                userServices.AddBooking(flightnumber, price, discount, flightdate, userid);
                ViewBag.message = "Payment Successfull";
                return View();
            }
            catch (Exception)
            {

                return View("Error");
            }
        }



    }
}