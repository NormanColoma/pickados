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













[HttpGet]
// [Route("{idPlayer}", Name="GetOIDPlayer")]

[Route ("~/api/Player/{idPlayer}")]

public HttpResponseMessage GetPlayerById (int idPlayer)
{
        // CAD, CEN, EN, returnValue
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;
        PlayerEN playerEN = null;
        PlayerDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // Data
                playerEN = playerCEN.GetPlayerById (idPlayer);

                // Convert return
                if (playerEN != null) {
                        returnValue = PlayerAssembler.Convert (playerEN, session);
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


// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadFilter Generado a partir del serviceLink

[HttpGet]

[Route ("~/api/Player/Player_getPlayersByClubTeam")]

public HttpResponseMessage Player_getPlayersByClubTeam (string p_clubteam_name, int first)
{
        // CAD, CEN, EN, returnValue

        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;

        System.Collections.Generic.List<PlayerEN> en;
        List<PlayerDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);


                // CEN return


                // paginación

                en = playerCEN.GetPlayersByClubTeam (p_clubteam_name).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<PlayerDTOA>();
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




// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadFilter Generado a partir del serviceLink

[HttpGet]

[Route ("~/api/Player/Player_getPlayersByNationalTeam")]

public HttpResponseMessage Player_getPlayersByNationalTeam (string p_nationalteam_name)
{
        // CAD, CEN, EN, returnValue

        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;

        System.Collections.Generic.List<PlayerEN> en;
        List<PlayerDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);


                // CEN return


                // paginación

                en = playerCEN.GetPlayersByNationalTeam (p_nationalteam_name).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<PlayerDTOA>();
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






[HttpPost]


[Route ("~/api/Player/NewPlayer")]




public HttpResponseMessage NewPlayer ( [FromBody] PlayerDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;
        PlayerDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // Create
                returnOID = playerCEN.NewPlayer (

                        dto.Name

                        );
                SessionCommit ();

                // Convert return
                returnValue = PlayerAssembler.Convert (playerRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDPlayer", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}





[HttpPut]

[Route ("~/api/ClubTeams/{idClubTeams}/GetAllClub_playerOfClub_team/{idPlayer}/")]
[Route ("~/api/NationalTeam/{idNationalTeam}/GetAllNational_playerOfNational_team/{idPlayer}/")]

public HttpResponseMessage ModifyPlayer (int idPlayer, [FromBody] PlayerDTO dto)
{
        // CAD, CEN, returnValue
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;
        PlayerDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // Modify
                playerCEN.ModifyPlayer (idPlayer,
                        dto.Name
                        );

                // Return modified object
                returnValue = PlayerAssembler.Convert (playerRESTCAD.ReadOIDDefault (idPlayer), session);

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

[Route ("~/api/ClubTeams/{idClubTeams}/GetAllClub_playerOfClub_team/{idPlayer}/")]
[Route ("~/api/NationalTeam/{idNationalTeam}/GetAllNational_playerOfNational_team/{idPlayer}/")]

public HttpResponseMessage DeletePlayer (int idPlayer)
{
        // CAD, CEN
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;

        try
        {
                SessionInitializeTransaction ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                playerCEN.DeletePlayer (idPlayer);
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


[HttpPut]
[Route ("~/api/ClubTeams/{idClubTeams}/GetAllClub_playerOfClub_team/JoinClubTeam")]
[Route ("~/api/NationalTeam/{idNationalTeam}/GetAllNational_playerOfNational_team/JoinClubTeam")]
public HttpResponseMessage JoinClubTeam (int p_player_oid, int p_club_team_oid)
{
        // CAD, CEN, returnValue
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;

        try
        {
                SessionInitializeTransaction ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // Relationer
                playerCEN.JoinClubTeam (p_player_oid, p_club_team_oid);
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

        // Return 200 - OK
        return this.Request.CreateResponse (HttpStatusCode.OK);
}



[HttpPut]
[Route ("~/api/ClubTeams/{idClubTeams}/GetAllClub_playerOfClub_team/JoinNationalTeam")]
[Route ("~/api/NationalTeam/{idNationalTeam}/GetAllNational_playerOfNational_team/JoinNationalTeam")]
public HttpResponseMessage JoinNationalTeam (int p_player_oid, int p_national_team_oid)
{
        // CAD, CEN, returnValue
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;

        try
        {
                SessionInitializeTransaction ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // Relationer
                playerCEN.JoinNationalTeam (p_player_oid, p_national_team_oid);
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

        // Return 200 - OK
        return this.Request.CreateResponse (HttpStatusCode.OK);
}



[HttpPut]
[Route ("~/api/ClubTeams/{idClubTeams}/GetAllClub_playerOfClub_team/UnlinkNationalTeam")]
[Route ("~/api/NationalTeam/{idNationalTeam}/GetAllNational_playerOfNational_team/UnlinkNationalTeam")]
public HttpResponseMessage UnlinkNationalTeam (int p_player_oid, int p_national_team_oid)
{
        // CAD, CEN, returnValue
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;

        try
        {
                SessionInitializeTransaction ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // UnRelationer
                playerCEN.UnlinkNationalTeam (p_player_oid, p_national_team_oid);
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

        // Return 200 - OK
        return this.Request.CreateResponse (HttpStatusCode.OK);
}



[HttpPut]
[Route ("~/api/ClubTeams/{idClubTeams}/GetAllClub_playerOfClub_team/UnlinkClubTeam")]
[Route ("~/api/NationalTeam/{idNationalTeam}/GetAllNational_playerOfNational_team/UnlinkClubTeam")]
public HttpResponseMessage UnlinkClubTeam (int p_player_oid, int p_club_team_oid)
{
        // CAD, CEN, returnValue
        PlayerRESTCAD playerRESTCAD = null;
        PlayerCEN playerCEN = null;

        try
        {
                SessionInitializeTransaction ();
                playerRESTCAD = new PlayerRESTCAD (session);
                playerCEN = new PlayerCEN (playerRESTCAD);

                // UnRelationer
                playerCEN.UnlinkClubTeam (p_player_oid, p_club_team_oid);
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

        // Return 200 - OK
        return this.Request.CreateResponse (HttpStatusCode.OK);
}







/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_PlayerControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
