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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_PickControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Pick")]
public class PickController : BasicController
{
// Voy a generar el readAll















[HttpPost]


[Route ("~/api/Pick/NewPick")]




public HttpResponseMessage NewPick ( [FromBody] PickDTO dto)
{
        // CAD, CEN, returnValue, returnOID
        PickRESTCAD pickRESTCAD = null;
        PickCEN pickCEN = null;
        PickDTOA returnValue = null;
        int returnOID = -1;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                pickRESTCAD = new PickRESTCAD (session);
                pickCEN = new PickCEN (pickRESTCAD);

                // Create
                returnOID = pickCEN.NewPick (

                        dto.Odd

                        ,

                        dto.Description

                        ,

                        dto.PickResult

                        ,

                        dto.Bookie

                        ,
                        dto.Event_rel_oid                 // association role

                        );
                SessionCommit ();

                // Convert return
                returnValue = PickAssembler.Convert (pickRESTCAD.ReadOIDDefault (returnOID), session);
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
         * uri = Url.Link("GetOIDPick", routeValues);
         * response.Headers.Location = new Uri(uri);
         */

        return response;
}





[HttpPut]

[Route ("~/api/Post/{idPost}/GetAllPickOfPost/{idPick}/")]

public HttpResponseMessage ModifyPick (int idPick, [FromBody] PickDTO dto)
{
        // CAD, CEN, returnValue
        PickRESTCAD pickRESTCAD = null;
        PickCEN pickCEN = null;
        PickDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                pickRESTCAD = new PickRESTCAD (session);
                pickCEN = new PickCEN (pickRESTCAD);

                // Modify
                pickCEN.ModifyPick (idPick,
                        dto.Odd
                        ,
                        dto.Description
                        ,
                        dto.PickResult
                        ,
                        dto.Bookie
                        );

                // Return modified object
                returnValue = PickAssembler.Convert (pickRESTCAD.ReadOIDDefault (idPick), session);

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

[Route ("~/api/Post/{idPost}/GetAllPickOfPost/{idPick}/")]

public HttpResponseMessage DeletePick (int idPick)
{
        // CAD, CEN
        PickRESTCAD pickRESTCAD = null;
        PickCEN pickCEN = null;

        try
        {
                SessionInitializeTransaction ();
                pickRESTCAD = new PickRESTCAD (session);
                pickCEN = new PickCEN (pickRESTCAD);

                pickCEN.DeletePick (idPick);
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






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_PickControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
