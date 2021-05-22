using GolfFinder_Models.Rating_Models;
using GolfFinder_Service.Rating_Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfFinderMVC.Controllers
{
    [Authorize]
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            var model = service.GetRatings();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RatingAdd model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRatingService();

            service.AddRating(model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);
            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var service = CreateRatingService();
            var detail = service.GetRatingById(id);
            var model = new RatingEdit
            {
                RatingID = detail.RatingID,
                Amenities = detail.Amenities,
                Cleanliness = detail.Cleanliness,
                Dificulty = detail.Dificulty,
                Layout = detail.Layout,
              
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RatingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.RatingID != id)
            {
                ModelState.AddModelError("", "ID Mismatch!");
                return View(model);
            }

            var service = CreateRatingService();
            if (service.UpdateRating(model))
            {
                TempData["SaveResult"] = "Your course was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your course could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRatingService();
            var model = svc.GetRatingById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRating(int id)
        {
            var service = CreateRatingService();
            service.DeleteRating(id);
            TempData["SaveResult"] = "Your note was deleted!";
            return RedirectToAction("Index");

        }
        private RatingService CreateRatingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RatingService(userId);
            return service;
        }
    }
}