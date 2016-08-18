using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Themes;

namespace Dcmg.CustomerDB.Controllers
{
    public class HomeController:Controller
    {
        [Themed]
        public ActionResult Index()
        {
            ViewBag.dt = DateTime.Now;
            return View();
        }
    }
}