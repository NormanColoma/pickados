using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class MatchDTO                   :                           Event_DTO


{
private int away_oid;
public int Away_oid {
        get { return away_oid; } set { away_oid = value;  }
}



private int home_oid;
public int Home_oid {
        get { return home_oid; } set { home_oid = value;  }
}

private string stadium;
public string Stadium {
        get { return stadium; } set { stadium = value;  }
}
}
}
