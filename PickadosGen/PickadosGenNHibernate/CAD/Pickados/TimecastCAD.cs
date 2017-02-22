
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
 * Clase Timecast:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class TimecastCAD : BasicCAD, ITimecastCAD
{
public TimecastCAD() : base ()
{
}

public TimecastCAD(ISession sessionAux) : base (sessionAux)
{
}



public TimecastEN ReadOIDDefault (int id
                                  )
{
        TimecastEN timecastEN = null;

        try
        {
                SessionInitializeTransaction ();
                timecastEN = (TimecastEN)session.Get (typeof(TimecastEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TimecastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return timecastEN;
}

public System.Collections.Generic.IList<TimecastEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<TimecastEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(TimecastEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<TimecastEN>();
                        else
                                result = session.CreateCriteria (typeof(TimecastEN)).List<TimecastEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TimecastCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (TimecastEN timecast)
{
        try
        {
                SessionInitializeTransaction ();
                TimecastEN timecastEN = (TimecastEN)session.Load (typeof(TimecastEN), timecast.Id);

                timecastEN.Score_time = timecast.Score_time;

                session.Update (timecastEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TimecastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewTimecast (TimecastEN timecast)
{
        try
        {
                SessionInitializeTransaction ();
                if (timecast.Event_rel != null) {
                        // Argumento OID y no colección.
                        timecast.Event_rel = (PickadosGenNHibernate.EN.Pickados.Event_EN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.Event_EN), timecast.Event_rel.Id);

                        timecast.Event_rel.Pick_rel
                        .Add (timecast);
                }
                if (timecast.Player != null) {
                        // Argumento OID y no colección.
                        timecast.Player = (PickadosGenNHibernate.EN.Pickados.PlayerEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.PlayerEN), timecast.Player.Id);

                        timecast.Player.Scorer
                        .Add (timecast);
                }

                session.Save (timecast);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TimecastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return timecast.Id;
}

public void ModifyTimecast (TimecastEN timecast)
{
        try
        {
                SessionInitializeTransaction ();
                TimecastEN timecastEN = (TimecastEN)session.Load (typeof(TimecastEN), timecast.Id);

                timecastEN.Odd = timecast.Odd;


                timecastEN.Description = timecast.Description;


                timecastEN.PickResult = timecast.PickResult;


                timecastEN.Bookie = timecast.Bookie;


                timecastEN.Scorer_name = timecast.Scorer_name;


                timecastEN.Score_time = timecast.Score_time;

                session.Update (timecastEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TimecastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeleteTimecast (int id
                            )
{
        try
        {
                SessionInitializeTransaction ();
                TimecastEN timecastEN = (TimecastEN)session.Load (typeof(TimecastEN), id);
                session.Delete (timecastEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in TimecastCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
