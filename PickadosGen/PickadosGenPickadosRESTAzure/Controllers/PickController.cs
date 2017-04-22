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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_PickControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Pick")]
public class PickController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Pick/GetAllPicks")]
public HttpResponseMessage GetAllPicks ()
{
        // CAD, CEN, EN, returnValue
        PickRESTCAD pickRESTCAD = null;
        PickCEN pickCEN = null;

        List<PickEN> pickEN = null;
        List<PickDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                pickRESTCAD = new PickRESTCAD (session);
                pickCEN = new PickCEN (pickRESTCAD);

                // Data
                // TODO: paginación

                pickEN = pickCEN.GetAllPicks (0, -1).ToList ();

                // Convert return
                if (pickEN != null) {
                        returnValue = new List<PickDTOA>();
                        foreach (PickEN entry in pickEN)
                                returnValue.Add (PickAssembler.Convert (entry, session));
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


























/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_PickControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
