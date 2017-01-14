
using System;
// Definición clase CompetitionEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class CompetitionEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo name
 */
private string name;



/**
 *	Atributo event_
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> event_;



/**
 *	Atributo sport
 */
private PickadosGenNHibernate.EN.Pickados.SportEN sport;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> Event_ {
        get { return event_; } set { event_ = value;  }
}



public virtual PickadosGenNHibernate.EN.Pickados.SportEN Sport {
        get { return sport; } set { sport = value;  }
}





public CompetitionEN()
{
        event_ = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.Event_EN>();
}



public CompetitionEN(int id, string name, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> event_, PickadosGenNHibernate.EN.Pickados.SportEN sport
                     )
{
        this.init (Id, name, event_, sport);
}


public CompetitionEN(CompetitionEN competition)
{
        this.init (Id, competition.Name, competition.Event_, competition.Sport);
}

private void init (int id
                   , string name, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> event_, PickadosGenNHibernate.EN.Pickados.SportEN sport)
{
        this.Id = id;


        this.Name = name;

        this.Event_ = event_;

        this.Sport = sport;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CompetitionEN t = obj as CompetitionEN;
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
