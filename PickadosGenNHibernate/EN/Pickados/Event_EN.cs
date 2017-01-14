
using System;
// Definición clase Event_EN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class Event_EN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo competition
 */
private PickadosGenNHibernate.EN.Pickados.CompetitionEN competition;



/**
 *	Atributo pick_rel
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick_rel;



/**
 *	Atributo hour
 */
private TimeSpan hour;



/**
 *	Atributo place
 */
private string place;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual PickadosGenNHibernate.EN.Pickados.CompetitionEN Competition {
        get { return competition; } set { competition = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> Pick_rel {
        get { return pick_rel; } set { pick_rel = value;  }
}



public virtual TimeSpan Hour {
        get { return hour; } set { hour = value;  }
}



public virtual string Place {
        get { return place; } set { place = value;  }
}





public Event_EN()
{
        pick_rel = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
}



public Event_EN(int id, PickadosGenNHibernate.EN.Pickados.CompetitionEN competition, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick_rel, TimeSpan hour, string place
                )
{
        this.init (Id, competition, pick_rel, hour, place);
}


public Event_EN(Event_EN event_)
{
        this.init (Id, event_.Competition, event_.Pick_rel, event_.Hour, event_.Place);
}

private void init (int id
                   , PickadosGenNHibernate.EN.Pickados.CompetitionEN competition, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick_rel, TimeSpan hour, string place)
{
        this.Id = id;


        this.Competition = competition;

        this.Pick_rel = pick_rel;

        this.Hour = hour;

        this.Place = place;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        Event_EN t = obj as Event_EN;
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
