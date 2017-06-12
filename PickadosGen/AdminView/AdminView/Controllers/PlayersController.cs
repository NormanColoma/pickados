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

        public ActionResult Players(int idTeam = 0, int idCompetition = 0, string countryName = "", int idSport = 0, string typeCompetition="")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            TeamCEN teams = new TeamCEN();
            PlayerCEN players = new PlayerCEN();
            ViewBag.country = countryName;
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.competition = competis.GetCompetitionById(idCompetition);
            TeamEN team = teams.GetTeamById(idTeam);
            ViewBag.team = team;
            List<PlayerEN> totalPlayers = players.GetPlayersByClubTeam(team.Name, 0, 100).ToList();
            totalPlayers.AddRange(players.GetPlayersByNationalTeam(team.Name));
            ViewBag.allPlayers = totalPlayers;
            ViewBag.typeCompetition = typeCompetition;
            return View();
        }

        public ActionResult Edit(int idTeam = 0, int idCompetition = 0, string countryName = "", int idSport = 0, int idPlayer = 0, string typeCompetition="")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            TeamCEN teams = new TeamCEN();
            PlayerCEN players = new PlayerCEN();
            PlayerEN player = players.GetPlayerById(idPlayer);
            ViewBag.country = countryName;
            ViewBag.sport = idSport;
            ViewBag.competition = idCompetition;
            ViewBag.team = idTeam;
            ViewBag.typeCompetition = typeCompetition;
            return View(player);
        }

        [HttpPost]
        public ActionResult Edit(int idTeam, int idCompetition, string countryName, int idSport, string typeCompetition, int id, FormCollection collection)
        {
            PlayerCEN players = new PlayerCEN();
            PlayerEN player = new PlayerEN();
            player.Id = id;
            player.Name = collection["Name"].ToString();
            players.ModifyPlayer(player.Id, player.Name);
            return RedirectToAction("Players", "Players", new { idTeam = idTeam, idCompetition = idCompetition, countryName = countryName, idSport = idSport, typeCompetition = typeCompetition });
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix, string typeCompetition, string idSport)
        {
            PlayerCEN entities = new PlayerCEN();
            List<PlayerEN> total = new List<PlayerEN>();
            if (typeCompetition.Equals("National"))
            {
                total = entities.GetPlayersNoClubTeam(Convert.ToInt32(idSport)).ToList();
            } else
            {
                total = entities.GetPlayersNoNationalTeam(Convert.ToInt32(idSport)).ToList();
            }
            var teams = (from team in total
                         where team.Name.Contains(prefix)
                         select new
                         {
                             label = team.Name,
                             val = team.Id
                         }).ToList();

            return Json(teams);
        }

        [HttpPost]
        public ActionResult AddPlayerToTeam(string playerName, string playerId, int idTeam, int idCompetition, string countryName, int idSport, string typeCompetition)
        {
            PlayerCEN players = new PlayerCEN();
            if (typeCompetition.Equals("National")) {
                players.JoinClubTeam(Convert.ToInt32(playerId), idTeam);
            } else
            {
                players.JoinNationalTeam(Convert.ToInt32(playerId), idTeam);
            }
            return RedirectToAction("Players", "Players", new { idTeam = idTeam, idCompetition = idCompetition, countryName = countryName, idSport = idSport, typeCompetition = typeCompetition });
        }

        public ActionResult Unlink(int idTeam = 0, int idCompetition = 0, string countryName = "", int idSport = 0, int idPlayer=0, string typeCompetition = "")
        {
            PlayerCEN players = new PlayerCEN();
            if (typeCompetition.Equals("National"))
            {
                players.UnlinkClubTeam(idPlayer, idTeam);
            } else
            {
                players.UnlinkNationalTeam(idPlayer, idTeam);
            }
            return RedirectToAction("Players", "Players", new { idTeam = idTeam, idCompetition = idCompetition, countryName = countryName, idSport = idSport, typeCompetition = typeCompetition });
        }

        public ActionResult PlayerDetails(int idCompeti = 0, int idTeam = 0, int idPlayer = 0)
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