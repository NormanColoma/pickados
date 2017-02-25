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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_TeamControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Team")]
public class TeamController : BasicController
{
// Voy a generar el readAll







[HttpGet]



[Route ("~/api/Team/{idTeam}/GetHomeOfEvent_home/")]

public HttpResponseMessage GetHomeOfEvent_home (int idMatch)
{
        // CAD, EN
        MatchRESTCAD matchRESTCAD = null;
        MatchEN matchEN = null;

        // returnValue
        TeamEN en = null;
        TeamDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                matchRESTCAD = new MatchRESTCAD (session);

                // Exists Match
                matchEN = matchRESTCAD.ReadOIDDefault (idMatch);
                if (matchEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Match#" + idMatch + " not found"));

                // Rol
                // TODO: paginación


                en = matchRESTCAD.GetHomeOfEvent_home (idMatch);

                // Convert return
                if (en != null) {
                        returnValue = TeamAssembler.Convert (en, session);
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
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}



[HttpGet]



[Route ("~/api/Team/{idTeam}/GetAwayOfEvent_away/")]

public HttpResponseMessage GetAwayOfEvent_away (int idMatch)
{
        // CAD, EN
        MatchRESTCAD matchRESTCAD = null;
        MatchEN matchEN = null;

        // returnValue
        TeamEN en = null;
        TeamDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                matchRESTCAD = new MatchRESTCAD (session);

                // Exists Match
                matchEN = matchRESTCAD.ReadOIDDefault (idMatch);
                if (matchEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Match#" + idMatch + " not found"));

                // Rol
                // TODO: paginación


                en = matchRESTCAD.GetAwayOfEvent_away (idMatch);

                // Convert return
                if (en != null) {
                        returnValue = TeamAssembler.Convert (en, session);
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
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}























/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_TeamControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
