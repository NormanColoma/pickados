
using System;
// Definición clase GoalEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class GoalEN                                                                 : PickadosGenNHibernate.EN.Pickados.PickEN


{
/**
 *	Atributo line
 */
private PickadosGenNHibernate.Enumerated.Pickados.LineEnum line;



/**
 *	Atributo quantity
 */
private double quantity;



/**
 *	Atributo asian
 */
private bool asian;






public virtual PickadosGenNHibernate.Enumerated.Pickados.LineEnum Line {
        get { return line; } set { line = value;  }
}



public virtual double Quantity {
        get { return quantity; } set { quantity = value;  }
}



public virtual bool Asian {
        get { return asian; } set { asian = value;  }
}





public GoalEN() : base ()
{
}



public GoalEN(int id, PickadosGenNHibernate.Enumerated.Pickados.LineEnum line, double quantity, bool asian
              , double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel
              )
{
        this.init (Id, line, quantity, asian, odd, description, pickResult, bookie, post, event_rel);
}


public GoalEN(GoalEN goal)
{
        this.init (Id, goal.Line, goal.Quantity, goal.Asian, goal.Odd, goal.Description, goal.PickResult, goal.Bookie, goal.Post, goal.Event_rel);
}

private void init (int id
                   , PickadosGenNHibernate.Enumerated.Pickados.LineEnum line, double quantity, bool asian, double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel)
{
        this.Id = id;


        this.Line = line;

        this.Quantity = quantity;

        this.Asian = asian;

        this.Odd = odd;

        this.Description = description;

        this.PickResult = pickResult;

        this.Bookie = bookie;

        this.Post = post;

        this.Event_rel = event_rel;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        GoalEN t = obj as GoalEN;
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
