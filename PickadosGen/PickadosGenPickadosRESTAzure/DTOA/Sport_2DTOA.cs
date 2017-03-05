using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class Sport_2DTOA
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


/* Rol: Sport_2 o--> Competition */
private IList<CompetitionDTOA> getAllCompetitionOfSport;
public IList<CompetitionDTOA> GetAllCompetitionOfSport
{
        get { return getAllCompetitionOfSport; }
        set { getAllCompetitionOfSport = value; }
}
}
}
