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













// No pasa el slEnables: getAllPostsByResult

[HttpGet]

[Route ("~/api/Post/GetAllPostsByResult")]

public HttpResponseMessage GetAllPostsByResult (PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum postresult)
{
        // CAD, CEN, EN, returnValue

        PostRESTCAD postRESTCAD = null;
        PostCEN postCEN = null;


        System.Collections.Generic.List<PostEN> en;

        System.Collections.Generic.List<PostDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                postRESTCAD = new PostRESTCAD (session);
                postCEN = new PostCEN (postRESTCAD);

                // CEN return



                en = postCEN.GetAllPostsByResult (postresult).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<PostDTOA>();
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
