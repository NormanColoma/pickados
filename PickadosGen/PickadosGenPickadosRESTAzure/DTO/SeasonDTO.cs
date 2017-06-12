using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class SeasonDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private Nullable<DateTime> initDate;
public Nullable<DateTime> InitDate {
        get { return initDate; } set { initDate = value;  }
}
private Nullable<DateTime> finalDate;
public Nullable<DateTime> FinalDate {
        get { return finalDate; } set { finalDate = value;  }
}


private int competition_oid;
public int Competition_oid {
        get { return competition_oid; } set { competition_oid = value;  }
}



private System.Collections.Generic.IList<int> round_oid;
public System.Collections.Generic.IList<int> Round_oid {
        get { return round_oid; } set { round_oid = value;  }
}
}
}
