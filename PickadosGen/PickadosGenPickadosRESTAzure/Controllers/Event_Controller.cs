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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_Event_ControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Event_")]
public class Event_Controller : BasicController
{
// Voy a generar el readAll
// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadAll Generado a partir del serviceLink
[HttpGet]
[Route ("~/api/Event_/Event_getAllEvents")]

public HttpResponseMessage Event_getAllEvents (int first)
{
        // CAD, CEN, EN, returnValue
        Event_RESTCAD event_RESTCAD = null;
        Event_CEN event_CEN = null;

        List<Event_EN> event_EN = null;
        List<Event_DTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                event_RESTCAD = new Event_RESTCAD (session);
                event_CEN = new Event_CEN (event_RESTCAD);

                // Data
                // paginación

                event_EN = event_CEN.GetAllEvents (first, 10).ToList ();



                // Convert return
                if (event_EN != null) {
                        returnValue = new List<Event_DTOA>();
                        foreach (Event_EN entry in event_EN)
                                returnValue.Add (Event_Assembler.Convert (entry, session));
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
// [Route("{idEvent_}", Name="GetOIDEvent_")]

[Route ("~/api/Event_/{idEvent_}")]

public HttpResponseMessage GetEventById (int idEvent_)
{
        // CAD, CEN, EN, returnValue
        Event_RESTCAD event_RESTCAD = null;
        Event_CEN event_CEN = null;
        Event_EN event_EN = null;
        Event_DTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                event_RESTCAD = new Event_RESTCAD (session);
                event_CEN = new Event_CEN (event_RESTCAD);

                // Data
                event_EN = event_CEN.GetEventById (idEvent_);

                // Convert return
                if (event_EN != null) {
                        returnValue = Event_Assembler.Convert (event_EN, session);
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


[Route ("~/api/Event_/NewEvent")]




public HttpResponseMessage NewEvent ( [FromBody] Event_DTO dto)
{
        // CAD, CEN, returnValue, returnOID
        Event_RESTCAD event_RESTCAD = null;
        Event_CEN event_CEN = null;
        Event_DTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                event_RESTCAD = new Event_RESTCAD (session);
                event_CEN = new Event_CEN (event_RESTCAD);

                // Create
                returnOID = event_CEN.NewEvent (

                        dto.Date

                        );
                SessionCommit ();

                // Convert return
                returnValue = Event_Assembler.Convert (event_RESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDEvent_", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}





[HttpPut]

[Route ("~/api/Event_/{idEvent_}/")]

public HttpResponseMessage ModifyEvent (int idEvent_, [FromBody] Event_DTO dto)
{
        // CAD, CEN, returnValue
        Event_RESTCAD event_RESTCAD = null;
        Event_CEN event_CEN = null;
        Event_DTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                event_RESTCAD = new Event_RESTCAD (session);
                event_CEN = new Event_CEN (event_RESTCAD);

                // Modify
                event_CEN.ModifyEvent (idEvent_,
                        dto.Date
                        );

                // Return modified object
                returnValue = Event_Assembler.Convert (event_RESTCAD.ReadOIDDefault (idEvent_), session);

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

[Route ("~/api/Event_/{idEvent_}/")]

public HttpResponseMessage DeleteEvent (int idEvent_)
{
        // CAD, CEN
        Event_RESTCAD event_RESTCAD = null;
        Event_CEN event_CEN = null;

        try
        {
                SessionInitializeTransaction ();
                event_RESTCAD = new Event_RESTCAD (session);
                event_CEN = new Event_CEN (event_RESTCAD);

                event_CEN.DeleteEvent (idEvent_);
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
[Route ("~/api/Event_/JoinCompetition")]
public HttpResponseMessage JoinCompetition (int p_event_oid, int p_competition_oid)
{
        // CAD, CEN, returnValue
        Event_RESTCAD event_RESTCAD = null;
        Event_CEN event_CEN = null;

        try
        {
                SessionInitializeTransaction ();
                event_RESTCAD = new Event_RESTCAD (session);
                event_CEN = new Event_CEN (event_RESTCAD);

                // Relationer
                event_CEN.JoinCompetition (p_event_oid, p_competition_oid);
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
[Route ("~/api/Event_/UnlinkCompetition")]
public HttpResponseMessage UnlinkCompetition (int p_event_oid, int p_competition_oid)
{
        // CAD, CEN, returnValue
        Event_RESTCAD event_RESTCAD = null;
        Event_CEN event_CEN = null;

        try
        {
                SessionInitializeTransaction ();
                event_RESTCAD = new Event_RESTCAD (session);
                event_CEN = new Event_CEN (event_RESTCAD);

                // UnRelationer
                event_CEN.UnlinkCompetition (p_event_oid, p_competition_oid);
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







/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_Event_ControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
