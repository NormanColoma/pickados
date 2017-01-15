
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
 * Clase Stats:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial class StatsCAD : BasicCAD, IStatsCAD
{
public StatsCAD() : base ()
{
}

public StatsCAD(ISession sessionAux) : base (sessionAux)
{
}



public StatsEN ReadOIDDefault (int id
                               )
{
        StatsEN statsEN = null;

        try
        {
                SessionInitializeTransaction ();
                statsEN = (StatsEN)session.Get (typeof(StatsEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in StatsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return statsEN;
}

public System.Collections.Generic.IList<StatsEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<StatsEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(StatsEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<StatsEN>();
                        else
                                result = session.CreateCriteria (typeof(StatsEN)).List<StatsEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in StatsCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (StatsEN stats)
{
        try
        {
                SessionInitializeTransaction ();
                StatsEN statsEN = (StatsEN)session.Load (typeof(StatsEN), stats.Id);

                statsEN.Benefit = stats.Benefit;


                statsEN.StakeAverage = stats.StakeAverage;


                statsEN.Yield = stats.Yield;


                statsEN.OddAverage = stats.OddAverage;


                statsEN.TotalPicks = stats.TotalPicks;


                statsEN.InitialDate = stats.InitialDate;


                session.Update (statsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in StatsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int NewMonthlyStats (StatsEN stats)
{
        try
        {
                SessionInitializeTransaction ();
                if (stats.Tipster != null) {
                        // Argumento OID y no colección.
                        stats.Tipster = (PickadosGenNHibernate.EN.Pickados.TipsterEN)session.Load (typeof(PickadosGenNHibernate.EN.Pickados.TipsterEN), stats.Tipster.Id);

                        stats.Tipster.MonthlyStats
                        .Add (stats);
                }

                session.Save (stats);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in StatsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return stats.Id;
}

public void ModifyMonthlyStats (StatsEN stats)
{
        try
        {
                SessionInitializeTransaction ();
                StatsEN statsEN = (StatsEN)session.Load (typeof(StatsEN), stats.Id);

                statsEN.Benefit = stats.Benefit;


                statsEN.StakeAverage = stats.StakeAverage;


                statsEN.Yield = stats.Yield;


                statsEN.OddAverage = stats.OddAverage;


                statsEN.TotalPicks = stats.TotalPicks;


                statsEN.InitialDate = stats.InitialDate;

                session.Update (statsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in StatsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void DeleteMonthlyStats (int id
                                )
{
        try
        {
                SessionInitializeTransaction ();
                StatsEN statsEN = (StatsEN)session.Load (typeof(StatsEN), id);
                session.Delete (statsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException ("Error in StatsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

        public StatsEN GetByID(int id
                                )
        {
            StatsEN statsEN = null;

            try
            {
                SessionInitializeTransaction();
                statsEN = (StatsEN)session.Get(typeof(StatsEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in StatsCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return statsEN;
        }

        public System.Collections.Generic.IList<StatsEN> ReadAll(int first, int size)
        {
            System.Collections.Generic.IList<StatsEN> result = null;
            try
            {
                SessionInitializeTransaction();
                if (size > 0)
                    result = session.CreateCriteria(typeof(StatsEN)).
                             SetFirstResult(first).SetMaxResults(size).List<StatsEN>();
                else
                    result = session.CreateCriteria(typeof(StatsEN)).List<StatsEN>();
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in StatsCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
