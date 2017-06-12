using PickadosGenNHibernate.CEN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Calendar()
        {
            SportCEN sports = new SportCEN();
            ViewBag.allSports = sports.GetAllSports(0, 2000).ToList();
            return View();
        }
    }
}