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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_Sport_2ControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Sport_2")]
public class Sport_2Controller : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Sport_2/GetAllSports")]
public HttpResponseMessage GetAllSports ()
{
        // CAD, CEN, EN, returnValue
        Sport_2RESTCAD sport_2RESTCAD = null;
        SportCEN sportCEN = null;

        List<SportEN> sportEN = null;
        List<Sport_2DTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                sport_2RESTCAD = new Sport_2RESTCAD (session);
                sportCEN = new SportCEN (sport_2RESTCAD);

                // Data
                // TODO: paginación

                sportEN = sportCEN.GetAllSports (0, -1).ToList ();

                // Convert return
                if (sportEN != null) {
                        returnValue = new List<Sport_2DTOA>();
                        foreach (SportEN entry in sportEN)
                                returnValue.Add (Sport_2Assembler.Convert (entry, session));
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

























/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_Sport_2ControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
