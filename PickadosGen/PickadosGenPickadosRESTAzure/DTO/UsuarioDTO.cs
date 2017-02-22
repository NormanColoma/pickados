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
private TimeSpan createdAt;
public TimeSpan CreatedAt {
        get { return createdAt; } set { createdAt = value;  }
}
private TimeSpan modifiedAt;
public TimeSpan ModifiedAt {
        get { return modifiedAt; } set { modifiedAt = value;  }
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
}
}
