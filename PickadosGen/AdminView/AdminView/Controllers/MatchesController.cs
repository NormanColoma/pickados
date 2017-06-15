using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class MatchesController : Controller
    {
        // GET: Matches
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Matches(int idRound = 0, int idSeason = 0, int idCompetition = 0, string countryName = "", int idSport = 0, string typeCompetition = "")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            SeasonCEN seasons = new SeasonCEN();
            RoundCEN rounds = new RoundCEN();
            Event_CEN events = new Event_CEN();
            List<Event_EN> allEvents = events.GetEventsByRound(idRound).ToList();
            List<MatchEN> allMatches = new List<MatchEN>();
            MatchCEN matches = new MatchCEN();
            ViewBag.country = countryName;
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.competition = competis.GetCompetitionById(idCompetition);
            ViewBag.season = seasons.GetSeasonByID(idSeason);
            ViewBag.typeCompetition = typeCompetition;
            ViewBag.round = rounds.ReadOID(idRound);
            foreach (Event_EN ev in allEvents)
            {
                allMatches.Add(matches.GetMatchById(ev.Id));
            }
            ViewBag.totalMatches = allMatches;
            return View();
        }
    }
}