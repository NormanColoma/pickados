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
using Newtonsoft.Json.Linq;
using PickadosGenPickadosRESTAzureREST.DTO;
using System.Web.Script.Serialization;


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_SportControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Sport")]
public class SportController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Sport/GetAllSports")]
public HttpResponseMessage GetAllSports ()
{
        // CAD, CEN, EN, returnValue
        SportRESTCAD sportRESTCAD = null;
        SportCEN sportCEN = null;

        List<SportEN> sportEN = null;
        List<SportDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                sportRESTCAD = new SportRESTCAD (session);
                sportCEN = new SportCEN (sportRESTCAD);

                // Data
                // TODO: paginación

                sportEN = sportCEN.GetAllSports (0, -1).ToList ();

                // Convert return
                if (sportEN != null) {
                        returnValue = new List<SportDTOA>();
                        foreach (SportEN entry in sportEN)
                                returnValue.Add (SportAssembler.Convert (entry, session));
                }
        }

        catch (Exception e)
        {
                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(PickadosGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(PickadosGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 204 - Empty
        if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}

        [HttpGet]
    
        [Route("~/api/events")]
        public async Task<HttpResponseMessage> GetAllEvents(string from, string to)
        {
            string returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();
                var result = await GetEvents(from, to);
                
                returnValue = result;
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

        private async Task<string> GetEvents(string from, string to)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://apifootball.com/api/?action=get_events&from="+ from + "&to="+to+"&APIkey=a5dfecb261f17d6f3644e14059d5220bb043042c983b19102d3e74af46ead2fd");
            response.EnsureSuccessStatusCode();
            var res = await response.Content.ReadAsStringAsync();
            return res;
        }

























        /*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_SportControllerAzure) ENABLED START*/
        // Meter las operaciones que invoquen a las CPs
        /*PROTECTED REGION END*/
    }
}
