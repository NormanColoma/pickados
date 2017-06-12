using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class RoundDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int season_oid;
public int Season_oid {
        get { return season_oid; } set { season_oid = value;  }
}



private System.Collections.Generic.IList<int> event__oid;
public System.Collections.Generic.IList<int> Event__oid {
        get { return event__oid; } set { event__oid = value;  }
}

private string name;
public string Name {
        get { return name; } set { name = value;  }
}
}
}
