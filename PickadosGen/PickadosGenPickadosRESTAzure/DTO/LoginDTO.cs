using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class LoginDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string alias;
public string Alias {
        get { return alias; } set { alias = value;  }
}
private Nullable<DateTime> date;
public Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}
}
}
