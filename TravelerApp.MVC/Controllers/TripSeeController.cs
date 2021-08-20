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
                return RedirectToAction("Index");
            };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int tripId, int seeId)
        {
            var svc = CreateTripSeeService();
            var model = svc.GetTripSeeById(tripId, seeId);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int seeId)
        {
            var service = CreateTripSeeService();

            service.DeleteTripSee(seeId);

            TempData["SaveResult"] = "Attraction was deleted from your trip.";

            return RedirectToAction("Index");
        }

        private TripSeeService CreateTripSeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripSeeService(userId);
            return service;
        }
    }
}