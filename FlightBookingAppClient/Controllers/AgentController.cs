using FlightBookingAppClient.Services;
using FlightBookingAppClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightBookingAppClient.Controllers
{
    [RoutePrefix("Agent")]
    public class AgentController : Controller
    {
        AgentServices agentServices;
        Random random;
        public AgentController()
        {
            agentServices = new AgentServices();
            random = new Random();
        }
        // GET: Agent
        public ActionResult AgentDashboard()
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
                    var agent = agentServices.Check(login.Email, login.password);
                    if (agent != null)
                    {
                        Session["agentid"] = agent.agentId;
                        return RedirectToAction("AgentDashboard");
                    }
                    else
                    {
                        ViewBag.message = "No agent found";
                        return View();
                    }
                }
                else
                {
                    ViewBag.message = "No agent found";
                    return View();
                }
            }
            catch (Exception)
            {

                return View("Error");
            }
        }
        [HttpGet, Route("registeragent")]
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

        [HttpPost, Route("registeragent")]
        public ActionResult Register(Agent agent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    agent.agentId = "A" + random.Next(1000);
                    agent.CreatedAt = DateTime.Now;
                    agent.UpdatedAt = DateTime.Now;
                    agent.status = "Pending";
                    agentServices.RegisterAgent(agent);
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

        [HttpGet, Route("bookhistory")]
        public ActionResult BookHistory()
        {
            try
            {
                string agentid = Session["agentid"].ToString();
                var bookings = agentServices.GetBookings(agentid);
                double total = 0;
                foreach (var item in bookings)
                {
                    total = total + item.CommissionEarned;
                }
                ViewBag.TotalCommission = total;
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

                agentServices.CancelBooking(bookingid);
                return RedirectToAction("BookHistory");
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("updatebooking")]
        public ActionResult UpdateBooking(string bookingid)
        {
            try
            {
                var booking = agentServices.GetBooking(bookingid);
                return View(booking);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpPost, Route("updatebooking")]
        public ActionResult UpdateBooking(AgentBooking booking)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    agentServices.UpdateBooking(booking);
                    return RedirectToAction("BookHistory");
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
                var flights = agentServices.GetFlights(source, destination);
                return View(flights);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet, Route("customerdetails")]
        public ActionResult CustomerDetails()
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

        [HttpGet, Route("savingdetails")]
        public ActionResult SavingDetails(Customer customer)
        {
            try
            {
                Session["customer"] = customer;
                return RedirectToAction("Searchflights");
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
                var flight = agentServices.flightdetails(flightnumber);
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
                Customer customer = (Customer)Session["customer"];

                string agentid = Session["agentid"].ToString();
                agentServices.AddBooking(customer, flightnumber, price, discount, flightdate, agentid);
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