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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_PlayerControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Player")]
public class PlayerController : BasicController
{
// Voy a generar el readAll



// ReadAll Generado a partir del NavigationalOperation
[HttpGet]

[Route ("~/api/Player/GetAllPlayers")]
public HttpResponseMessage GetAllPlayers ()
{
        // CAD, CEN, EN, returnValue
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;

        List<PlayerEN> playerEN = null;
        List<PlayerDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // Data
                // TODO: paginación

                playerEN = playerCEN.GetAllPlayers (0, -1).ToList ();

                // Convert return
                if (playerEN != null) {
                        returnValue = new List<PlayerDTOA>();
                        foreach (PlayerEN entry in playerEN)
                                returnValue.Add (PlayerAssembler.Convert (entry, session));
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











// No pasa el slEnables: getPlayersByClubTeam

[HttpGet]

[Route ("~/api/Player/GetPlayersByClubTeam")]

public HttpResponseMessage GetPlayersByClubTeam (string p_clubteam_name)
{
        // CAD, CEN, EN, returnValue

        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;


        System.Collections.Generic.List<PlayerEN> en;

        System.Collections.Generic.List<PlayerDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // CEN return



                en = playerCEN.GetPlayersByClubTeam (p_clubteam_name).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PlayerDTOA>();
                        foreach (PlayerEN entry in en)
                                returnValue.Add (PlayerAssembler.Convert (entry, session));
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


// No pasa el slEnables: getPlayersByNationalTeam

[HttpGet]

[Route ("~/api/Player/GetPlayersByNationalTeam")]

public HttpResponseMessage GetPlayersByNationalTeam (string p_nationalteam_name)
{
        // CAD, CEN, EN, returnValue

        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;


        System.Collections.Generic.List<PlayerEN> en;

        System.Collections.Generic.List<PlayerDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // CEN return



                en = playerCEN.GetPlayersByNationalTeam (p_nationalteam_name).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PlayerDTOA>();
                        foreach (PlayerEN entry in en)
                                returnValue.Add (PlayerAssembler.Convert (entry, session));
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
















/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_PlayerControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
