using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class GoalDTO                    :                           PickDTO


{
private PickadosGenNHibernate.Enumerated.Pickados.LineEnum line;
public PickadosGenNHibernate.Enumerated.Pickados.LineEnum Line {
        get { return line; } set { line = value;  }
}
private double quantity;
public double Quantity {
        get { return quantity; } set { quantity = value;  }
}
private bool asian;
public bool Asian {
        get { return asian; } set { asian = value;  }
}
}
}
