using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class PickDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private double odd;
public double Odd {
        get { return odd; } set { odd = value;  }
}
private string description;
public string Description {
        get { return description; } set { description = value;  }
}
private PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult;
public PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum PickResult {
        get { return pickResult; } set { pickResult = value;  }
}
private string bookie;
public string Bookie {
        get { return bookie; } set { bookie = value;  }
}


private System.Collections.Generic.IList<int> post_oid;
public System.Collections.Generic.IList<int> Post_oid {
        get { return post_oid; } set { post_oid = value;  }
}



private int event_rel_oid;
public int Event_rel_oid {
        get { return event_rel_oid; } set { event_rel_oid = value;  }
}
}
}
