using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using PickadosGenPickadosRESTAzure.DTO;
using PickadosGenPickadosRESTAzure.DTOA;
using PickadosGenPickadosRESTAzure.CAD;
using PickadosGenPickadosRESTAzure.Assemblers;
using PickadosGenPickadosRESTAzure.AssemblersDTO;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.CP.Pickados;
using System.Threading.Tasks;
using PickadosGenPickadosRESTAzureREST.DTO;
using Newtonsoft.Json;


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_MatchControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Match")]
public class MatchController : BasicController
{
        // Voy a generar el readAll


        [HttpGet]

        [Route("~/api/Match/odds")]
        public async Task<HttpResponseMessage> GetAllEvents(string from, string to, string match_id)
        {
            MatchJSON returnValue = null;

            try
            {
                var matchJSON = await GetMatch(from, to, match_id);
                returnValue = JsonConvert.DeserializeObject<List<MatchJSON>>(matchJSON).First<MatchJSON>();

                var eventsJSON = await GetEvents(from, to, match_id);

                List<OddJSON> odds = new List<OddJSON>();
                odds = JsonConvert.DeserializeObject<List<OddJSON>>(eventsJSON);
                returnValue.Odds = odds;
            }

            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(PickadosGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(PickadosGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 204 - Empty
            if (returnValue == null)
                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            // Return 200 - OK
            else return this.Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }

        private async Task<string> GetEvents(string from, string to, string match_id)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://apifootball.com/api/?action=get_odds&from=" + from + "&to=" + to + "&match_id=" + match_id + "&APIkey=a5dfecb261f17d6f3644e14059d5220bb043042c983b19102d3e74af46ead2fd");
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadAsStringAsync();
            return res;
        }

        private async Task<string> GetMatch(string from, string to, string match_id)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://apifootball.com/api/?action=get_events&from=" + from + "&to=" + to + "&match_id=" + match_id + "&APIkey=a5dfecb261f17d6f3644e14059d5220bb043042c983b19102d3e74af46ead2fd");
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadAsStringAsync();
            return res;
        }

























        /*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_MatchControllerAzure) ENABLED START*/
        // Meter las operaciones que invoquen a las CPs
        /*PROTECTED REGION END*/
    }
}
