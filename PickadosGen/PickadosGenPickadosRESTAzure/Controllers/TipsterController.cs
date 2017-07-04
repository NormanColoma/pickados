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













// No pasa el slEnables: getFollowers

[HttpGet]

[Route ("~/api/Tipster/GetFollowers")]

public HttpResponseMessage GetFollowers (int id)
{
        // CAD, CEN, EN, returnValue

        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;


        System.Collections.Generic.List<TipsterEN> en;

        System.Collections.Generic.List<TipsterDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);

                // CEN return



                en = tipsterCEN.GetFollowers (id).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<TipsterDTOA>();
                        foreach (TipsterEN entry in en)
                                returnValue.Add (TipsterAssembler.Convert (entry, session));
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


// No pasa el slEnables: getFollows

[HttpGet]

[Route ("~/api/Tipster/GetFollows")]

public HttpResponseMessage GetFollows (int id)
{
        // CAD, CEN, EN, returnValue

        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;


        System.Collections.Generic.List<TipsterEN> en;

        System.Collections.Generic.List<TipsterDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);

                // CEN return



                en = tipsterCEN.GetFollows (id).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<TipsterDTOA>();
                        foreach (TipsterEN entry in en)
                                returnValue.Add (TipsterAssembler.Convert (entry, session));
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


// No pasa el slEnables: getTipstersPremium

[HttpGet]

[Route ("~/api/Tipster/GetTipstersPremium")]

public HttpResponseMessage GetTipstersPremium (int first, int size)
{
        // CAD, CEN, EN, returnValue

        TipsterCP tipsterCP = null;


        System.Collections.Generic.List<TipsterEN> en;

        System.Collections.Generic.List<TipsterDTOA> returnValue = null;

        try
        {
                SessionInitializeWithoutTransaction ();

                tipsterCP = new TipsterCP (session);

                // CEN return



                en = tipsterCP.GetTipstersPremium (first, size).ToList ();




                // Convert return
                if (en != null) {
                        returnValue = new System.Collections.Generic.List<TipsterDTOA>();
                        foreach (TipsterEN entry in en)
                                returnValue.Add (TipsterAssembler.Convert (entry, session));
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


// No pasa el slEnables: findByUser

[HttpGet]

[Route ("~/api/Tipster/FindByUser")]

public HttpResponseMessage FindByUser (string alias)
{
        // CAD, CEN, EN, returnValue

        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;


        TipsterEN en;

        TipsterDTOA returnValue;

        try
        {
                SessionInitializeWithoutTransaction ();

                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);

                // CEN return



                en = tipsterCEN.FindByUser (alias);




                // Convert return
                returnValue = TipsterAssembler.Convert (en, session);
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
        if (returnValue == null)
                return this.Request.CreateResponse (HttpStatusCode.NoContent);
        // Return 200 - OK
        else return this.Request.CreateResponse (HttpStatusCode.OK, returnValue);
}













[HttpPost]

[Route ("~/api/Tipster/Login")]


public HttpResponseMessage Login (string user, string pass)
{
        // CAD, CEN, returnValue
        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;
        TipsterDTOA returnValue;
        TipsterEN en;

        try
        {
                SessionInitializeTransaction ();
                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);


                // Operation
                en = tipsterCEN.Login (user, pass);
                SessionCommit ();

                // Convert return
                returnValue = TipsterAssembler.Convert (en, session);
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



[HttpPost]

[Route ("~/api/Tipster/Registration")]


public HttpResponseMessage Registration (string alias, string nif, string email, string pass)
{
        // CAD, CEN, returnValue
        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;
        int returnValue;

        try
        {
                SessionInitializeTransaction ();
                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);


                // Operation
                returnValue = tipsterCEN.Registration (alias, nif, email, pass);
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



[HttpPost]

[Route ("~/api/Tipster/AddingFollower")]


public HttpResponseMessage AddingFollower (int idtipster, int idnewfollower)
{
        // CAD, CEN, returnValue
        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;
        bool returnValue;

        try
        {
                SessionInitializeTransaction ();
                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);


                // Operation
                returnValue = tipsterCEN.AddingFollower (idtipster, idnewfollower);
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



[HttpPost]

[Route ("~/api/Tipster/DeletingFollower")]


public HttpResponseMessage DeletingFollower (int idtipster, int idunfollower)
{
        // CAD, CEN, returnValue
        TipsterRESTCAD tipsterRESTCAD = null;
        TipsterCEN tipsterCEN = null;
        bool returnValue;

        try
        {
                SessionInitializeTransaction ();
                tipsterRESTCAD = new TipsterRESTCAD (session);
                tipsterCEN = new TipsterCEN (tipsterRESTCAD);


                // Operation
                returnValue = tipsterCEN.DeletingFollower (idtipster, idunfollower);
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






/*PROTECTED REGION ID(PickadosGenPickadosRESTAzure_TipsterControllerAzure) ENABLED START*/
// Meter las operaciones que invoquen a las CPs
/*PROTECTED REGION END*/
}
}
