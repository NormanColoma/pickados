
using System;
// Definición clase HandicapEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class HandicapEN                                                                     : PickadosGenNHibernate.EN.Pickados.GoalEN


{
/**
 *	Atributo result
 */
private PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result;






public virtual PickadosGenNHibernate.Enumerated.Pickados.ResultEnum Result {
        get { return result; } set { result = value;  }
}





public HandicapEN() : base ()
{
}



public HandicapEN(int id, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result
                  , PickadosGenNHibernate.Enumerated.Pickados.LineEnum line, double quantity, bool asian
                  , double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel
                  )
{
        this.init (Id, result, line, quantity, asian, odd, description, pickResult, bookie, post, event_rel);
}


public HandicapEN(HandicapEN handicap)
{
        this.init (Id, handicap.Result, handicap.Line, handicap.Quantity, handicap.Asian, handicap.Odd, handicap.Description, handicap.PickResult, handicap.Bookie, handicap.Post, handicap.Event_rel);
}

private void init (int id
                   , PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result, PickadosGenNHibernate.Enumerated.Pickados.LineEnum line, double quantity, bool asian, double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel)
{
        this.Id = id;


        this.Result = result;

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
        HandicapEN t = obj as HandicapEN;
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
