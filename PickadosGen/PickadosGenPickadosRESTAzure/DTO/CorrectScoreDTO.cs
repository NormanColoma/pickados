using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class CorrectScoreDTO                    :                           PickDTO


{
private int homeScore;
public int HomeScore {
        get { return homeScore; } set { homeScore = value;  }
}
private int awayScore;
public int AwayScore {
        get { return awayScore; } set { awayScore = value;  }
}
}
}
