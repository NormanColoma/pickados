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
// [Route("{idMatch}", Name="GetOIDMatch")]

[Route ("~/api/Match/{idMatch}")]

public HttpResponseMessage GetMatchById (int idMatch)
{
        // CAD, CEN, EN, returnValue
        MatchRESTCAD matchRESTCAD = null;
        MatchCEN matchCEN = null;
        MatchEN matchEN = null;
        MatchDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                matchRESTCAD = new MatchRESTCAD (session);
                matchCEN = new MatchCEN (matchRESTCAD);

                // Data
                matchEN = matchCEN.GetMatchById (idMatch);

                // Convert return
                if (matchEN != null) {
                        returnValue = MatchAssembler.Convert (matchEN, session);
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

[Route ("~/api/Match/Match_getMatchByCompetition")]

public HttpResponseMessage Match_getMatchByCompetition (int id, int first)
{
        // CAD, CEN, EN, returnValue

        MatchRESTCAD matchRESTCAD = null;
        MatchCEN matchCEN = null;

        System.Collections.Generic.List<MatchEN> en;
        List<MatchDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                matchRESTCAD = new MatchRESTCAD (session);
                matchCEN = new MatchCEN (matchRESTCAD);


                // CEN return


                // paginación

                en = matchCEN.GetMatchByCompetition (id, first, 10).ToList ();



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










[HttpPut]

[Route ("~/api/Match/{idMatch}/")]

public HttpResponseMessage ModifyMatch (int idMatch, [FromBody] MatchDTO dto)
{
        // CAD, CEN, returnValue
        MatchRESTCAD matchRESTCAD = null;
        MatchCEN matchCEN = null;
        MatchDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                matchRESTCAD = new MatchRESTCAD (session);
                matchCEN = new MatchCEN (matchRESTCAD);

                // Modify
                matchCEN.ModifyMatch (idMatch,
                        dto.Date
                        ,
                        dto.Stadium
                        );

                // Return modified object
                returnValue = MatchAssembler.Convert (matchRESTCAD.ReadOIDDefault (idMatch), session);

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

[Route ("~/api/Match/{idMatch}/")]

public HttpResponseMessage DeleteMatch (int idMatch)
{
        // CAD, CEN
        MatchRESTCAD matchRESTCAD = null;
        MatchCEN matchCEN = null;

        try
        {
                SessionInitializeTransaction ();
                matchRESTCAD = new MatchRESTCAD (session);
                matchCEN = new MatchCEN (matchRESTCAD);

                matchCEN.DeleteMatch (idMatch);
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






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_MatchControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
