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
            Event_CEN events = new Event_CEN();
            List<Event_EN> allEvents = events.GetEventsByRound(idRound).ToList();
            List<MatchEN> allMatches = new List<MatchEN>();
            MatchCEN matches = new MatchCEN();
            foreach(Event_EN ev in allEvents)
            {
                allMatches.Add(matches.GetMatchById(ev.Id));
            }
            ViewBag.totalMatches = allMatches;
            return View();
        }
    }
}