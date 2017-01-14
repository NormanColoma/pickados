
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
 * Clase Wincast:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class WincastCAD : BasicCAD, IWincastCAD
{
public WincastCAD() : base ()
{
}

public WincastCAD(ISession sessionAux) : base (sessionAux)
{
}



public WincastEN ReadOIDDefault (int id
                                 )
{
        WincastEN wincastEN = null;

        try
        {
                SessionInitializeTransaction ();
                wincastEN = (WincastEN)session.Get (typeof(WincastEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in WincastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return wincastEN;
}

public System.Collections.Generic.IList<WincastEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<WincastEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(WincastEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<WincastEN>();
                        else
                                result = session.CreateCriteria (typeof(WincastEN)).List<WincastEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in WincastCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (WincastEN wincast)
{
        try
        {
                SessionInitializeTransaction ();
                WincastEN wincastEN = (WincastEN)session.Load (typeof(WincastEN), wincast.Id);

                wincastEN.Team_name = wincast.Team_name;

                session.Update (wincastEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in WincastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (WincastEN wincast)
{
        try
        {
                SessionInitializeTransaction ();
                if (wincast.Event_rel != null) {
                        // Argumento OID y no colección.
                        wincast.Event_rel = (PickadosGenNHibernate.EN.Pickados.Event_EN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.Event_EN), wincast.Event_rel.Id);

                        wincast.Event_rel.Pick_rel
                        .Add (wincast);
                }
                if (wincast.Player != null) {
                        // Argumento OID y no colección.
                        wincast.Player = (PickadosGenNHibernate.EN.Pickados.PlayerEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.PlayerEN), wincast.Player.Id);

                        wincast.Player.Scorer
                        .Add (wincast);
                }

                session.Save (wincast);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in WincastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return wincast.Id;
}

public void Modify (WincastEN wincast)
{
        try
        {
                SessionInitializeTransaction ();
                WincastEN wincastEN = (WincastEN)session.Load (typeof(WincastEN), wincast.Id);

                wincastEN.Odd = wincast.Odd;


                wincastEN.Description = wincast.Description;


                wincastEN.PickResult = wincast.PickResult;


                wincastEN.Bookie = wincast.Bookie;


                wincastEN.Scorer_name = wincast.Scorer_name;


                wincastEN.Team_name = wincast.Team_name;

                session.Update (wincastEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in WincastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int id
                     )
{
        try
        {
                SessionInitializeTransaction ();
                WincastEN wincastEN = (WincastEN)session.Load (typeof(WincastEN), id);
                session.Delete (wincastEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in WincastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
