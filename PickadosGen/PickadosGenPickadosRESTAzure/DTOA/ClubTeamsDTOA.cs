using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class ClubTeamsDTOA
{
private string name;
public string Name
{
        get { return name; }
        set { name = value; }
}

private string country;
public string Country
{
        get { return country; }
        set { country = value; }
}

private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


/* Rol: ClubTeams o--> Player */
private IList<PlayerDTOA> getAllClub_playerOfClub_team;
public IList<PlayerDTOA> GetAllClub_playerOfClub_team
{
        get { return getAllClub_playerOfClub_team; }
        set { getAllClub_playerOfClub_team = value; }
}
}
}
