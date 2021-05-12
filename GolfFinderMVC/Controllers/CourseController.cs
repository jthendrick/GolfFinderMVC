using GolfFinder_Models.Course_Models;
using GolfFinder_Service.Course_Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfFinderMVC.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            var model = service.GetCourses();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseAdd model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateCourseService();

            service.AddCourse(model);
            return RedirectToAction("Index");
        }
        public ActionResult Details (int id)
        {
            var svc = CreateCourseService();
            var model = svc.GetCourseById(id);
            return View(model);
        }

        private CourseService CreateCourseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CourseService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCourseService();
            var detail = service.GetCourseById(id);
            var model = new CourseEdit
            {
                CourseID = detail.CourseID,
                CourseName = detail.CourseName,
                CourseAddress = detail.CourseAddress,
                EighteenHoleCost = detail.EighteenHoleCost,
                NineHoleCost = detail.NineHoleCost,
                AlcoholFriendly = detail.AlcoholFriendly,
                BeginnerFriendly = detail.BeginnerFriendly
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CourseID != id)
            {
                ModelState.AddModelError("", "ID Mismatch!");
                return View(model);
            }

            var service = CreateCourseService();
            if (service.UpdateCourse(model))
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
            var svc = CreateCourseService();
            var model = svc.GetCourseById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCourse(int id)
        {
            var service = CreateCourseService();
            service.DeleteCourse(id);
            TempData["SaveResult"] = "Your note was deleted!";
            return RedirectToAction("Index");

        }

    }
}