
using System;
using System.Text;
using PickadosGenNHibernate.CEN.Pickados;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Exceptions;


/*
 * Clase Request:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class RequestCAD : BasicCAD, IRequestCAD
{
public RequestCAD() : base ()
{
}

public RequestCAD(ISession sessionAux) : base (sessionAux)
{
}



public RequestEN ReadOIDDefault (int id
                                 )
{
        RequestEN requestEN = null;

        try
        {
                SessionInitializeTransaction ();
                requestEN = (RequestEN)session.Get (typeof(RequestEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RequestCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return requestEN;
}

public System.Collections.Generic.IList<RequestEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<RequestEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(RequestEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<RequestEN>();
                        else
                                result = session.CreateCriteria (typeof(RequestEN)).List<RequestEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RequestCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (RequestEN request)
{
        try
        {
                SessionInitializeTransaction ();
                RequestEN requestEN = (RequestEN)session.Load (typeof(RequestEN), request.Id);


                requestEN.Type = request.Type;


                requestEN.Reason = request.Reason;


                requestEN.State = request.State;


                requestEN.Date = request.Date;

                session.Update (requestEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RequestCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (RequestEN request)
{
        try
        {
                SessionInitializeTransaction ();
                if (request.Post != null) {
                        // Argumento OID y no colección.
                        request.Post = (PickadosGenNHibernate.EN.Pickados.PostEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.PostEN), request.Post.Id);

                        request.Post.Request
                        .Add (request);
                }

                session.Save (request);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RequestCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return request.Id;
}

public void Modify (RequestEN request)
{
        try
        {
                SessionInitializeTransaction ();
                RequestEN requestEN = (RequestEN)session.Load (typeof(RequestEN), request.Id);

                requestEN.Type = request.Type;


                requestEN.Reason = request.Reason;


                requestEN.State = request.State;


                requestEN.Date = request.Date;

                session.Update (requestEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RequestCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Delete (int id
                    )
{
        try
        {
                SessionInitializeTransaction ();
                RequestEN requestEN = (RequestEN)session.Load (typeof(RequestEN), id);
                session.Delete (requestEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RequestCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetById
//Con e: RequestEN
public RequestEN GetById (int id
                          )
{
        RequestEN requestEN = null;

        try
        {
                SessionInitializeTransaction ();
                requestEN = (RequestEN)session.Get (typeof(RequestEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RequestCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return requestEN;
}

public System.Collections.Generic.IList<RequestEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<RequestEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(RequestEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<RequestEN>();
                else
                        result = session.CreateCriteria (typeof(RequestEN)).List<RequestEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RequestCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RequestEN> GetByState (PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum ? p_state)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RequestEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM RequestEN self where FROM RequestEN  where state = :p_state";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("RequestENgetByStateHQL");
                query.SetParameter ("p_state", p_state);

                result = query.List<PickadosGenNHibernate.EN.Pickados.RequestEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in RequestCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
