using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class CompetitionDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string name;
public string Name {
        get { return name; } set { name = value;  }
}
private System.Collections.Generic.IList<Event_DTO> event_;
public System.Collections.Generic.IList<Event_DTO> Event_ {
        get { return event_; } set { event_ = value;  }
}


private int sport_oid;
public int Sport_oid {
        get { return sport_oid; } set { sport_oid = value;  }
}

private string place;
public string Place {
        get { return place; } set { place = value;  }
}
}
}
