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
    [Authorize]
    public class EatController : Controller
    {
        // GET: Eat
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EatService(userId);
            var model = service.GetEats();

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
        public ActionResult Create(EatCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEatService();

            if (service.CreateEat(model))
            {
                TempData["SaveResult"] = "Restaurant was created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateEatService();
            var model = svc.GetEatById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateEatService();
            var detail = service.GetEatById(id);
            var model =
                new EatEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Location = detail.Location,
                    RestaurantTypeId = detail.RestaurantTypeId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EatEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateEatService();

            if (service.UpdateEat(model))
            {
                TempData["SaveResult"] = "Restaurant was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Restaurant could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateEatService(); 
            var model = svc.GetEatById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id) 
        {
            var service = CreateEatService();

            service.DeleteEat(id);

            TempData["SaveResult"] = "Your restaurant was deleted.";

            return RedirectToAction("Index");
        }

        private EatService CreateEatService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EatService(userId);
            return service;
        }
    }
}