
using System;
// Definición clase AdminEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class AdminEN                                                                        : PickadosGenNHibernate.EN.Pickados.UsuarioEN


{
public AdminEN() : base ()
{
}



public AdminEN(int id,
               string alias, string email, String password
               )
{
        this.init (Id, alias, email, password);
}


public AdminEN(AdminEN admin)
{
        this.init (Id, admin.Alias, admin.Email, admin.Password);
}

private void init (int id
                   , string alias, string email, String password)
{
        this.Id = id;


        this.Alias = alias;

        this.Email = email;

        this.Password = password;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
