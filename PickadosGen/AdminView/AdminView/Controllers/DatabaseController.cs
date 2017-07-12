using Newtonsoft.Json.Linq;
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
    }
}