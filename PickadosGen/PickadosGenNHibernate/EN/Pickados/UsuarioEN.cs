
using System;
// Definición clase UsuarioEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class UsuarioEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo alias
 */
private string alias;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo password
 */
private String password;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Alias {
        get { return alias; } set { alias = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}





public UsuarioEN()
{
}



public UsuarioEN(int id, string alias, string email, String password
                 )
{
        this.init (Id, alias, email, password);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (Id, usuario.Alias, usuario.Email, usuario.Password);
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
        UsuarioEN t = obj as UsuarioEN;
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
