using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class ResultDTO                  :                           PickDTO


{
private PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result;
public PickadosGenNHibernate.Enumerated.Pickados.ResultEnum Result {
        get { return result; } set { result = value;  }
}
private PickadosGenNHibernate.Enumerated.Pickados.TimeEnum matchtime;
public PickadosGenNHibernate.Enumerated.Pickados.TimeEnum Matchtime {
        get { return matchtime; } set { matchtime = value;  }
}
}
}
