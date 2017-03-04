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
























[HttpPost]

[Route ("~/api/Usuario/Login")]


public HttpResponseMessage Login (string user, string pass)
{
        // CAD, CEN, returnValue
        UsuarioRESTCAD usuarioRESTCAD = null;
        UsuarioCEN usuarioCEN = null;
        UsuarioDTOA returnValue;
        UsuarioEN en;

        try
        {
                SessionInitializeTransaction ();
                usuarioRESTCAD = new UsuarioRESTCAD (session);
                usuarioCEN = new UsuarioCEN (usuarioRESTCAD);


                // Operation
                en = usuarioCEN.Login (user, pass);
                SessionCommit ();

                // Convert return
                returnValue = UsuarioAssembler.Convert (en, session);
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






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_UsuarioControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
