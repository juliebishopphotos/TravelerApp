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
                TempData["SaveResult"] = "Place to eat was add to trip.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int tripId, int eatId)
        {
            var svc = CreateTripEatService();
            var model = svc.GetTripEatById(tripId, eatId);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int eatId)
        {
            var service = CreateTripEatService();

            service.DeleteTripEat(eatId);

            TempData["SaveResult"] = "Place to eat was deleted from trip.";

            return RedirectToAction("Index");
        }

        private TripEatService CreateTripEatService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripEatService(userId);
            return service;
        }
    }
}