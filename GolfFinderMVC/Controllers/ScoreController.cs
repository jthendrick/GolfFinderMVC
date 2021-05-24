using GolfFinder_Models.Score_Models;
using GolfFinder_Service.Score_Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfFinderMVC.Controllers
{
    [Authorize]
    public class ScoreController : Controller
    {
        // GET: Score
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoreService(userId);
            var model = service.GetScores();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ScoreAdd model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateScoreService();

            service.AddScore(model);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var svc = CreateScoreService();
            var model = svc.GetScoreByID(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateScoreService();
            var detail = service.GetScoreByID(id);
            var model = new ScoreEdit
            {
                Hole1 = detail.Hole1,
                ParHole1 = detail.ParHole1,
                Hole2 = detail.Hole2,
                ParHole2 = detail.ParHole2,
                Hole3 = detail.Hole3,
                ParHole3 = detail.ParHole3,
                Hole4 = detail.Hole4,
                ParHole4 = detail.ParHole4,
                Hole5 = detail.Hole5,
                ParHole5 = detail.ParHole5,
                Hole6 = detail.Hole6,
                ParHole6 = detail.ParHole6,
                Hole7 = detail.Hole7,
                ParHole7 = detail.ParHole7,
                Hole8 = detail.Hole8,
                ParHole8 = detail.ParHole8,
                Hole9 = detail.Hole9,
                ParHole9 = detail.ParHole9,
                Hole10 = detail.Hole10,
                ParHole10 = detail.ParHole10,
                Hole11 = detail.Hole11,
                ParHole11 = detail.ParHole11,
                Hole12 = detail.Hole12,
                ParHole12 = detail.ParHole12,
                Hole13 = detail.Hole13,
                ParHole13 = detail.ParHole13,
                Hole14 = detail.Hole14,
                ParHole14 = detail.ParHole14,
                Hole15 = detail.Hole15,
                ParHole15 = detail.ParHole15,
                Hole16 = detail.Hole16,
                ParHole16 = detail.ParHole16,
                Hole17 = detail.Hole17,
                ParHole17 = detail.ParHole17,
                Hole18 = detail.Hole18,
                ParHole18 = detail.ParHole18

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ScoreEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            //if (model.ScoreID != id)
            //{
            //    ModelState.AddModelError("", "ID Mismatch!");
            //    return View(model);
            //}

            var service = CreateScoreService();
            if (service.UpdateScore(model))
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
            var svc = CreateScoreService();
            var model = svc.GetScoreByID(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteScore(int id)
        {
            var service = CreateScoreService();
            service.DeleteScore(id);
            TempData["SaveResult"] = "Your note was deleted!";
            return RedirectToAction("Index");

        }

        private ScoreService CreateScoreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoreService(userId);
            return service;
        }

    }
}