
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
}
}
