
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



/**
 *	Atributo place
 */
private string place;



/**
 *	Atributo team
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TeamEN> team;






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



public virtual string Place {
        get { return place; } set { place = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TeamEN> Team {
        get { return team; } set { team = value;  }
}





public CompetitionEN()
{
        event_ = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.Event_EN>();
        team = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.TeamEN>();
}



public CompetitionEN(int id, string name, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> event_, PickadosGenNHibernate.EN.Pickados.SportEN sport, string place, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TeamEN> team
                     )
{
        this.init (Id, name, event_, sport, place, team);
}


public CompetitionEN(CompetitionEN competition)
{
        this.init (Id, competition.Name, competition.Event_, competition.Sport, competition.Place, competition.Team);
}

private void init (int id
                   , string name, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.Event_EN> event_, PickadosGenNHibernate.EN.Pickados.SportEN sport, string place, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TeamEN> team)
{
        this.Id = id;


        this.Name = name;

        this.Event_ = event_;

        this.Sport = sport;

        this.Place = place;

        this.Team = team;
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
