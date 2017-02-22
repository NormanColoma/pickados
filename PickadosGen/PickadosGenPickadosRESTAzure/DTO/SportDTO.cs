using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class SportDTO
{
private System.Collections.Generic.IList<CompetitionDTO> competition;
public System.Collections.Generic.IList<CompetitionDTO> Competition {
        get { return competition; } set { competition = value;  }
}
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string name;
public string Name {
        get { return name; } set { name = value;  }
}
}
}
