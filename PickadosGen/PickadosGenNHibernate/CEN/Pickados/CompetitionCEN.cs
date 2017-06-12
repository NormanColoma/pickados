

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
 *      Definition of the class CompetitionCEN
 *
 */
public partial class CompetitionCEN
{
private ICompetitionCAD _ICompetitionCAD;

public CompetitionCEN()
{
        this._ICompetitionCAD = new CompetitionCAD ();
}

public CompetitionCEN(ICompetitionCAD _ICompetitionCAD)
{
        this._ICompetitionCAD = _ICompetitionCAD;
}

public ICompetitionCAD get_ICompetitionCAD ()
{
        return this._ICompetitionCAD;
}

public int NewCompetition (string p_name, int p_sport, string p_place, bool p_clubs, System.Collections.Generic.IList<int> p_season)
{
        CompetitionEN competitionEN = null;
        int oid;

        //Initialized CompetitionEN
        competitionEN = new CompetitionEN ();
        competitionEN.Name = p_name;


        if (p_sport != -1) {
                // El argumento p_sport -> Property sport es oid = false
                // Lista de oids id
                competitionEN.Sport = new PickadosGenNHibernate.EN.Pickados.SportEN ();
                competitionEN.Sport.Id = p_sport;
        }

        competitionEN.Place = p_place;

        competitionEN.Clubs = p_clubs;


        competitionEN.Season = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.SeasonEN>();
        if (p_season != null) {
                foreach (int item in p_season) {
                        PickadosGenNHibernate.EN.Pickados.SeasonEN en = new PickadosGenNHibernate.EN.Pickados.SeasonEN ();
                        en.Id = item;
                        competitionEN.Season.Add (en);
                }
        }

        else{
                competitionEN.Season = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.SeasonEN>();
        }

        //Call to CompetitionCAD

        oid = _ICompetitionCAD.NewCompetition (competitionEN);
        return oid;
}

public void ModifyCompetition (int p_Competition_OID, string p_name, string p_place, bool p_clubs)
{
        CompetitionEN competitionEN = null;

        //Initialized CompetitionEN
        competitionEN = new CompetitionEN ();
        competitionEN.Id = p_Competition_OID;
        competitionEN.Name = p_name;
        competitionEN.Place = p_place;
        competitionEN.Clubs = p_clubs;
        //Call to CompetitionCAD

        _ICompetitionCAD.ModifyCompetition (competitionEN);
}

public void DeleteCompetition (int id
                               )
{
        _ICompetitionCAD.DeleteCompetition (id);
}

public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetCompetitionsByPlace (string place)
{
        return _ICompetitionCAD.GetCompetitionsByPlace (place);
}
public CompetitionEN GetCompetitionById (int id
                                         )
{
        CompetitionEN competitionEN = null;

        competitionEN = _ICompetitionCAD.GetCompetitionById (id);
        return competitionEN;
}

public System.Collections.Generic.IList<CompetitionEN> GetAllCompetitions (int first, int size)
{
        System.Collections.Generic.IList<CompetitionEN> list = null;

        list = _ICompetitionCAD.GetAllCompetitions (first, size);
        return list;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetCompetitionByTeam (int id)
{
        return _ICompetitionCAD.GetCompetitionByTeam (id);
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetCompetitionBySport (int id)
{
        return _ICompetitionCAD.GetCompetitionBySport (id);
}
public System.Collections.Generic.IList<string> GetPlaces ()
{
        return _ICompetitionCAD.GetPlaces ();
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetClubCompetition ()
{
        return _ICompetitionCAD.GetClubCompetition ();
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> GetNationalCompetition ()
{
        return _ICompetitionCAD.GetNationalCompetition ();
}
public System.Collections.Generic.IList<string> GetClubPlaces ()
{
        return _ICompetitionCAD.GetClubPlaces ();
}
public System.Collections.Generic.IList<string> GetNationalPlaces ()
{
        return _ICompetitionCAD.GetNationalPlaces ();
}
}
}
