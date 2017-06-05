
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


                statsEN.Date = stats.Date;



                statsEN.OddAccumulator = stats.OddAccumulator;


                statsEN.TotalStaked = stats.TotalStaked;

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


                statsEN.Date = stats.Date;


                statsEN.OddAccumulator = stats.OddAccumulator;


                statsEN.TotalStaked = stats.TotalStaked;

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

//Sin e: GetStatById
//Con e: StatsEN
public StatsEN GetStatById (int id
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

public System.Collections.Generic.IList<StatsEN> GetAllStats (int first, int size)
{
        System.Collections.Generic.IList<StatsEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(StatsEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<StatsEN>();
                else
                        result = session.CreateCriteria (typeof(StatsEN)).List<StatsEN>();
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

        return result;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> GetStatsByTipster (string p_Tipster_Name)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM StatsEN self where select s FROM StatsEN as s INNER JOIN s.Tipster as t WHERE t.Alias = :p_Tipster_Name";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("StatsENgetStatsByTipsterHQL");
                query.SetParameter ("p_Tipster_Name", p_Tipster_Name);

                result = query.List<PickadosGenNHibernate.EN.Pickados.StatsEN>();
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

        return result;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> GetStatsByMonthTipster (string p_Tipster_Name, PickadosGenNHibernate.Enumerated.Pickados.MonthsEnum? p_Stats_Month, int ? p_Stats_Year)
{
        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM StatsEN self where select s FROM StatsEN as s INNER JOIN s.Tipster as t WHERE t.Alias = :p_Tipster_Name AND month(date) = :p_Stats_Month AND year(date) = :p_Stats_Year";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("StatsENgetStatsByMonthTipsterHQL");
                query.SetParameter ("p_Tipster_Name", p_Tipster_Name);
                query.SetParameter ("p_Stats_Month", p_Stats_Month);
                query.SetParameter ("p_Stats_Year", p_Stats_Year);

                result = query.List<PickadosGenNHibernate.EN.Pickados.StatsEN>();
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

        return result;
}
}
}
