using Newtonsoft.Json.Linq;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class DatabaseController : Controller
    {
        private string apikey = "a5dfecb261f17d6f3644e14059d5220bb043042c983b19102d3e74af46ead2fd";
        // GET: Database
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JArray CargarDatos(string categoria)
        {
            switch(categoria)
            {
                case "competiciones":
                    return CargarCompeticionesFutbol();
                default:
                    return new JArray();
            }
        }

        private JArray CargarCompeticionesFutbol()
        {
            WebRequest request = WebRequest.Create("https://apifootball.com/api/?action=get_leagues&APIkey=" + apikey);
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent = "pickados";

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string competiciones = reader.ReadToEnd();
            JArray json = JArray.Parse(competiciones);
            JArray sorted = new JArray(json.OrderBy(obj => obj["country_name"]));

            response.Close();

            return sorted;
        }

        [HttpPost]
        public ActionResult CargarCompeticionesFutbol(string json, string club)
        {
            bool club_team = true;
            if (club.Equals("0"))
                club_team = false;

            JObject jobject = JObject.Parse(json);

            string place = jobject.GetValue("name").ToString();

            JArray jarray = JArray.Parse(jobject.GetValue("leagues").ToString());

            SportCEN sportCEN = new SportCEN();
            int sport = sportCEN.NewSport("Football", "https://cdn0.iconfinder.com/data/icons/stroke-ball-icons-2/633/02_Soccer-512.png");

            SeasonCEN seasonCEN = new SeasonCEN();
            int season1 = seasonCEN.NewSeason(new DateTime(2016, 8, 18), new DateTime(2017, 5, 19));

            List<int> seasons = new List<int>(); seasons.Add(season1);

            foreach (JObject league_json in jarray)
            {
                string league = league_json.GetValue("value").ToString();
                
                CompetitionCEN compCEN = new CompetitionCEN();
                compCEN.NewCompetition(league, sport, place, club_team, seasons);
            }
            return null;
        }
    }
}