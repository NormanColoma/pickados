using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class CompetitionDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string name;
public string Name
{
        get { return name; }
        set { name = value; }
}

private string place;
public string Place
{
        get { return place; }
        set { place = value; }
}


/* Rol: Competition o--> Match */
private IList<MatchDTOA> getAllEventOfCompetition;
public IList<MatchDTOA> GetAllEventOfCompetition
{
        get { return getAllEventOfCompetition; }
        set { getAllEventOfCompetition = value; }
}
}
}
