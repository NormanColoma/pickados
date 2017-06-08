
using System;
// Definición clase LoginEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class LoginEN
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
 *	Atributo date
 */
private Nullable<DateTime> date;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Alias {
        get { return alias; } set { alias = value;  }
}



public virtual Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}





public LoginEN()
{
}



public LoginEN(int id, string alias, Nullable<DateTime> date
               )
{
        this.init (Id, alias, date);
}


public LoginEN(LoginEN login)
{
        this.init (Id, login.Alias, login.Date);
}

private void init (int id
                   , string alias, Nullable<DateTime> date)
{
        this.Id = id;


        this.Alias = alias;

        this.Date = date;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        LoginEN t = obj as LoginEN;
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
