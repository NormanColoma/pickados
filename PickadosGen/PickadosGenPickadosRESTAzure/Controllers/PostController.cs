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
// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadAll Generado a partir del serviceLink
[HttpGet]
[Route ("~/api/Post/Post_getAllPosts")]

public HttpResponseMessage Post_getAllPosts (int first)
{
        // CAD, CEN, EN, returnValue
        PostRESTCAD postRESTCAD = null;
        PostCEN postCEN = null;

        List<PostEN> postEN = null;
        List<PostDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                postRESTCAD = new PostRESTCAD (session);
                postCEN = new PostCEN (postRESTCAD);

                // Data
                // paginación

                postEN = postCEN.GetAllPosts (first, 10).ToList ();



                // Convert return
                if (postEN != null) {
                        returnValue = new List<PostDTOA>();
                        foreach (PostEN entry in postEN)
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











[HttpGet]
// [Route("{idPost}", Name="GetOIDPost")]

[Route ("~/api/Post/{idPost}")]

public HttpResponseMessage Post_getPostById (int idPost)
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


// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadFilter Generado a partir del serviceLink

[HttpGet]

[Route ("~/api/Post/Post_findPostsByTipster")]

public HttpResponseMessage Post_findPostsByTipster (int id, int first)
{
        // CAD, CEN, EN, returnValue

        PostRESTCAD postRESTCAD = null;
        PostCEN postCEN = null;

        System.Collections.Generic.List<PostEN> en;
        List<PostDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                postRESTCAD = new PostRESTCAD (session);
                postCEN = new PostCEN (postRESTCAD);


                // CEN return


                // paginación

                en = postCEN.FindPostsByTipster (id, first, 10).ToList ();



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










[HttpPut]

[Route ("~/api/Post/{idPost}/")]

public HttpResponseMessage ModifyPost (int idPost, [FromBody] PostDTO dto)
{
        // CAD, CEN, returnValue
        PostRESTCAD postRESTCAD = null;
        PostCEN postCEN = null;
        PostDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                postRESTCAD = new PostRESTCAD (session);
                postCEN = new PostCEN (postRESTCAD);

                // Modify
                postCEN.ModifyPost (idPost,
                        dto.Created_at
                        ,
                        dto.Modified_at
                        ,
                        dto.Stake
                        ,
                        dto.Description
                        ,
                        dto.Private_
                        ,
                        dto.TotalOdd
                        ,
                        dto.PostResult
                        );

                // Return modified object
                returnValue = PostAssembler.Convert (postRESTCAD.ReadOIDDefault (idPost), session);

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

[Route ("~/api/Post/{idPost}/")]

public HttpResponseMessage DeletePost (int idPost)
{
        // CAD, CEN
        PostRESTCAD postRESTCAD = null;
        PostCEN postCEN = null;

        try
        {
                SessionInitializeTransaction ();
                postRESTCAD = new PostRESTCAD (session);
                postCEN = new PostCEN (postRESTCAD);

                postCEN.DeletePost (idPost);
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






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_PostControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
