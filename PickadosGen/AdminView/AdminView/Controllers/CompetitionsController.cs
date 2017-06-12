using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminView.Controllers
{
    public class CompetitionsController : Controller
    {
        // GET: Competitions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Competitions(string countryName = "", int idSport=0, string typeCompetition="")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            ViewBag.country = countryName;
            ViewBag.sport = sports.GetSportById(idSport);
            ViewBag.typeCompetition = typeCompetition;
            ViewBag.allCompetitions = competis.GetCompetitionBySport(idSport).Where(p => p.Place.Equals(countryName)).OrderBy(p => p.Name).ToList();
            return View();
        }

        public ActionResult Edit(string countryName = "", int idSport = 0, int idCompetition=0, string typeCompetition = "")
        {
            CompetitionCEN competis = new CompetitionCEN();
            SportCEN sports = new SportCEN();
            TeamCEN teams = new TeamCEN();
            CompetitionEN competition = competis.GetCompetitionById(idCompetition);
            ViewBag.country = countryName;
            ViewBag.idSport = idSport;
            ViewBag.allTeams = teams.GetTeamByCompetition(idCompetition).OrderBy(c => c.Name);
            ViewBag.typeCompetition = typeCompetition;
            return View(competition);
        }

        [HttpPost]
        public ActionResult Edit(string countryName, int idSport, string typeCompetition, int id, FormCollection collection)
        {
            CompetitionCEN competis = new CompetitionCEN();
            CompetitionEN competitionEdited = new CompetitionEN();
            bool nacint = false;
            competitionEdited.Id = id;
            competitionEdited.Name = collection["Name"].ToString();
            competitionEdited.Place = collection["Place"].ToString();
            if(typeCompetition.Equals("National"))
            {
                nacint = true;
            }
            competis.ModifyCompetition(competitionEdited.Id, competitionEdited.Name, competitionEdited.Place, nacint);
            //ViewBag.allCompetitions = competis.GetCompetitionBySport(idSport).Where(p => p.Place.Equals(countryName)).OrderBy(p => p.Name).ToList();
            return RedirectToAction("Competitions", "Competitions", new { countryName = countryName, idSport = idSport, typeCompetition = typeCompetition });
        }

        public ActionResult DetailsCompetition(int id = 0)
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
            competis.ModifyCompetition(id, competi.Name, competi.Place, true);
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            compets.Insert(0, new CompetitionEN());
            List<TeamEN> totalTeams = teams.GetTeamByCompetition(id).ToList();
            totalTeams.Insert(0, new TeamEN());
            ViewBag.allCompetitions = new SelectList(compets, "id", "name", id);
            ViewBag.allTeams = new SelectList(totalTeams, "id", "name");

            return View(competi);
        }
    }
}