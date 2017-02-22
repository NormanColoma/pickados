
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
 * Clase Handicap:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class HandicapCAD : BasicCAD, IHandicapCAD
{
public HandicapCAD() : base ()
{
}

public HandicapCAD(ISession sessionAux) : base (sessionAux)
{
}



public HandicapEN ReadOIDDefault (int id
                                  )
{
        HandicapEN handicapEN = null;

        try
        {
                SessionInitializeTransaction ();
                handicapEN = (HandicapEN)session.Get (typeof(HandicapEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in HandicapCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return handicapEN;
}

public System.Collections.Generic.IList<HandicapEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<HandicapEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(HandicapEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<HandicapEN>();
                        else
                                result = session.CreateCriteria (typeof(HandicapEN)).List<HandicapEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in HandicapCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (HandicapEN handicap)
{
        try
        {
                SessionInitializeTransaction ();
                HandicapEN handicapEN = (HandicapEN)session.Load (typeof(HandicapEN), handicap.Id);

                handicapEN.Result = handicap.Result;

                session.Update (handicapEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in HandicapCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewHandicap (HandicapEN handicap)
{
        try
        {
                SessionInitializeTransaction ();
                if (handicap.Event_rel != null) {
                        // Argumento OID y no colección.
                        handicap.Event_rel = (PickadosGenNHibernate.EN.Pickados.Event_EN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.Event_EN), handicap.Event_rel.Id);

                        handicap.Event_rel.Pick_rel
                        .Add (handicap);
                }

                session.Save (handicap);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in HandicapCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return handicap.Id;
}

public void ModifyHandicap (HandicapEN handicap)
{
        try
        {
                SessionInitializeTransaction ();
                HandicapEN handicapEN = (HandicapEN)session.Load (typeof(HandicapEN), handicap.Id);

                handicapEN.Odd = handicap.Odd;


                handicapEN.Description = handicap.Description;


                handicapEN.PickResult = handicap.PickResult;


                handicapEN.Bookie = handicap.Bookie;


                handicapEN.Line = handicap.Line;


                handicapEN.Quantity = handicap.Quantity;


                handicapEN.Asian = handicap.Asian;


                handicapEN.Result = handicap.Result;

                session.Update (handicapEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in HandicapCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeleteHandicap (int id
                            )
{
        try
        {
                SessionInitializeTransaction ();
                HandicapEN handicapEN = (HandicapEN)session.Load (typeof(HandicapEN), id);
                session.Delete (handicapEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in HandicapCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
