using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GolfFinderMVC.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Maps()
        {
            return View();
        }
    }
}