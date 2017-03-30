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
















[HttpPost]


[Route ("~/api/Team/NewTeam")]




public HttpResponseMessage NewTeam ( [FromBody] TeamDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        TeamRESTCAD teamRESTCAD = null;
        TeamCEN teamCEN = null;
        TeamDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                teamRESTCAD = new TeamRESTCAD (session);
                teamCEN = new TeamCEN (teamRESTCAD);

                // Create
                returnOID = teamCEN.NewTeam (

                        dto.Name

                        ,

                        dto.Country

                        );
                SessionCommit ();

                // Convert return
                returnValue = TeamAssembler.Convert (teamRESTCAD.ReadOIDDefault (returnOID), session);
        }

        catch (Exception e)
        {
                SessionRollBack ();

                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(PickadosGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(PickadosGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 201 - Created
        response = this.Request.CreateResponse (HttpStatusCode.Created, returnValue);

        // Location Header
        /*
         * Dictionary<string, object> routeValues = new Dictionary<string, object>();
         *
         * // TODO: y rolPaths
         * routeValues.Add("id", returnOID);
         *
         * uri = Url.Link("GetOIDTeam", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}





[HttpPut]

[Route ("~/api/Match/{idMatch}/GetHomeOfEvent_home/{idTeam}/")]
[Route ("~/api/Match/{idMatch}/GetAwayOfEvent_away/{idTeam}/")]

public HttpResponseMessage ModifyTeam (int idTeam, [FromBody] TeamDTO dto)
{
        // CAD, CEN, returnValue
        TeamRESTCAD teamRESTCAD = null;
        TeamCEN teamCEN = null;
        TeamDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                teamRESTCAD = new TeamRESTCAD (session);
                teamCEN = new TeamCEN (teamRESTCAD);

                // Modify
                teamCEN.ModifyTeam (idTeam,
                        dto.Name
                        ,
                        dto.Country
                        );

                // Return modified object
                returnValue = TeamAssembler.Convert (teamRESTCAD.ReadOIDDefault (idTeam), session);

                SessionCommit ();
        }

        catch (Exception e)
        {
                SessionRollBack ();

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
        else{
                response = this.Request.CreateResponse (HttpStatusCode.OK, returnValue);

                return response;
        }
}





[HttpDelete]

[Route ("~/api/Match/{idMatch}/GetHomeOfEvent_home/{idTeam}/")]
[Route ("~/api/Match/{idMatch}/GetAwayOfEvent_away/{idTeam}/")]

public HttpResponseMessage DeleteTeam (int idTeam)
{
        // CAD, CEN
        TeamRESTCAD teamRESTCAD = null;
        TeamCEN teamCEN = null;

        try
        {
                SessionInitializeTransaction ();
                teamRESTCAD = new TeamRESTCAD (session);
                teamCEN = new TeamCEN (teamRESTCAD);

                teamCEN.DeleteTeam (idTeam);
                SessionCommit ();
        }

        catch (Exception e)
        {
                SessionRollBack ();

                if (e.GetType () == typeof(HttpResponseException)) throw e;
                else if (e.GetType () == typeof(PickadosGenNHibernate.Exceptions.ModelException) || e.GetType () == typeof(PickadosGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException (HttpStatusCode.BadRequest);
                else throw new HttpResponseException (HttpStatusCode.InternalServerError);
        }
        finally
        {
                SessionClose ();
        }

        // Return 204 - No Content
        return this.Request.CreateResponse (HttpStatusCode.NoContent);
}






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_TeamControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
