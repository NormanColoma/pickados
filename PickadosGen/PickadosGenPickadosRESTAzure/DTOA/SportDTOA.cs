using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class SportDTOA
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


/* GetAll: Competition */
private IList<CompetitionDTOA> getAllCompetition;
public IList<CompetitionDTOA> GetAllCompetition
{
        get { return getAllCompetition; }
        set { getAllCompetition = value; }
}
}
}
