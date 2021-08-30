using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelerApp.Models;
using TravelerApp.Services;

namespace TravelerApp.MVC.Controllers
{
    public class TripStayController : Controller
    {
        public ActionResult Create()
        {
            {
                var tripservice = CreateTripService();
                var trips = tripservice.GetTrips();
                ViewBag.Trips = trips.ToList();

                var stayservice = CreateStayService();
                var stays = stayservice.GetStays();
                ViewBag.Stays = stays.ToList();
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TripStayCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTripStayService();

            if (service.CreateTripStay(model))
            {
                TempData["SaveResult"] = "Lodging was added to your trip.";
                return RedirectToAction("Create");
            };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete()
        {
            
                var tripservice = DeleteTripService();
                var trips = tripservice.GetTrips();
                ViewBag.Trips = trips.ToList();

                var stayservice = DeleteStayService();
                var stays = stayservice.GetStays();
                ViewBag.Stays = stays.ToList();
            
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(TripStayDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTripStayService();

            if (service.DeleteTripStay(model))
            {
                TempData["SaveResult"] = "Lodging was deleted from your trip.";
                return RedirectToAction("Delete");
            };

            return View(model);
        }

        private TripStayService CreateTripStayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripStayService(userId);
            return service;
        }

        private TripService CreateTripService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripService(userId);
            return service;
        }

        private StayService CreateStayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StayService(userId);
            return service;
        }

        private TripService DeleteTripService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripService(userId);
            return service;
        }

        private StayService DeleteStayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StayService(userId);
            return service;
        }
    }
}