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
// [Route("{idPost}", Name="GetOIDPost")]

[Route ("~/api/Post/{idPost}")]

public HttpResponseMessage GetPostById (int idPost)
{
        // CAD, CEN, EN, returnValue
        PostRESTCAD postRESTCAD = null;
        PostCEN postCEN = null;
        PostEN postEN = null;
        PostDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                postRESTCAD = new PostRESTCAD (session);
                postCEN = new PostCEN (postRESTCAD);

                // Data
                postEN = postCEN.GetPostById (idPost);

                // Convert return
                if (postEN != null) {
                        returnValue = PostAssembler.Convert (postEN, session);
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



// No pasa el slEnables: findPostsByTipster

[HttpGet]

[Route ("~/api/Post/FindPostsByTipster")]

public HttpResponseMessage FindPostsByTipster (int id)
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



                en = postCEN.FindPostsByTipster (id).ToList ();




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














[HttpPost]

[Route ("~/api/Post/VerifyPost")]

public HttpResponseMessage VerifyPost (int p_oid)
{
        // CP, returnValue
        PostCP postCP = null;


        try
        {
                SessionInitializeTransaction ();
                postCP = new PostCP (session);

                // Operation
                postCP.VerifyPost (p_oid);
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



[HttpPost]

[Route ("~/api/Post/PublishPost")]

public HttpResponseMessage PublishPost (Nullable<DateTime> p_created_at, Nullable<DateTime> p_modified_at, double p_stake, string p_description, bool p_private, System.Collections.Generic.IList<int> p_pick, int p_tipster, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_postresult)
{
        // CP, returnValue
        PostCP postCP = null;

        int returnValue;

        try
        {
                SessionInitializeTransaction ();
                postCP = new PostCP (session);

                // Operation
                returnValue = postCP.PublishPost (p_created_at, p_modified_at, p_stake, p_description, p_private, p_pick, p_tipster, p_postresult);
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
        return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}





/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_PostControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
