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
            //TeamCEN teams = new TeamCEN();
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            compets.Insert(0, new CompetitionEN());
            //var totalTeams = teams.GetAllTeams(1, 2000);
            ViewBag.allCompetitions = new SelectList(compets, "id", "name");
            //ViewBag.allTeams = new SelectList(totalTeams, "id", "name");
            return View();
        }

        public ActionResult DetailsCompetition(int id=0)
        {
            CompetitionCEN competis = new CompetitionCEN();
            TeamCEN teams = new TeamCEN();
            CompetitionEN competi = competis.GetCompetitionById(id);
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            compets.Insert(0, new CompetitionEN());
            List<TeamEN> totalTeams = teams.GetTeamByCompetition(id).ToList();
            totalTeams.Insert(0, new TeamEN());
            ViewBag.allCompetitions = new SelectList(compets, "id", "name", id);
            ViewBag.allTeams = new SelectList(totalTeams, "id", "name");

            return View(competi);
        }

        [HttpPost]
        public ActionResult DetailsCompetition(int id, FormCollection collection)
        {
            CompetitionCEN competis = new CompetitionCEN();
            TeamCEN teams = new TeamCEN();
            CompetitionEN competi = competis.GetCompetitionById(id);
            competi.Name = collection["Name"].ToString();
            competi.Place = collection["Place"].ToString();
            competis.ModifyCompetition(id, competi.Name, competi.Place);
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            compets.Insert(0, new CompetitionEN());
            List<TeamEN> totalTeams = teams.GetTeamByCompetition(id).ToList();
            totalTeams.Insert(0, new TeamEN());
            ViewBag.allCompetitions = new SelectList(compets, "id", "name", id);
            ViewBag.allTeams = new SelectList(totalTeams, "id", "name");

            return View(competi);
        }

        public ActionResult DetailsTeam(string id = "")
        {
            string[] partes = id.Split('-');
            TeamCEN teams = new TeamCEN();
            CompetitionCEN competis = new CompetitionCEN();
            PlayerCEN players = new PlayerCEN();
            TeamEN team = teams.GetTeamById(Convert.ToInt32(partes[0]));
            ViewBag.allPlayers = players.GetPlayersByClubTeam(team.Name, 0, 200).ToList();
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            var totalTeams = teams.GetTeamByCompetition(Convert.ToInt32(partes[1]));
            ViewBag.allCompetitions = new SelectList(compets, "id", "name", Convert.ToInt32(partes[1]));
            ViewBag.allCompetis = new SelectList(compets, "id", "name", Convert.ToInt32(partes[1]));
            ViewBag.allTeams = new SelectList(totalTeams, "id", "name", Convert.ToInt32(partes[0]));
            ViewBag.competiByTeam = competis.GetCompetitionsByTeam(Convert.ToInt32(partes[0])).ToList();
            return View(team);
        }

        public ActionResult AddCompeti(int idNewCompet = 0, int idTeam=0, int idCompeti=0)
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
            ViewBag.competiByTeam = competis.GetCompetitionsByTeam(idTeam).ToList();
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
            ViewBag.competiByTeam = competis.GetCompetitionsByTeam(idTeam).ToList();
            return View(team);
        }
    }
}