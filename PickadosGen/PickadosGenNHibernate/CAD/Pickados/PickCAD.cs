
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
 * Clase Pick:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class PickCAD : BasicCAD, IPickCAD
{
public PickCAD() : base ()
{
}

public PickCAD(ISession sessionAux) : base (sessionAux)
{
}



public PickEN ReadOIDDefault (int id
                              )
{
        PickEN pickEN = null;

        try
        {
                SessionInitializeTransaction ();
                pickEN = (PickEN)session.Get (typeof(PickEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PickCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pickEN;
}

public System.Collections.Generic.IList<PickEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PickEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PickEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PickEN>();
                        else
                                result = session.CreateCriteria (typeof(PickEN)).List<PickEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PickCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PickEN pick)
{
        try
        {
                SessionInitializeTransaction ();
                PickEN pickEN = (PickEN)session.Load (typeof(PickEN), pick.Id);

                pickEN.Odd = pick.Odd;


                pickEN.Description = pick.Description;


                pickEN.PickResult = pick.PickResult;


                pickEN.Bookie = pick.Bookie;



                session.Update (pickEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PickCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewPick (PickEN pick)
{
        try
        {
                SessionInitializeTransaction ();
                if (pick.Event_rel != null) {
                        // Argumento OID y no colección.
                        pick.Event_rel = (PickadosGenNHibernate.EN.Pickados.Event_EN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.Event_EN), pick.Event_rel.Id);

                        pick.Event_rel.Pick_rel
                        .Add (pick);
                }

                session.Save (pick);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PickCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pick.Id;
}

public void ModifyPick (PickEN pick)
{
        try
        {
                SessionInitializeTransaction ();
                PickEN pickEN = (PickEN)session.Load (typeof(PickEN), pick.Id);

                pickEN.Odd = pick.Odd;


                pickEN.Description = pick.Description;


                pickEN.PickResult = pick.PickResult;


                pickEN.Bookie = pick.Bookie;

                session.Update (pickEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PickCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeletePick (int id
                        )
{
        try
        {
                SessionInitializeTransaction ();
                PickEN pickEN = (PickEN)session.Load (typeof(PickEN), id);
                session.Delete (pickEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PickCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

//Sin e: GetPickById
//Con e: PickEN
public PickEN GetPickById (int id
                           )
{
        PickEN pickEN = null;

        try
        {
                SessionInitializeTransaction ();
                pickEN = (PickEN)session.Get (typeof(PickEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PickCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return pickEN;
}

public System.Collections.Generic.IList<PickEN> GetAllPicks (int first, int size)
{
        System.Collections.Generic.IList<PickEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(PickEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<PickEN>();
                else
                        result = session.CreateCriteria (typeof(PickEN)).List<PickEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PickCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> GetPicksByResult (PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum ? p_pickResult)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PickEN self where FROM PickEN where pickResult = :p_pickResult";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PickENgetPicksByResultHQL");
                query.SetParameter ("p_pickResult", p_pickResult);

                result = query.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in PickCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
