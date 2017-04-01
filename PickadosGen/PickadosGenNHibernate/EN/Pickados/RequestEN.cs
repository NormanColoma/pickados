
using System;
// Definición clase RequestEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class RequestEN
{
/**
 *	Atributo post
 */
private PickadosGenNHibernate.EN.Pickados.PostEN post;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo type
 */
private PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum type;



/**
 *	Atributo reason
 */
private string reason;



/**
 *	Atributo state
 */
private PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum state;



/**
 *	Atributo date
 */
private Nullable<DateTime> date;






public virtual PickadosGenNHibernate.EN.Pickados.PostEN Post {
        get { return post; } set { post = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum Type {
        get { return type; } set { type = value;  }
}



public virtual string Reason {
        get { return reason; } set { reason = value;  }
}



public virtual PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum State {
        get { return state; } set { state = value;  }
}



public virtual Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}





public RequestEN()
{
}



public RequestEN(int id, PickadosGenNHibernate.EN.Pickados.PostEN post, PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum type, string reason, PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum state, Nullable<DateTime> date
                 )
{
        this.init (Id, post, type, reason, state, date);
}


public RequestEN(RequestEN request)
{
        this.init (Id, request.Post, request.Type, request.Reason, request.State, request.Date);
}

private void init (int id
                   , PickadosGenNHibernate.EN.Pickados.PostEN post, PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum type, string reason, PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum state, Nullable<DateTime> date)
{
        this.Id = id;


        this.Post = post;

        this.Type = type;

        this.Reason = reason;

        this.State = state;

        this.Date = date;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RequestEN t = obj as RequestEN;
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
