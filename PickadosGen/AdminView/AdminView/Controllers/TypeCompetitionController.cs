using PickadosGenNHibernate.CEN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class TypeCompetitionController : Controller
    {
        // GET: TypeCompetition
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TypeCompetition(int idSport = 0)
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.allCountries = competis.GetPlaces().ToList();
            return View();
        }
    }
}