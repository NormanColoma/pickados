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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_RequestControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Request")]
public class RequestController : BasicController
{
// Voy a generar el readAll
// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadAll Generado a partir del serviceLink
[HttpGet]
[Route ("~/api/Request/Request_getAll")]

public HttpResponseMessage Request_getAll (int first)
{
        // CAD, CEN, EN, returnValue
        RequestRESTCAD requestRESTCAD = null;
        RequestCEN requestCEN = null;

        List<RequestEN> requestEN = null;
        List<RequestDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                requestRESTCAD = new RequestRESTCAD (session);
                requestCEN = new RequestCEN (requestRESTCAD);

                // Data
                // paginación

                requestEN = requestCEN.GetAll (first, 10).ToList ();



                // Convert return
                if (requestEN != null) {
                        returnValue = new List<RequestDTOA>();
                        foreach (RequestEN entry in requestEN)
                                returnValue.Add (RequestAssembler.Convert (entry, session));
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
// [Route("{idRequest}", Name="GetOIDRequest")]

[Route ("~/api/Request/{idRequest}")]

public HttpResponseMessage GetById (int idRequest)
{
        // CAD, CEN, EN, returnValue
        RequestRESTCAD requestRESTCAD = null;
        RequestCEN requestCEN = null;
        RequestEN requestEN = null;
        RequestDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                requestRESTCAD = new RequestRESTCAD (session);
                requestCEN = new RequestCEN (requestRESTCAD);

                // Data
                requestEN = requestCEN.GetById (idRequest);

                // Convert return
                if (requestEN != null) {
                        returnValue = RequestAssembler.Convert (requestEN, session);
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

[Route ("~/api/Request/Request_getByState")]

public HttpResponseMessage Request_getByState (PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum p_state)
{
        // CAD, CEN, EN, returnValue

        RequestRESTCAD requestRESTCAD = null;
        RequestCEN requestCEN = null;

        System.Collections.Generic.List<RequestEN> en;
        List<RequestDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                requestRESTCAD = new RequestRESTCAD (session);
                requestCEN = new RequestCEN (requestRESTCAD);


                // CEN return


                // paginación

                en = requestCEN.GetByState (p_state).ToList ();



                // Convert return
                if (en != null) {
                        returnValue = new List<RequestDTOA>();
                        foreach (RequestEN entry in en)
                                returnValue.Add (RequestAssembler.Convert (entry, session));
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

[Route ("~/api/Request/{idRequest}/")]

public HttpResponseMessage Modify (int idRequest, [FromBody] RequestDTO dto)
{
        // CAD, CEN, returnValue
        RequestRESTCAD requestRESTCAD = null;
        RequestCEN requestCEN = null;
        RequestDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                requestRESTCAD = new RequestRESTCAD (session);
                requestCEN = new RequestCEN (requestRESTCAD);

                // Modify
                requestCEN.Modify (idRequest,
                        dto.Type
                        ,
                        dto.Reason
                        ,
                        dto.State
                        ,
                        dto.Date
                        );

                // Return modified object
                returnValue = RequestAssembler.Convert (requestRESTCAD.ReadOIDDefault (idRequest), session);

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

[Route ("~/api/Request/{idRequest}/")]

public HttpResponseMessage Delete (int idRequest)
{
        // CAD, CEN
        RequestRESTCAD requestRESTCAD = null;
        RequestCEN requestCEN = null;

        try
        {
                SessionInitializeTransaction ();
                requestRESTCAD = new RequestRESTCAD (session);
                requestCEN = new RequestCEN (requestRESTCAD);

                requestCEN.Delete (idRequest);
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






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_RequestControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
