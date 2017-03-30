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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_CompetitionControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Competition")]
public class CompetitionController : BasicController
{
// Voy a generar el readAll
// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadAll Generado a partir del serviceLink
[HttpGet]
[Route ("~/api/Competition/Competition_getAllCompetitions")]

public HttpResponseMessage Competition_getAllCompetitions (int first)
{
        // CAD, CEN, EN, returnValue
        CompetitionRESTCAD competitionRESTCAD = null;
        CompetitionCEN competitionCEN = null;

        List<CompetitionEN> competitionEN = null;
        List<CompetitionDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                competitionRESTCAD = new CompetitionRESTCAD (session);
                competitionCEN = new CompetitionCEN (competitionRESTCAD);

                // Data
                // paginación

                competitionEN = competitionCEN.GetAllCompetitions (first, 10).ToList ();



                // Convert return
                if (competitionEN != null) {
                        returnValue = new List<CompetitionDTOA>();
                        foreach (CompetitionEN entry in competitionEN)
                                returnValue.Add (CompetitionAssembler.Convert (entry, session));
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
// [Route("{idCompetition}", Name="GetOIDCompetition")]

[Route ("~/api/Competition/{idCompetition}")]

public HttpResponseMessage GetCompetitionById (int idCompetition)
{
        // CAD, CEN, EN, returnValue
        CompetitionRESTCAD competitionRESTCAD = null;
        CompetitionCEN competitionCEN = null;
        CompetitionEN competitionEN = null;
        CompetitionDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                competitionRESTCAD = new CompetitionRESTCAD (session);
                competitionCEN = new CompetitionCEN (competitionRESTCAD);

                // Data
                competitionEN = competitionCEN.GetCompetitionById (idCompetition);

                // Convert return
                if (competitionEN != null) {
                        returnValue = CompetitionAssembler.Convert (competitionEN, session);
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




[HttpPost]


[Route ("~/api/Competition/NewCompetition")]




public HttpResponseMessage NewCompetition ( [FromBody] CompetitionDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        CompetitionRESTCAD competitionRESTCAD = null;
        CompetitionCEN competitionCEN = null;
        CompetitionDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                competitionRESTCAD = new CompetitionRESTCAD (session);
                competitionCEN = new CompetitionCEN (competitionRESTCAD);

                // Create
                returnOID = competitionCEN.NewCompetition (

                        dto.Name

                        ,
                        dto.Sport_oid                 // association role

                        ,

                        dto.Place

                        );
                SessionCommit ();

                // Convert return
                returnValue = CompetitionAssembler.Convert (competitionRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDCompetition", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}





[HttpPut]

[Route ("~/api/Competition/{idCompetition}/")]

public HttpResponseMessage ModifyCompetition (int idCompetition, [FromBody] CompetitionDTO dto)
{
        // CAD, CEN, returnValue
        CompetitionRESTCAD competitionRESTCAD = null;
        CompetitionCEN competitionCEN = null;
        CompetitionDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                competitionRESTCAD = new CompetitionRESTCAD (session);
                competitionCEN = new CompetitionCEN (competitionRESTCAD);

                // Modify
                competitionCEN.ModifyCompetition (idCompetition,
                        dto.Name
                        ,
                        dto.Place
                        );

                // Return modified object
                returnValue = CompetitionAssembler.Convert (competitionRESTCAD.ReadOIDDefault (idCompetition), session);

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

[Route ("~/api/Competition/{idCompetition}/")]

public HttpResponseMessage DeleteCompetition (int idCompetition)
{
        // CAD, CEN
        CompetitionRESTCAD competitionRESTCAD = null;
        CompetitionCEN competitionCEN = null;

        try
        {
                SessionInitializeTransaction ();
                competitionRESTCAD = new CompetitionRESTCAD (session);
                competitionCEN = new CompetitionCEN (competitionRESTCAD);

                competitionCEN.DeleteCompetition (idCompetition);
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






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_CompetitionControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
