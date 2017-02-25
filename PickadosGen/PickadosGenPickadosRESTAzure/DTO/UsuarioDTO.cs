using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class UsuarioDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private string alias;
public string Alias {
        get { return alias; } set { alias = value;  }
}
private string email;
public string Email {
        get { return email; } set { email = value;  }
}
private String password;
public String Password {
        get { return password; } set { password = value;  }
}
private Nullable<DateTime> created_at;
public Nullable<DateTime> Created_at {
        get { return created_at; } set { created_at = value;  }
}
private Nullable<DateTime> updated_at;
public Nullable<DateTime> Updated_at {
        get { return updated_at; } set { updated_at = value;  }
}
private string nif;
public string Nif {
        get { return nif; } set { nif = value;  }
}
}
}
