using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class TeamDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string name;
public string Name {
        get { return name; } set { name = value;  }
}
private string country;
public string Country {
        get { return country; } set { country = value;  }
}


private System.Collections.Generic.IList<int> event_home_oid;
public System.Collections.Generic.IList<int> Event_home_oid {
        get { return event_home_oid; } set { event_home_oid = value;  }
}



private System.Collections.Generic.IList<int> event_away_oid;
public System.Collections.Generic.IList<int> Event_away_oid {
        get { return event_away_oid; } set { event_away_oid = value;  }
}



private System.Collections.Generic.IList<int> club_player_oid;
public System.Collections.Generic.IList<int> Club_player_oid {
        get { return club_player_oid; } set { club_player_oid = value;  }
}



private System.Collections.Generic.IList<int> national_player_oid;
public System.Collections.Generic.IList<int> National_player_oid {
        get { return national_player_oid; } set { national_player_oid = value;  }
}
}
}
