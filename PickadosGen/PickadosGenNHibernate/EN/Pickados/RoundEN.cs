
using System;
// Definición clase RoundEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class RoundEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo season
 */
private PickadosGenNHibernate.EN.Pickados.SeasonEN season;



/**
 *	Atributo event_
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> event_;



/**
 *	Atributo name
 */
private string name;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PickadosGenNHibernate.EN.Pickados.SeasonEN Season {
        get { return season; } set { season = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> Event_ {
        get { return event_; } set { event_ = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}





public RoundEN()
{
        event_ = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.Event_EN>();
}



public RoundEN(int id, PickadosGenNHibernate.EN.Pickados.SeasonEN season, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> event_, string name
               )
{
        this.init (Id, season, event_, name);
}


public RoundEN(RoundEN round)
{
        this.init (Id, round.Season, round.Event_, round.Name);
}

private void init (int id
                   , PickadosGenNHibernate.EN.Pickados.SeasonEN season, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> event_, string name)
{
        this.Id = id;


        this.Season = season;

        this.Event_ = event_;

        this.Name = name;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        RoundEN t = obj as RoundEN;
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
