

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
 *      Definition of the class TeamCEN
 *
 */
public partial class TeamCEN
{
private ITeamCAD _ITeamCAD;

public TeamCEN()
{
        this._ITeamCAD = new TeamCAD ();
}

public TeamCEN(ITeamCAD _ITeamCAD)
{
        this._ITeamCAD = _ITeamCAD;
}

public ITeamCAD get_ITeamCAD ()
{
        return this._ITeamCAD;
}

public int NewTeam (string p_name, string p_country)
{
        TeamEN teamEN = null;
        int oid;

        //Initialized TeamEN
        teamEN = new TeamEN ();
        teamEN.Name = p_name;

        teamEN.Country = p_country;

        //Call to TeamCAD

        oid = _ITeamCAD.NewTeam (teamEN);
        return oid;
}

public void ModifyTeam (int p_Team_OID, string p_name, string p_country)
{
        TeamEN teamEN = null;

        //Initialized TeamEN
        teamEN = new TeamEN ();
        teamEN.Id = p_Team_OID;
        teamEN.Name = p_name;
        teamEN.Country = p_country;
        //Call to TeamCAD

        _ITeamCAD.ModifyTeam (teamEN);
}

public void DeleteTeam (int id
                        )
{
        _ITeamCAD.DeleteTeam (id);
}

public TeamEN GetTeamById (int id
                           )
{
        TeamEN teamEN = null;

        teamEN = _ITeamCAD.GetTeamById (id);
        return teamEN;
}

public System.Collections.Generic.IList<TeamEN> GetAllTeams (int first, int size)
{
        System.Collections.Generic.IList<TeamEN> list = null;

        list = _ITeamCAD.GetAllTeams (first, size);
        return list;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TeamEN> GetTeamByCompetition (int id)
{
        return _ITeamCAD.GetTeamByCompetition (id);
}
public void AddCompetition (int p_Team_OID, System.Collections.Generic.IList<int> p_competition_OIDs)
{
        //Call to TeamCAD

        _ITeamCAD.AddCompetition (p_Team_OID, p_competition_OIDs);
}
}
}
