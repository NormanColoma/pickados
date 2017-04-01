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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_NationalTeamControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/NationalTeam")]
public class NationalTeamController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/NationalTeam/GetAllTeams")]
public HttpResponseMessage GetAllTeams ()
{
        // CAD, CEN, EN, returnValue
        NationalTeamRESTCAD nationalTeamRESTCAD = null;
        TeamCEN teamCEN = null;

        List<TeamEN> teamEN = null;
        List<NationalTeamDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                nationalTeamRESTCAD = new NationalTeamRESTCAD (session);
                teamCEN = new TeamCEN (nationalTeamRESTCAD);

                // Data
                // TODO: paginación

                teamEN = teamCEN.GetAllTeams (0, -1).ToList ();

                // Convert return
                if (teamEN != null) {
                        returnValue = new List<NationalTeamDTOA>();
                        foreach (TeamEN entry in teamEN)
                                returnValue.Add (NationalTeamAssembler.Convert (entry, session));
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
// [Route("{idNationalTeam}", Name="GetOIDNationalTeam")]

[Route ("~/api/NationalTeam/{idNationalTeam}")]

public HttpResponseMessage GetTeamById (int idNationalTeam)
{
        // CAD, CEN, EN, returnValue
        NationalTeamRESTCAD nationalTeamRESTCAD = null;
        TeamCEN teamCEN = null;
        TeamEN teamEN = null;
        NationalTeamDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                nationalTeamRESTCAD = new NationalTeamRESTCAD (session);
                teamCEN = new TeamCEN (nationalTeamRESTCAD);

                // Data
                teamEN = teamCEN.GetTeamById (idNationalTeam);

                // Convert return
                if (teamEN != null) {
                        returnValue = NationalTeamAssembler.Convert (teamEN, session);
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

















/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_NationalTeamControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
