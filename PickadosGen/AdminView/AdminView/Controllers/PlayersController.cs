using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PlayerDetails(int idCompeti = 0, int idTeam =0, int idPlayer=0)
        {
            TeamCEN teams = new TeamCEN();
            CompetitionCEN competis = new CompetitionCEN();
            PlayerCEN players = new PlayerCEN();
            TeamEN team = teams.GetTeamById(idTeam);
            ViewBag.teamByPlayer = teams.GetClubTeamsByPlayer(idPlayer);
            PlayerEN player = players.GetPlayerById(idPlayer);
            ViewBag.allPlayers = players.GetPlayersByClubTeam(team.Name, 0, 200).ToList(); ;
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            var totalTeamsByCompeti = teams.GetTeamByCompetition(idCompeti);
            var totalTeams = teams.GetAllTeams(0, 2000);
            ViewBag.allCompetitions = new SelectList(compets, "id", "name", idCompeti);
            ViewBag.allTeamsByCompetition = new SelectList(totalTeamsByCompeti, "id", "name", idTeam);
            ViewBag.allTeams = new SelectList(totalTeams, "id", "name", idTeam);
            return View(player);
        }
    }
}