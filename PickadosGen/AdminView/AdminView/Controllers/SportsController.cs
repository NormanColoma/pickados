using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class SportsController : Controller
    {
        // GET: Sport
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sports()
        {
            SportCEN sports = new SportCEN();
            ViewBag.allSports = sports.GetAllSports(0, 2000).ToList();
            return View();
        }

        public ActionResult Edit(int idSport = 0)
        {
            SportCEN sports = new SportCEN();
            SportEN sport = sports.GetSportById(idSport);
            ViewBag.sportImage = sport.Image;
            return View(sport);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            SportEN sportEdited = new SportEN();
            sportEdited.Id = id;
            sportEdited.Name = collection["Name"].ToString();
            sportEdited.Image = collection["Image"].ToString();
            SportCEN sports = new SportCEN();
            sports.ModifySport(sportEdited.Id, sportEdited.Name, sportEdited.Image);
            return RedirectToAction("Sports");
        }

        public ActionResult DetailsSport(int id = 0)
        {
            SportCEN sports = new SportCEN();
            CompetitionCEN competis = new CompetitionCEN();
            SportEN sport = sports.GetSportById(id);
            List<SportEN> sportList = sports.GetAllSports(0, 2000).ToList();
            sportList.Insert(0, new SportEN());
            List<String> countries = competis.GetPlaces().ToList();
            countries.Insert(0, "");
            ViewBag.allSports = new SelectList(sportList, "id", "name", id);
            ViewBag.allCountries = new SelectList(countries);
            ViewBag.allCompetitionsBySport = competis.GetCompetitionBySport(id).ToList();
            return View(sport);
        }

        public ActionResult DetailsSportCountry(int idSport = 0, string country = "")
        {
            SportCEN sports = new SportCEN();
            CompetitionCEN competis = new CompetitionCEN();
            SportEN sport = sports.GetSportById(idSport);
            List<SportEN> sportList = sports.GetAllSports(0, 2000).ToList();
            sportList.Insert(0, new SportEN());
            List<String> countries = competis.GetPlaces().ToList();
            countries.Insert(0, "");
            ViewBag.allSports = new SelectList(sportList, "id", "name", idSport);
            ViewBag.allCountries = new SelectList(countries, country);
            ViewBag.allCompetitionsBySport = competis.GetCompetitionBySport(idSport).Where(p => p.Place.Equals(country)).ToList();
            return View(sport);
        }
    }
}