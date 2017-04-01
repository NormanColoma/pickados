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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_ClubTeamsControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/ClubTeams")]
public class ClubTeamsController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/ClubTeams/GetAllTeams")]
public HttpResponseMessage GetAllTeams ()
{
        // CAD, CEN, EN, returnValue
        ClubTeamsRESTCAD clubTeamsRESTCAD = null;
        TeamCEN teamCEN = null;

        List<TeamEN> teamEN = null;
        List<ClubTeamsDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                clubTeamsRESTCAD = new ClubTeamsRESTCAD (session);
                teamCEN = new TeamCEN (clubTeamsRESTCAD);

                // Data
                // TODO: paginación

                teamEN = teamCEN.GetAllTeams (0, -1).ToList ();

                // Convert return
                if (teamEN != null) {
                        returnValue = new List<ClubTeamsDTOA>();
                        foreach (TeamEN entry in teamEN)
                                returnValue.Add (ClubTeamsAssembler.Convert (entry, session));
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
// [Route("{idClubTeams}", Name="GetOIDClubTeams")]

[Route ("~/api/ClubTeams/{idClubTeams}")]

public HttpResponseMessage GetTeamById (int idClubTeams)
{
        // CAD, CEN, EN, returnValue
        ClubTeamsRESTCAD clubTeamsRESTCAD = null;
        TeamCEN teamCEN = null;
        TeamEN teamEN = null;
        ClubTeamsDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                clubTeamsRESTCAD = new ClubTeamsRESTCAD (session);
                teamCEN = new TeamCEN (clubTeamsRESTCAD);

                // Data
                teamEN = teamCEN.GetTeamById (idClubTeams);

                // Convert return
                if (teamEN != null) {
                        returnValue = ClubTeamsAssembler.Convert (teamEN, session);
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

        // Return 404 - Not found
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NotFound);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}

















/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_ClubTeamsControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
