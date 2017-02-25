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



[Route ("~/api/Match/{idMatch}/GetAllEventOfCompetition/")]

public HttpResponseMessage GetAllEventOfCompetition (int idCompetition)
{
        // CAD, EN
        CompetitionRESTCAD competitionRESTCAD = null;
        CompetitionEN competitionEN = null;

        // returnValue
        List<MatchEN> en = null;
        List<MatchDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                competitionRESTCAD = new CompetitionRESTCAD (session);

                // Exists Competition
                competitionEN = competitionRESTCAD.ReadOIDDefault (idCompetition);
                if (competitionEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Competition#" + idCompetition + " not found"));

                // Rol
                // TODO: paginación


                en = competitionRESTCAD.GetAllEventOfCompetition (idCompetition).ToList ();

                // Convert return
                if (en != null) {
                        returnValue = new List<MatchDTOA>();
                        foreach (MatchEN entry in en)
                                returnValue.Add (MatchAssembler.Convert (entry, session));
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























/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_MatchControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
