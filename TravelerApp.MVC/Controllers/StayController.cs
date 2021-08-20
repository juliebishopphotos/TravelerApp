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
    public class StayController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StayService(userId);
            var model = service.GetStays();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StayCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateStayService();

            if (service.CreateStay(model))
            {
                TempData["SaveResult"] = "Lodging was created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateStayService();
            var model = svc.GetStayById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStayService();
            var detail = service.GetStayById(id);
            var model =
                new StayEdit
                {
                    StayId = detail.StayId,
                    Name = detail.Name,
                    Location = detail.Location,
                    TypeOfLodging = detail.TypeOfLodging
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StayEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.StayId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateStayService();

            if (service.UpdateStay(model))
            {
                TempData["SaveResult"] = "Lodging was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Lodging could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStayService();
            var model = svc.GetStayById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateStayService();

            service.DeleteStay(id);

            TempData["SaveResult"] = "Lodging was deleted.";

            return RedirectToAction("Index");
        }

        private StayService CreateStayService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StayService(userId);
            return service;
        }
    }
}