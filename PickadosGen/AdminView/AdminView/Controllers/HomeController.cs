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

        public ActionResult Teams()
        {
            TeamCEN teams = new TeamCEN();
            var totalTeams = teams.GetAllTeams(1, 2000).OrderBy(p => p.Country);
            ViewBag.allTeams = totalTeams;
            return View();
        }

        public ActionResult DetailsTeam(int id = 0)
        {
            if (id != 0)
            {
                TeamCEN team = new TeamCEN();
                PlayerCEN player = new PlayerCEN();
                var totalTeams = team.GetAllTeams(1, 2000).OrderBy(p => p.Country);
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