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
    public class SeeController : Controller
    {
        // GET: See
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeeService(userId);
            var model = service.GetSees();

            return View(model);
        }

        //Add method here VVVV
        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSeeService();

            if (service.CreateSee(model))
            {
                TempData["SaveResult"] = "Place to see was created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSeeService();
            var model = svc.GetSeeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSeeService();
            var detail = service.GetSeeById(id);
            var model =
                new SeeEdit
                {
                    SeeId = detail.SeeId,
                    Name = detail.Name,
                    Location = detail.Location,
                    Description= detail.Description
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SeeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSeeService();

            if (service.UpdateSee(model))
            {
                TempData["SaveResult"] = "Place to see was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Place to see could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSeeService();
            var model = svc.GetSeeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSeeService();

            service.DeleteSee(id);

            TempData["SaveResult"] = "Place to see was deleted.";

            return RedirectToAction("Index");
        }

        private SeeService CreateSeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SeeService(userId);
            return service;
        }
    }
}