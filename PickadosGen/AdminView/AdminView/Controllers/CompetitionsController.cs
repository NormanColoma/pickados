using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class CompetitionsController : Controller
    {
        // GET: Competitions
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Competitions(int id = 0)
        {
            CompetitionCEN competis = new CompetitionCEN();
            List<CompetitionEN> compets = competis.GetAllCompetitions(0, 2000).ToList();
            compets.Insert(0, new CompetitionEN());
            ViewBag.allCompetitions = new SelectList(compets, "id", "name");
            return View();
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
            competis.ModifyCompetition(id, competi.Name, competi.Place);
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