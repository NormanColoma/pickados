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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_TipsterStatsControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/TipsterStats")]
public class TipsterStatsController : BasicController
{
// Voy a generar el readAll
// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadAll Generado a partir del serviceLink
[HttpGet]
[Route ("~/api/TipsterStats/GetAll")]

public HttpResponseMessage GetAll ()
{
        // CAD, CEN, EN, returnValue
        TipsterStatsRESTCAD tipsterStatsRESTCAD = null;
        TipsterCEN tipsterCEN = null;

        List<TipsterEN> tipsterEN = null;
        List<TipsterStatsDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                tipsterStatsRESTCAD = new TipsterStatsRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterStatsRESTCAD);

                // Data
                // paginación

                tipsterEN = tipsterCEN.GetAllTipsters (0, -1).ToList ();



                // Convert return
                if (tipsterEN != null) {
                        returnValue = new List<TipsterStatsDTOA>();
                        foreach (TipsterEN entry in tipsterEN)
                                returnValue.Add (TipsterStatsAssembler.Convert (entry, session));
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



























/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_TipsterStatsControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
