

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
 *      Definition of the class PlayerCEN
 *
 */
public partial class PlayerCEN
{
private IPlayerCAD _IPlayerCAD;

public PlayerCEN()
{
        this._IPlayerCAD = new PlayerCAD ();
}

public PlayerCEN(IPlayerCAD _IPlayerCAD)
{
        this._IPlayerCAD = _IPlayerCAD;
}

public IPlayerCAD get_IPlayerCAD ()
{
        return this._IPlayerCAD;
}

public int New_ (string p_name)
{
        PlayerEN playerEN = null;
        int oid;

        //Initialized PlayerEN
        playerEN = new PlayerEN ();
        playerEN.Name = p_name;

        //Call to PlayerCAD

        oid = _IPlayerCAD.New_ (playerEN);
        return oid;
}

public void Modify (int p_Player_OID, string p_name)
{
        PlayerEN playerEN = null;

        //Initialized PlayerEN
        playerEN = new PlayerEN ();
        playerEN.Id = p_Player_OID;
        playerEN.Name = p_name;
        //Call to PlayerCAD

        _IPlayerCAD.Modify (playerEN);
}

public void Destroy (int id
                     )
{
        _IPlayerCAD.Destroy (id);
}

public void JoinClubTeam (int p_Player_OID, int p_club_team_OID)
{
        //Call to PlayerCAD

        _IPlayerCAD.JoinClubTeam (p_Player_OID, p_club_team_OID);
}
public void JoinNationalTeam (int p_Player_OID, int p_national_team_OID)
{
        //Call to PlayerCAD

        _IPlayerCAD.JoinNationalTeam (p_Player_OID, p_national_team_OID);
}
public void UnlinkClubTeam (int p_Player_OID, int p_club_team_OID)
{
        //Call to PlayerCAD

        _IPlayerCAD.UnlinkClubTeam (p_Player_OID, p_club_team_OID);
}
public void UnlinkNationalTeam (int p_Player_OID, int p_national_team_OID)
{
        //Call to PlayerCAD

        _IPlayerCAD.UnlinkNationalTeam (p_Player_OID, p_national_team_OID);
}
}
}
