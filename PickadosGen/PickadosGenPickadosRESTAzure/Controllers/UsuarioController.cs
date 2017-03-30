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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_UsuarioControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Usuario")]
public class UsuarioController : BasicController
{
// Voy a generar el readAll
// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadAll Generado a partir del serviceLink
[HttpGet]
[Route ("~/api/Usuario/Usuario_getAllUsers")]

public HttpResponseMessage Usuario_getAllUsers (int first)
{
        // CAD, CEN, EN, returnValue
        UsuarioRESTCAD usuarioRESTCAD = null;
        UsuarioCEN usuarioCEN = null;

        List<UsuarioEN> usuarioEN = null;
        List<UsuarioDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                usuarioRESTCAD = new UsuarioRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioRESTCAD);

                // Data
                // paginación

                usuarioEN = usuarioCEN.GetAllUsers (first, 10).ToList ();



                // Convert return
                if (usuarioEN != null) {
                        returnValue = new List<UsuarioDTOA>();
                        foreach (UsuarioEN entry in usuarioEN)
                                returnValue.Add (UsuarioAssembler.Convert (entry, session));
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
// [Route("{idUsuario}", Name="GetOIDUsuario")]

[Route ("~/api/Usuario/{idUsuario}")]

public HttpResponseMessage Usuario_getUserById (int idUsuario)
{
        // CAD, CEN, EN, returnValue
        UsuarioRESTCAD usuarioRESTCAD = null;
        UsuarioCEN usuarioCEN = null;
        UsuarioEN usuarioEN = null;
        UsuarioDTOA returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();
                usuarioRESTCAD = new UsuarioRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioRESTCAD);

                // Data
                usuarioEN = usuarioCEN.GetUserById (idUsuario);

                // Convert return
                if (usuarioEN != null) {
                        returnValue = UsuarioAssembler.Convert (usuarioEN, session);
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








[HttpPut]

[Route ("~/api/Usuario/{idUsuario}/")]

public HttpResponseMessage ModifyUser (int idUsuario, [FromBody] UsuarioDTO dto)
{
        // CAD, CEN, returnValue
        UsuarioRESTCAD usuarioRESTCAD = null;
        UsuarioCEN usuarioCEN = null;
        UsuarioDTOA returnValue = null;

        // HTTP response
        HttpResponseMessage response = null;
        string uri = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioRESTCAD = new UsuarioRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioRESTCAD);

                // Modify
                usuarioCEN.ModifyUser (idUsuario,
                        dto.Alias
                        ,
                        dto.Email
                        ,
                        dto.Password
                        ,
                        dto.Created_at
                        ,
                        dto.Updated_at
                        ,
                        dto.Nif
                        ,
                        dto.Admin
                        );

                // Return modified object
                returnValue = UsuarioAssembler.Convert (usuarioRESTCAD.ReadOIDDefault (idUsuario), session);

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

[Route ("~/api/Usuario/{idUsuario}/")]

public HttpResponseMessage DeleteUser (int idUsuario)
{
        // CAD, CEN
        UsuarioRESTCAD usuarioRESTCAD = null;
        UsuarioCEN usuarioCEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioRESTCAD = new UsuarioRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioRESTCAD);

                usuarioCEN.DeleteUser (idUsuario);
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






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_UsuarioControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
