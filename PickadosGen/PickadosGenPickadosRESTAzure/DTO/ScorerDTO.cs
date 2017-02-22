using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class ScorerDTO                  :                           PickDTO


{
private string scorer_name;
public string Scorer_name {
        get { return scorer_name; } set { scorer_name = value;  }
}


private int player_oid;
public int Player_oid {
        get { return player_oid; } set { player_oid = value;  }
}
}
}
