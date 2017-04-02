using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Teams()
        {
            return View();
        }

        public ActionResult DetailsTeam(int id = 0)
        {
            return View(id);
        }

        public ActionResult DetailsPlayer(int id = 0)
        {
            return View(id);
        }
    }
}