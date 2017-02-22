using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class PlayerDTO
{
private int club_team_oid;
public int Club_team_oid {
        get { return club_team_oid; } set { club_team_oid = value;  }
}



private int national_team_oid;
public int National_team_oid {
        get { return national_team_oid; } set { national_team_oid = value;  }
}

private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string name;
public string Name {
        get { return name; } set { name = value;  }
}


private System.Collections.Generic.IList<int> scorer_oid;
public System.Collections.Generic.IList<int> Scorer_oid {
        get { return scorer_oid; } set { scorer_oid = value;  }
}
}
}
