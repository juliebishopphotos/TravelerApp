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
    public class TripEatController : Controller
    {
        public ActionResult Create()
        { 
            {
                var tripservice = CreateTripService();
                var trips = tripservice.GetTrips();
                ViewBag.Trips = trips.ToList();

                var eatservice = CreateEatService();
                var eats = eatservice.GetEats();
                ViewBag.Eats = eats.ToList();
            }
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TripEatCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTripEatService();

            if (service.CreateTripEat(model))
            {
                TempData["SaveResult"] = "Restaurant was added to your trip.";
                return RedirectToAction("Create");
            };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete() 
        {
            {
                var tripservice = DeleteTripService();
                var trips = tripservice.GetTrips();
                ViewBag.Trips = trips.ToList();

                var eatservice = DeleteEatService();
                var eats = eatservice.GetEats();
                ViewBag.Eats = eats.ToList();
            }
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(TripEatDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTripEatService();

            if (service.DeleteTripEat(model))
            {
                TempData["SaveResult"] = "Restaurant was deleted from your trip.";
                return RedirectToAction("Delete");
            };

            return View(model);
        }

        private TripEatService CreateTripEatService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripEatService(userId);
            return service;
        }

        private TripService CreateTripService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripService(userId);
            return service;
        }

        private EatService CreateEatService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EatService(userId);
            return service;
        }

        private TripService DeleteTripService() 
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripService(userId);
            return service;
        }

        private EatService DeleteEatService() 
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EatService(userId);
            return service;
        }
    }
}