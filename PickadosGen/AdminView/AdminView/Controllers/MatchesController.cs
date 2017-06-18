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
            CompetitionEN com = competis.GetCompetitionById(idCompetition);
            List<Event_EN> allEvents = events.GetEventsByRoundAndCompetition(idRound, idCompetition).ToList();
            List<MatchEN> allMatches = new List<MatchEN>();
            MatchCEN matches = new MatchCEN();
            ViewBag.country = countryName;
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.competition = competis.GetCompetitionById(idCompetition);
            ViewBag.season = seasons.GetSeasonByID(idSeason);
            ViewBag.typeCompetition = typeCompetition;
            ViewBag.round = rounds.ReadOID(idRound);
            foreach (Event_EN oneEv in allEvents)
            {
                allMatches.Add(matches.GetMatchById(oneEv.Id));
            }
            ViewBag.totalMatches = allMatches;
            return View();
        }

        public ActionResult Edit(int idMatch = 0, int idRound = 0, int idSeason = 0, int idCompetition = 0, string countryName = "", int idSport = 0, string typeCompetition = "")
        {
            MatchCEN matches = new MatchCEN();
            ViewBag.country = countryName;
            ViewBag.sport = idSport;
            ViewBag.competition = idCompetition;
            ViewBag.season = idSeason;
            ViewBag.typeCompetition = typeCompetition;
            ViewBag.round = idRound;
            MatchEN match = matches.GetMatchById(idMatch);
            return View(match);
        }

        [HttpPost]
        public ActionResult Edit(int idRound, int idSeason, int idCompetition, string countryName, int idSport, string typeCompetition, int id, FormCollection collection)
        {
            MatchCEN matches = new MatchCEN();
            MatchEN matchEdited = new MatchEN();
            matchEdited.Id = id;
            matchEdited.Stadium = collection["Stadium"].ToString();
            matchEdited.Date = DateTime.Parse(collection["Date"].ToString());
            matches.ModifyMatch(matchEdited.Id, matchEdited.Date, matchEdited.Stadium);
            return RedirectToAction("Matches", "Matches", new { idRound = idRound, idSeason = idSeason, idCompetition = idCompetition, countryName = countryName, idSport = idSport, typeCompetition = typeCompetition });
        }
    }
}