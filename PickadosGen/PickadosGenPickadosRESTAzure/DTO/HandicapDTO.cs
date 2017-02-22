using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class HandicapDTO                :                           GoalDTO


{
private PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result;
public PickadosGenNHibernate.Enumerated.Pickados.ResultEnum Result {
        get { return result; } set { result = value;  }
}
}
}
