

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
 *      Definition of the class TimecastCEN
 *
 */
public partial class TimecastCEN
{
private ITimecastCAD _ITimecastCAD;

public TimecastCEN()
{
        this._ITimecastCAD = new TimecastCAD ();
}

public TimecastCEN(ITimecastCAD _ITimecastCAD)
{
        this._ITimecastCAD = _ITimecastCAD;
}

public ITimecastCAD get_ITimecastCAD ()
{
        return this._ITimecastCAD;
}

public int NewTimecast (double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel, string p_scorer_name, int p_player, string p_score_time)
{
        TimecastEN timecastEN = null;
        int oid;

        //Initialized TimecastEN
        timecastEN = new TimecastEN ();
        timecastEN.Odd = p_odd;

        timecastEN.Description = p_description;

        timecastEN.PickResult = p_pickResult;

        timecastEN.Bookie = p_bookie;


        if (p_event_rel != -1) {
                // El argumento p_event_rel -> Property event_rel es oid = false
                // Lista de oids id
                timecastEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN ();
                timecastEN.Event_rel.Id = p_event_rel;
        }

        timecastEN.Scorer_name = p_scorer_name;


        if (p_player != -1) {
                // El argumento p_player -> Property player es oid = false
                // Lista de oids id
                timecastEN.Player = new PickadosGenNHibernate.EN.Pickados.PlayerEN ();
                timecastEN.Player.Id = p_player;
        }

        timecastEN.Score_time = p_score_time;

        //Call to TimecastCAD

        oid = _ITimecastCAD.NewTimecast (timecastEN);
        return oid;
}

public void ModifyTimecast (int p_Timecast_OID, double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, string p_scorer_name, string p_score_time)
{
        TimecastEN timecastEN = null;

        //Initialized TimecastEN
        timecastEN = new TimecastEN ();
        timecastEN.Id = p_Timecast_OID;
        timecastEN.Odd = p_odd;
        timecastEN.Description = p_description;
        timecastEN.PickResult = p_pickResult;
        timecastEN.Bookie = p_bookie;
        timecastEN.Scorer_name = p_scorer_name;
        timecastEN.Score_time = p_score_time;
        //Call to TimecastCAD

        _ITimecastCAD.ModifyTimecast (timecastEN);
}

public void DeleteTimecast (int id
                            )
{
        _ITimecastCAD.DeleteTimecast (id);
}
}
}
