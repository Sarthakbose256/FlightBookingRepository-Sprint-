using FlightBookingAppClient.Models;
using FlightBookingAppClient.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace FlightBookingAppClient.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {
        AdminServices adminServices;
        Random random;
        public AdminController()
        {
            adminServices = new AdminServices();
            random = new Random();  
        }


        [HttpGet, Route("flightschedule")]
        public ActionResult GetFlightSchedule()
        {
            try
            {
                var schedules = adminServices.FlightSchedules();
                return View(schedules);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet,Route("flightpassengers")]
        public ActionResult GetPassengers(string flightnumber)
        {
            try
            {
                var bookings = adminServices.GetFlightPassengers(flightnumber);
                return View(bookings);
            }
            catch (Exception)
            {
                return View("Error");

            }
        }

        [HttpGet,Route("updateschedule")]
        public ActionResult UpdateSchedule(string scheduleId)
        {
            try
            {
                var schedule = adminServices.GetScheduleById(scheduleId);
                return View(schedule);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpPost,Route("updateschedule")]
        public ActionResult UpdateSchedule(FlightSchedule flightSchedule)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    flightSchedule.Duration = flightSchedule.ArrivalTime - flightSchedule.DepartureTime;
                    adminServices.UpdateSchedule(flightSchedule);
                    return RedirectToAction("GetFlightSchedule");
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

        [HttpGet,Route("addschedule")]
        public ActionResult AddFlightSchedule()
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
        [HttpPost,Route("addschedule")]
        public ActionResult AddFlightSchedule(FlightSchedule flightSchedule)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    flightSchedule.ScheduleId = "SCH" + random.Next(100);
                    flightSchedule.Duration = flightSchedule.ArrivalTime - flightSchedule.DepartureTime;
                    adminServices.AddFlightSchedule(flightSchedule);
                    return RedirectToAction("GetFlightSchedule");
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

        [HttpGet,Route("agents")]
        public ActionResult GetAgents()
        {
            try
            {
                var agents = adminServices.GetAllAgents();
                return View(agents);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet,Route("approval")]
        public ActionResult Approve(string ApplicantId)
        {
            try
            {
                var agent = adminServices.GetAgent(ApplicantId);
                adminServices.ApproveAgent(agent);
                return RedirectToAction("GetAgents");
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet, Route("reject")]
        public ActionResult Reject(string ApplicantId)
        {
            var agent = adminServices.GetAgent(ApplicantId);
            adminServices.RejectAgent(agent);
            return RedirectToAction("GetAgents");
        }
        [Route("AdminDashboard")]
        public ActionResult AdminDashboard()
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
                    var admin = adminServices.Check(login.Email, login.password);
                    if (admin != null)
                    {

                        return RedirectToAction("AdminDashboard");
                    }
                    else
                    {
                        ViewBag.message = "No admin found";
                        return View();
                    }
                }
                else
                {
                    ViewBag.message = "No admin found";
                    return View();
                }
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet,Route("flights")]
        public ActionResult GetFlightDetails()
        {
            try
            {
                var flights = adminServices.Flights();
                return View(flights);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpGet,Route("add-discount")]
        public ActionResult AddDiscount(string flightnumber)
        {
            try
            {
                var flight = adminServices.flightdetails(flightnumber);
                return View(flight);
            }
            catch (Exception)
            {

                return View("Error");
            }
        }

        [HttpPost, Route("add-discount")]
        public ActionResult AddDiscount(FlightDetail flightDetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    adminServices.AddDiscount(flightDetail);
                    return RedirectToAction("GetFlightDetails");
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

    }
}