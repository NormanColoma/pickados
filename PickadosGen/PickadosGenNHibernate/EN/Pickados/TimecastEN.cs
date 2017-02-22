
using System;
// Definición clase TimecastEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class TimecastEN                                                                     : PickadosGenNHibernate.EN.Pickados.ScorerEN


{
/**
 *	Atributo score_time
 */
private string score_time;






public virtual string Score_time {
        get { return score_time; } set { score_time = value;  }
}





public TimecastEN() : base ()
{
}



public TimecastEN(int id, string score_time
                  , string scorer_name, PickadosGenNHibernate.EN.Pickados.PlayerEN player
                  , double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel
                  )
{
        this.init (Id, score_time, scorer_name, player, odd, description, pickResult, bookie, post, event_rel);
}


public TimecastEN(TimecastEN timecast)
{
        this.init (Id, timecast.Score_time, timecast.Scorer_name, timecast.Player, timecast.Odd, timecast.Description, timecast.PickResult, timecast.Bookie, timecast.Post, timecast.Event_rel);
}

private void init (int id
                   , string score_time, string scorer_name, PickadosGenNHibernate.EN.Pickados.PlayerEN player, double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel)
{
        this.Id = id;


        this.Score_time = score_time;

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
        TimecastEN t = obj as TimecastEN;
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
