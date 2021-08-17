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
    public class RestaurantTypeController : Controller
    {

        // GET: RestaurantType
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestaurantTypeService(userId);
            var model = service.GetRestaurantTypes();

            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantTypeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateRestaurantTypeService();

            if (service.CreateEat(model))
            {
                TempData["SaveResult"] = "Your restaurant description were added.";
                return RedirectToAction("Index");
            };

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRestaurantTypeService();
            var model = svc.GetRestaurantTypeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateRestaurantTypeService();
            var detail = service.GetRestaurantTypeById(id);
            var model =
                new RestaurantTypeEdit
                {
                    RestaurantTypeId = detail.RestaurantTypeId,
                    Description = detail.Description,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RestaurantTypeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RestaurantTypeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRestaurantTypeService();

            if (service.UpdateRestaurantType(model))
            {
                TempData["SaveResult"] = "Restaurant description was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Restaurant description could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRestaurantTypeService();
            var model = svc.GetRestaurantTypeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRestaurantTypeService();

            service.DeleteRestaurantType(id);

            TempData["SaveResult"] = "Your restaurant description was deleted.";

            return RedirectToAction("Index");
        }


        private RestaurantTypeService CreateRestaurantTypeService() 
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RestaurantTypeService(userId);
            return service;
        }
    }
}