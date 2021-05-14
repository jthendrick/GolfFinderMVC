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
       
        private ScoreService CreateScoreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ScoreService(userId);
            return service;
        }

    }
}