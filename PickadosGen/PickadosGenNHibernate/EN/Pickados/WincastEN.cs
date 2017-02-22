
using System;
// Definición clase WincastEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class WincastEN                                                                      : PickadosGenNHibernate.EN.Pickados.ScorerEN


{
/**
 *	Atributo team_name
 */
private string team_name;






public virtual string Team_name {
        get { return team_name; } set { team_name = value;  }
}





public WincastEN() : base ()
{
}



public WincastEN(int id, string team_name
                 , string scorer_name, PickadosGenNHibernate.EN.Pickados.PlayerEN player
                 , double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel
                 )
{
        this.init (Id, team_name, scorer_name, player, odd, description, pickResult, bookie, post, event_rel);
}


public WincastEN(WincastEN wincast)
{
        this.init (Id, wincast.Team_name, wincast.Scorer_name, wincast.Player, wincast.Odd, wincast.Description, wincast.PickResult, wincast.Bookie, wincast.Post, wincast.Event_rel);
}

private void init (int id
                   , string team_name, string scorer_name, PickadosGenNHibernate.EN.Pickados.PlayerEN player, double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel)
{
        this.Id = id;


        this.Team_name = team_name;

        this.Scorer_name = scorer_name;

        this.Player = player;

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
        WincastEN t = obj as WincastEN;
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
