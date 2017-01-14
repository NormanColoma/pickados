
using System;
// Definición clase CorrectScoreEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class CorrectScoreEN                                                                 : PickadosGenNHibernate.EN.Pickados.PickEN


{
/**
 *	Atributo homeScore
 */
private int homeScore;



/**
 *	Atributo awayScore
 */
private int awayScore;






public virtual int HomeScore {
        get { return homeScore; } set { homeScore = value;  }
}



public virtual int AwayScore {
        get { return awayScore; } set { awayScore = value;  }
}





public CorrectScoreEN() : base ()
{
}



public CorrectScoreEN(int id, int homeScore, int awayScore
                      , double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel
                      )
{
        this.init (Id, homeScore, awayScore, odd, description, pickResult, bookie, post, event_rel);
}


public CorrectScoreEN(CorrectScoreEN correctScore)
{
        this.init (Id, correctScore.HomeScore, correctScore.AwayScore, correctScore.Odd, correctScore.Description, correctScore.PickResult, correctScore.Bookie, correctScore.Post, correctScore.Event_rel);
}

private void init (int id
                   , int homeScore, int awayScore, double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel)
{
        this.Id = id;


        this.HomeScore = homeScore;

        this.AwayScore = awayScore;

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
        CorrectScoreEN t = obj as CorrectScoreEN;
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
