

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
}
}
