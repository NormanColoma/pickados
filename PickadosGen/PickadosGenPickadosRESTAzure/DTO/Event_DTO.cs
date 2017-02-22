using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class Event_DTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}


private int competition_oid;
public int Competition_oid {
        get { return competition_oid; } set { competition_oid = value;  }
}

private System.Collections.Generic.IList<PickDTO> pick_rel;
public System.Collections.Generic.IList<PickDTO> Pick_rel {
        get { return pick_rel; } set { pick_rel = value;  }
}
private Nullable<DateTime> date;
public Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}
}
}
