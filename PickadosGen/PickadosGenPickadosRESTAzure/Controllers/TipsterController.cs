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


/*PROTECTED REGION ID(usingPickadosGenPickadosRESTAzure_TipsterControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/



namespace PickadosGenPickadosRESTAzure.Controllers
{
[RoutePrefix ("~/api/Tipster")]
public class TipsterController : BasicController
{
// Voy a generar el readAll












// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadFilter Generado a partir del serviceLink

[HttpGet]

[Route ("~/api/Tipster/Tipster_findByMail")]

public HttpResponseMessage Tipster_findByMail (string email, int first)
{
        // CAD, CEN, EN, returnValue

        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;

        TipsterEN en;

        List<TipsterDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);


                // CEN return


                // paginación

                en = tipsterCEN.FindByMail (email);



                // Convert return
                if (en != null) {
                        returnValue = new List<TipsterDTOA>();
                        
                        returnValue.Add (TipsterAssembler.Convert (en, session));
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




// Pasa el slEnables


//Pasa el serviceLinkValid

// ReadFilter Generado a partir del serviceLink

[HttpGet]

[Route ("~/api/Tipster/Tipster_findByNIF")]

public HttpResponseMessage Tipster_findByNIF (string nif, int first)
{
        // CAD, CEN, EN, returnValue

        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;

        TipsterEN en;

        List<TipsterDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);


                // CEN return


                // paginación

                en = tipsterCEN.FindByNIF (nif);



                // Convert return
                if (en != null) {
                        returnValue = new List<TipsterDTOA>();
                        returnValue.Add (TipsterAssembler.Convert (en, session));
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

[Route ("~/api/Tipster/BecomePremium")]


public HttpResponseMessage BecomePremium (int p_oid, double fee)
{
        // CAD, CEN, returnValue
        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;

        try
        {
                SessionInitializeTransaction ();
                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);


                // Operation
                tipsterCEN.BecomePremium (p_oid, fee);
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






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_TipsterControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
