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
    public class TripSeeController : Controller
    {
        public ActionResult Create()
        {
            {
                var tripservice = CreateTripService();
                var trips = tripservice.GetTrips();
                ViewBag.Trips = trips.ToList();

                var seeservice = CreateSeeService();
                var sees = seeservice.GetSees();
                ViewBag.Sees = sees.ToList();
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TripSeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTripSeeService();

            if (service.CreateTripSee(model))
            {
                TempData["SaveResult"] = "Attraction was added to your trip.";
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

                var seeservice = DeleteSeeService();
                var sees = seeservice.GetSees();
                ViewBag.Sees = sees.ToList();
            
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(TripSeeDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTripSeeService();

            if (service.DeleteTripSee(model))
            {
                TempData["SaveResult"] = "Attraction was deleted from your trip.";
                return RedirectToAction("Delete");
            };

            return View(model);
        }

        private TripSeeService CreateTripSeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripSeeService(userId);
            return service;
        }


        private TripService CreateTripService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripService(userId);
            return service;
        }

        private SeeService CreateSeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeeService(userId);
            return service;
        }

        private TripService DeleteTripService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripService(userId);
            return service;
        }

        private SeeService DeleteSeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeeService(userId);
            return service;
        }
    }
}