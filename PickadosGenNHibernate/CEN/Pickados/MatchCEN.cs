

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
 *      Definition of the class MatchCEN
 *
 */
public partial class MatchCEN
{
private IMatchCAD _IMatchCAD;

public MatchCEN()
{
        this._IMatchCAD = new MatchCAD ();
}

public MatchCEN(IMatchCAD _IMatchCAD)
{
        this._IMatchCAD = _IMatchCAD;
}

public IMatchCAD get_IMatchCAD ()
{
        return this._IMatchCAD;
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetTeams ()
{
        return _IMatchCAD.GetTeams ();
}
public void AddVisitante (int p_Match_OID, int p_away_OID)
{
        //Call to MatchCAD

        _IMatchCAD.AddVisitante (p_Match_OID, p_away_OID);
}
public void AddLocal (int p_Match_OID, int p_home_OID)
{
        //Call to MatchCAD

        _IMatchCAD.AddLocal (p_Match_OID, p_home_OID);
}
public int New_ (TimeSpan p_hour, string p_place, int p_away, int p_home, string p_stadium)
{
        MatchEN matchEN = null;
        int oid;

        //Initialized MatchEN
        matchEN = new MatchEN ();
        matchEN.Hour = p_hour;

        matchEN.Place = p_place;


        if (p_away != -1) {
                // El argumento p_away -> Property away es oid = false
                // Lista de oids id
                matchEN.Away = new PickadosGenNHibernate.EN.Pickados.TeamEN ();
                matchEN.Away.Id = p_away;
        }


        if (p_home != -1) {
                // El argumento p_home -> Property home es oid = false
                // Lista de oids id
                matchEN.Home = new PickadosGenNHibernate.EN.Pickados.TeamEN ();
                matchEN.Home.Id = p_home;
        }

        matchEN.Stadium = p_stadium;

        //Call to MatchCAD

        oid = _IMatchCAD.New_ (matchEN);
        return oid;
}

public void Modify (int p_Match_OID, TimeSpan p_hour, string p_place, string p_stadium)
{
        MatchEN matchEN = null;

        //Initialized MatchEN
        matchEN = new MatchEN ();
        matchEN.Id = p_Match_OID;
        matchEN.Hour = p_hour;
        matchEN.Place = p_place;
        matchEN.Stadium = p_stadium;
        //Call to MatchCAD

        _IMatchCAD.Modify (matchEN);
}

public void Destroy (int id
                     )
{
        _IMatchCAD.Destroy (id);
}
}
}
