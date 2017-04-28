
using System;
// Definición clase TeamEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class TeamEN
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
 *	Atributo country
 */
private string country;



/**
 *	Atributo event_home
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> event_home;



/**
 *	Atributo event_away
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> event_away;



/**
 *	Atributo club_player
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> club_player;



/**
 *	Atributo national_player
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> national_player;



/**
 *	Atributo competition
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> competition;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}



public virtual string Country {
        get { return country; } set { country = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> Event_home {
        get { return event_home; } set { event_home = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> Event_away {
        get { return event_away; } set { event_away = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> Club_player {
        get { return club_player; } set { club_player = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> National_player {
        get { return national_player; } set { national_player = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> Competition {
        get { return competition; } set { competition = value;  }
}





public TeamEN()
{
        event_home = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.MatchEN>();
        event_away = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.MatchEN>();
        club_player = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PlayerEN>();
        national_player = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PlayerEN>();
        competition = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.CompetitionEN>();
}



public TeamEN(int id, string name, string country, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> event_home, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> event_away, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> club_player, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> national_player, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> competition
              )
{
        this.init (Id, name, country, event_home, event_away, club_player, national_player, competition);
}


public TeamEN(TeamEN team)
{
        this.init (Id, team.Name, team.Country, team.Event_home, team.Event_away, team.Club_player, team.National_player, team.Competition);
}

private void init (int id
                   , string name, string country, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> event_home, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> event_away, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> club_player, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> national_player, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> competition)
{
        this.Id = id;


        this.Name = name;

        this.Country = country;

        this.Event_home = event_home;

        this.Event_away = event_away;

        this.Club_player = club_player;

        this.National_player = national_player;

        this.Competition = competition;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TeamEN t = obj as TeamEN;
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
