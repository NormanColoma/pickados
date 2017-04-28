using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
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
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToRoute("Login");
            }
            return View();
        }

        public ActionResult Competitions(int id = 0)
        {
            CompetitionCEN competis = new CompetitionCEN();
            TeamCEN teams = new TeamCEN();
            var totalCompetis = competis.GetAllCompetitions(1, 2000).OrderBy(p => p.Place);
            var totalTeams = teams.GetTeamByCompetition(id);
            ViewBag.allCompetitions = totalCompetis;
            ViewBag.allTeams = totalTeams;
            
            return View();
        }

        public ActionResult DetailsTeam(int id = 0)
        {
            if (id != 0)
            {
                TeamCEN team = new TeamCEN();
                PlayerCEN player = new PlayerCEN();
                var totalTeams = team.GetTeamByCompetition(id).OrderBy(p => p.Name);
                ViewBag.allTeams = totalTeams;
                TeamEN teamToSearch = team.GetTeamById(id);
                ViewBag.team = teamToSearch;
                ViewBag.players = player.GetPlayersByClubTeam(teamToSearch.Name, 1, 20000);
            }
            return View();
        }

        public ActionResult DetailsPlayer(int id = 0)
        {
            return View(id);
        }
    }
}