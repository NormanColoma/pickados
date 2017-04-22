using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class MatchDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string stadium;
public string Stadium
{
        get { return stadium; }
        set { stadium = value; }
}

private Nullable<DateTime> date;
public Nullable<DateTime> Date
{
        get { return date; }
        set { date = value; }
}


/* Rol: Match o--> Team */
private TeamDTOA getHomeOfEvent_home;
public TeamDTOA GetHomeOfEvent_home
{
        get { return getHomeOfEvent_home; }
        set { getHomeOfEvent_home = value; }
}

/* Rol: Match o--> Team */
private TeamDTOA getAwayOfEvent_away;
public TeamDTOA GetAwayOfEvent_away
{
        get { return getAwayOfEvent_away; }
        set { getAwayOfEvent_away = value; }
}
}
}
