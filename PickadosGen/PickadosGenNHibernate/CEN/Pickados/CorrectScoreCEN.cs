

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
 *      Definition of the class CorrectScoreCEN
 *
 */
public partial class CorrectScoreCEN
{
private ICorrectScoreCAD _ICorrectScoreCAD;

public CorrectScoreCEN()
{
        this._ICorrectScoreCAD = new CorrectScoreCAD ();
}

public CorrectScoreCEN(ICorrectScoreCAD _ICorrectScoreCAD)
{
        this._ICorrectScoreCAD = _ICorrectScoreCAD;
}

public ICorrectScoreCAD get_ICorrectScoreCAD ()
{
        return this._ICorrectScoreCAD;
}

public int NewCorrectScore (double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel, int p_homeScore, int p_awayScore)
{
        CorrectScoreEN correctScoreEN = null;
        int oid;

        //Initialized CorrectScoreEN
        correctScoreEN = new CorrectScoreEN ();
        correctScoreEN.Odd = p_odd;

        correctScoreEN.Description = p_description;

        correctScoreEN.PickResult = p_pickResult;

        correctScoreEN.Bookie = p_bookie;


        if (p_event_rel != -1) {
                // El argumento p_event_rel -> Property event_rel es oid = false
                // Lista de oids id
                correctScoreEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN ();
                correctScoreEN.Event_rel.Id = p_event_rel;
        }

        correctScoreEN.HomeScore = p_homeScore;

        correctScoreEN.AwayScore = p_awayScore;

        //Call to CorrectScoreCAD

        oid = _ICorrectScoreCAD.NewCorrectScore (correctScoreEN);
        return oid;
}

public void ModifyCorrectScore (int p_CorrectScore_OID, double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_homeScore, int p_awayScore)
{
        CorrectScoreEN correctScoreEN = null;

        //Initialized CorrectScoreEN
        correctScoreEN = new CorrectScoreEN ();
        correctScoreEN.Id = p_CorrectScore_OID;
        correctScoreEN.Odd = p_odd;
        correctScoreEN.Description = p_description;
        correctScoreEN.PickResult = p_pickResult;
        correctScoreEN.Bookie = p_bookie;
        correctScoreEN.HomeScore = p_homeScore;
        correctScoreEN.AwayScore = p_awayScore;
        //Call to CorrectScoreCAD

        _ICorrectScoreCAD.ModifyCorrectScore (correctScoreEN);
}

public void DeleteCorrectScore (int id
                                )
{
        _ICorrectScoreCAD.DeleteCorrectScore (id);
}
}
}
