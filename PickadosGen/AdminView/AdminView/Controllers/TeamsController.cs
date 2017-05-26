using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class TeamsController : Controller
    {
        // GET: Players
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailsTeam(/*string id = ""*/int idTeam = 0, int idCompeti=0)
        {
            //string[] partes = id.Split('-');
            TeamCEN teams = new TeamCEN();
            CompetitionCEN competis = new CompetitionCEN();
            PlayerCEN players = new PlayerCEN();
            TeamEN team = teams.GetTeamById(idTeam);
            ViewBag.allPlayers = players.GetPlayersByClubTeam(team.Name, 0, 200).ToList();
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            var totalTeams = teams.GetTeamByCompetition(idCompeti);
            ViewBag.allCompetitions = new SelectList(compets, "id", "name", idCompeti);
            ViewBag.allCompetis = new SelectList(compets, "id", "name", idCompeti);
            ViewBag.allTeams = new SelectList(totalTeams, "id", "name", idTeam);
            ViewBag.competiByTeam = competis.GetCompetitionByTeam(idTeam).ToList();
            return View(team);
        }

        public ActionResult AddCompeti(int idNewCompet = 0, int idTeam = 0, int idCompeti = 0)
        {
            TeamCEN teams = new TeamCEN();
            CompetitionCEN competis = new CompetitionCEN();
            PlayerCEN players = new PlayerCEN();
            IList<int> totalCompetisOfTeam = new List<int>();
            TeamEN team = teams.GetTeamById(idTeam);
            ViewBag.allPlayers = players.GetPlayersByClubTeam(team.Name, 0, 200).ToList();
            totalCompetisOfTeam.Add(idNewCompet);
            teams.AddCompetition(idTeam, totalCompetisOfTeam);
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            var totalTeams = teams.GetTeamByCompetition(idCompeti);
            ViewBag.allCompetitions = new SelectList(compets, "id", "name", idCompeti);
            ViewBag.allCompetis = new SelectList(compets, "id", "name", idCompeti);
            ViewBag.allTeams = new SelectList(totalTeams, "id", "name", idTeam);
            ViewBag.competiByTeam = competis.GetCompetitionByTeam(idTeam).ToList();
            return View(team);
        }

        public ActionResult DeleteCompeti(int idOldCompet = 0, int idTeam = 0, int idCompeti = 0)
        {
            TeamCEN teams = new TeamCEN();
            CompetitionCEN competis = new CompetitionCEN();
            PlayerCEN players = new PlayerCEN();
            IList<int> totalCompetisOfTeam = new List<int>();
            TeamEN team = teams.GetTeamById(idTeam);
            ViewBag.allPlayers = players.GetPlayersByClubTeam(team.Name, 0, 200).ToList();
            totalCompetisOfTeam.Add(idOldCompet);
            teams.DeleteCompetition(idTeam, totalCompetisOfTeam);
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            var totalTeams = teams.GetTeamByCompetition(idCompeti);
            ViewBag.allCompetitions = new SelectList(compets, "id", "name", idCompeti);
            ViewBag.allCompetis = new SelectList(compets, "id", "name", idCompeti);
            ViewBag.allTeams = new SelectList(totalTeams, "id", "name", idTeam);
            ViewBag.competiByTeam = competis.GetCompetitionByTeam(idTeam).ToList();
            return View(team);
        }
    }
}