
using System;
// Definición clase ScorerEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class ScorerEN                                                                       : PickadosGenNHibernate.EN.Pickados.PickEN


{
/**
 *	Atributo scorer_name
 */
private string scorer_name;



/**
 *	Atributo player
 */
private PickadosGenNHibernate.EN.Pickados.PlayerEN player;






public virtual string Scorer_name {
        get { return scorer_name; } set { scorer_name = value;  }
}



public virtual PickadosGenNHibernate.EN.Pickados.PlayerEN Player {
        get { return player; } set { player = value;  }
}





public ScorerEN() : base ()
{
}



public ScorerEN(int id, string scorer_name, PickadosGenNHibernate.EN.Pickados.PlayerEN player
                , double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel
                )
{
        this.init (Id, scorer_name, player, odd, description, pickResult, bookie, post, event_rel);
}


public ScorerEN(ScorerEN scorer)
{
        this.init (Id, scorer.Scorer_name, scorer.Player, scorer.Odd, scorer.Description, scorer.PickResult, scorer.Bookie, scorer.Post, scorer.Event_rel);
}

private void init (int id
                   , string scorer_name, PickadosGenNHibernate.EN.Pickados.PlayerEN player, double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel)
{
        this.Id = id;


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
        ScorerEN t = obj as ScorerEN;
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
