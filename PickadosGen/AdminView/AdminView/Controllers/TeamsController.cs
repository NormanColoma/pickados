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

        public ActionResult Teams(int idCompetition = 0, string countryName = "", int idSport = 0, string typeCompetition = "")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            TeamCEN teams = new TeamCEN();
            ViewBag.country = countryName;
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.competition = competis.GetCompetitionById(idCompetition);
            ViewBag.allTeams = teams.GetTeamByCompetition(idCompetition).ToList();
            ViewBag.typeCompetition = typeCompetition;
            return View();
        }

        public ActionResult Edit(int idCompetition = 0, string countryName = "", int idSport = 0, int idTeam=0, string typeCompetition= "")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            TeamCEN teams = new TeamCEN();
            TeamEN team = teams.GetTeamById(idTeam);
            ViewBag.country = countryName;
            ViewBag.sport = idSport;
            ViewBag.competition = idCompetition;
            ViewBag.typeCompetition = typeCompetition;
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(int idCompetition, string countryName, int idSport, string typeCompetition, int id, FormCollection collection)
        {
            TeamCEN teams = new TeamCEN();
            TeamEN team = new TeamEN();
            bool nacint = false;
            team.Id = id;
            team.Name = collection["Name"].ToString();
            team.Country = collection["Country"].ToString();
            if(typeCompetition.Equals("National"))
            {
                nacint = true;
            }
            teams.ModifyTeam(team.Id, team.Name, team.Country, nacint);
            return RedirectToAction("Teams", "Teams", new { idCompetition = idCompetition, countryName = countryName, idSport = idSport, typeCompetition = typeCompetition });
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix, string typeCompetition)
        {
            TeamCEN entities = new TeamCEN();
            List<TeamEN> total = new List<TeamEN>();
            if (typeCompetition.Equals("National"))
            {
                total = entities.GetNationalTeams().ToList();
            } else
            {
                total = entities.GetInternationalTeam().ToList();
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
        public ActionResult AddTeamToCompetition(string teamName, string teamId, int idCompetition, string countryName="", int idSport = 0, string typeCompetition = "")
        {
            TeamCEN teams = new TeamCEN();
            List<int> newCompetitions = new List<int>();
            newCompetitions.Add(idCompetition);
            teams.AddCompetition(Convert.ToInt32(teamId), newCompetitions);
            return RedirectToAction("Teams", "Teams", new { idCompetition = idCompetition, countryName = countryName, idSport = idSport, typeCompetition = typeCompetition });
        }

        public ActionResult Unlink(int idCompetition = 0, string countryName = "", int idSport = 0, int idTeam = 0, string typeCompetition = "")
        {
            TeamCEN teams = new TeamCEN();
            List<int> oldCompetitions = new List<int>();
            oldCompetitions.Add(idCompetition);
            teams.DeleteCompetition(idTeam, oldCompetitions);
            return RedirectToAction("Teams", "Teams", new { idCompetition = idCompetition, countryName = countryName, idSport = idSport, typeCompetition = typeCompetition });
        }
    }
}