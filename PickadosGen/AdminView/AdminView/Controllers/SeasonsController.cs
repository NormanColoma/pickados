using PickadosGenNHibernate.CEN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class SeasonsController : Controller
    {
        // GET: Seasons
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Seasons(int idCompetition = 0, string countryName = "", int idSport = 0, string typeCompetition = "")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            SeasonCEN seasons = new SeasonCEN();
            ViewBag.country = countryName;
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.competition = competis.GetCompetitionById(idCompetition);
            ViewBag.allSeasons = seasons.GetSeasonByCompetition(idCompetition).ToList();
            ViewBag.typeCompetition = typeCompetition;
            return View();
        }
    }
}