
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
               string alias, string email, String password, Nullable<DateTime> created_at, Nullable<DateTime> updated_at, string nif, bool admin
               )
{
        this.init (Id, alias, email, password, created_at, updated_at, nif, admin);
}


public AdminEN(AdminEN admin)
{
        this.init (Id, admin.Alias, admin.Email, admin.Password, admin.Created_at, admin.Updated_at, admin.Nif, admin.Admin);
}

private void init (int id
                   , string alias, string email, String password, Nullable<DateTime> created_at, Nullable<DateTime> updated_at, string nif, bool admin)
{
        this.Id = id;


        this.Alias = alias;

        this.Email = email;

        this.Password = password;

        this.Created_at = created_at;

        this.Updated_at = updated_at;

        this.Nif = nif;

        this.Admin = admin;
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
