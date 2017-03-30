using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class NationalTeamDTOA
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


/* Rol: NationalTeam o--> Player */
private IList<PlayerDTOA> getAllNational_playerOfNational_team;
public IList<PlayerDTOA> GetAllNational_playerOfNational_team
{
        get { return getAllNational_playerOfNational_team; }
        set { getAllNational_playerOfNational_team = value; }
}
}
}
