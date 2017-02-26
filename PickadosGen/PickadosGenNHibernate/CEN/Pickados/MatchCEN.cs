

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

public int NewMatch (Nullable<DateTime> p_date, int p_away, int p_home, string p_stadium)
{
        MatchEN matchEN = null;
        int oid;

        //Initialized MatchEN
        matchEN = new MatchEN ();
        matchEN.Date = p_date;


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

        oid = _IMatchCAD.NewMatch (matchEN);
        return oid;
}

public void ModifyMatch (int p_Match_OID, Nullable<DateTime> p_date, string p_stadium)
{
        MatchEN matchEN = null;

        //Initialized MatchEN
        matchEN = new MatchEN ();
        matchEN.Id = p_Match_OID;
        matchEN.Date = p_date;
        matchEN.Stadium = p_stadium;
        //Call to MatchCAD

        _IMatchCAD.ModifyMatch (matchEN);
}

public void DeleteMatch (int id
                         )
{
        _IMatchCAD.DeleteMatch (id);
}

public MatchEN GetMatchById (int id
                             )
{
        MatchEN matchEN = null;

        matchEN = _IMatchCAD.GetMatchById (id);
        return matchEN;
}

public System.Collections.Generic.IList<MatchEN> GetAllMatches (int first, int size)
{
        System.Collections.Generic.IList<MatchEN> list = null;

        list = _IMatchCAD.GetAllMatches (first, size);
        return list;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetMatchByCompetition (int id)
{
        return _IMatchCAD.GetMatchByCompetition (id);
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetMatchByLocalTeam (int id)
{
        return _IMatchCAD.GetMatchByLocalTeam (id);
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetMatchByVisistantTeam (int id)
{
        return _IMatchCAD.GetMatchByVisistantTeam (id);
}
}
}
