using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class RoundController : Controller
    {
        // GET: Round
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Round(int idSeason = 0, int idCompetition = 0, string countryName = "", int idSport = 0, string typeCompetition = "")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            SeasonCEN seasons = new SeasonCEN();
            RoundCEN rounds = new RoundCEN();
            ViewBag.country = countryName;
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.competition = competis.GetCompetitionById(idCompetition);
            SeasonEN season = seasons.GetSeasonByID(idSeason);
            ViewBag.season = season;
            ViewBag.allRounds = rounds.GetRoundBySeason(idSeason).ToList();
            ViewBag.typeCompetition = typeCompetition;
            return View();
        }
    }
}