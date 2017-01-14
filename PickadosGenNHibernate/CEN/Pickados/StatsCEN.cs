

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;

using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;


namespace PickadosGenNHibernate.CEN.Pickados
{
/*
 *      Definition of the class StatsCEN
 *
 */
public partial class StatsCEN
{
private IStatsCAD _IStatsCAD;

public StatsCEN()
{
        this._IStatsCAD = new StatsCAD ();
}

public StatsCEN(IStatsCAD _IStatsCAD)
{
        this._IStatsCAD = _IStatsCAD;
}

public IStatsCAD get_IStatsCAD ()
{
        return this._IStatsCAD;
}

public int NewMonthlyStats (double p_benefit, double p_stakeAverage, float p_yield, double p_oddAverage, int p_totalPicks, Nullable<DateTime> p_initialDate, int p_tipster)
{
        StatsEN statsEN = null;
        int oid;

        //Initialized StatsEN
        statsEN = new StatsEN ();
        statsEN.Benefit = p_benefit;

        statsEN.StakeAverage = p_stakeAverage;

        statsEN.Yield = p_yield;

        statsEN.OddAverage = p_oddAverage;

        statsEN.TotalPicks = p_totalPicks;

        statsEN.InitialDate = p_initialDate;


        if (p_tipster != -1) {
                // El argumento p_tipster -> Property tipster es oid = false
                // Lista de oids id
                statsEN.Tipster = new PickadosGenNHibernate.EN.Pickados.TipsterEN ();
                statsEN.Tipster.Id = p_tipster;
        }

        //Call to StatsCAD

        oid = _IStatsCAD.NewMonthlyStats (statsEN);
        return oid;
}

public void ModifyMonthlyStats (int p_Stats_OID, double p_benefit, double p_stakeAverage, float p_yield, double p_oddAverage, int p_totalPicks, Nullable<DateTime> p_initialDate)
{
        StatsEN statsEN = null;

        //Initialized StatsEN
        statsEN = new StatsEN ();
        statsEN.Id = p_Stats_OID;
        statsEN.Benefit = p_benefit;
        statsEN.StakeAverage = p_stakeAverage;
        statsEN.Yield = p_yield;
        statsEN.OddAverage = p_oddAverage;
        statsEN.TotalPicks = p_totalPicks;
        statsEN.InitialDate = p_initialDate;
        //Call to StatsCAD

        _IStatsCAD.ModifyMonthlyStats (statsEN);
}

public void DeleteMonthlyStats (int id
                                )
{
        _IStatsCAD.DeleteMonthlyStats (id);
}
}
}
