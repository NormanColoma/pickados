using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class TimecastDTO                :                           ScorerDTO


{
private string score_time;
public string Score_time {
        get { return score_time; } set { score_time = value;  }
}
}
}
