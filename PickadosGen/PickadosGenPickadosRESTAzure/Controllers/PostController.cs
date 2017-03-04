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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_PostControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Post")]
public class PostController : BasicController
{
// Voy a generar el readAll







[HttpGet]



[Route ("~/api/Post/{idPost}/GetAllPostOfTipster/")]

public HttpResponseMessage GetAllPostOfTipster (int idTipster)
{
        // CAD, EN
        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterEN tipsterEN = null;

        // returnValue
        List<PostEN> en = null;
        List<PostDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                tipsterRESTCAD = new TipsterRESTCAD (session);

                // Exists Tipster
                tipsterEN = tipsterRESTCAD.ReadOIDDefault (idTipster);
                if (tipsterEN == null) throw new HttpResponseException (this.Request.CreateResponse (HttpStatusCode.NotFound, "Tipster#" + idTipster + " not found"));

                // Rol
                // TODO: paginación


                en = tipsterRESTCAD.GetAllPostOfTipster (idTipster).ToList ();

                // Convert return
                if (en != null) {
                        returnValue = new List<PostDTOA>();
                        foreach (PostEN entry in en)
                                returnValue.Add (PostAssembler.Convert (entry, session));
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























/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_PostControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
