using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class CountryController : Controller
    {
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Country(int idSport = 0, string typeCompetition="")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.typeCompetition = typeCompetition;
            if (typeCompetition.Equals("National")) {
                ViewBag.allCountries = competis.GetClubPlaces().ToList();
            } else
            {
                ViewBag.allCountries = competis.GetNationalPlaces().ToList();
            }
            return View();
        }
    }
}