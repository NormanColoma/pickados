using PickadosGenNHibernate.CEN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class CompetiCalendarController : Controller
    {
        // GET: CompetiCalendar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompetiCalendar(string countryName = "", int idSport = 0, string typeCompetition = "")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            ViewBag.country = countryName;
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.typeCompetition = typeCompetition;
            ViewBag.allCompetitions = competis.GetCompetitionBySport(idSport).Where(p => p.Place.Equals(countryName)).OrderBy(p => p.Name).ToList();
            return View();
        }
    }
}