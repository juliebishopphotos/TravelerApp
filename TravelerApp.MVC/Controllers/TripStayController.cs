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
                TempData["SaveResult"] = "Place to stay was add to trip.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int tripId, int stayId)
        {
            var svc = CreateTripStayService();
            var model = svc.GetTripStayById(tripId, stayId);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int stayId)
        {
            var service = CreateTripStayService();

            service.DeleteTripStay(stayId);

            TempData["SaveResult"] = "Place to stay was deleted from trip.";

            return RedirectToAction("Index");
        }

        private TripStayService CreateTripStayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TripStayService(userId);
            return service;
        }
    }
}