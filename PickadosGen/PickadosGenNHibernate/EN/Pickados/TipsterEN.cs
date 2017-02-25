
using System;
// Definición clase TipsterEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class TipsterEN                                                                      : PickadosGenNHibernate.EN.Pickados.UsuarioEN


{
/**
 *	Atributo monthlyStats
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> monthlyStats;



/**
 *	Atributo post
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post;



/**
 *	Atributo follow_to
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> follow_to;



/**
 *	Atributo followed_by
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> followed_by;



/**
 *	Atributo premium
 */
private bool premium;



/**
 *	Atributo subscription_fee
 */
private double subscription_fee;






public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> MonthlyStats {
        get { return monthlyStats; } set { monthlyStats = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> Post {
        get { return post; } set { post = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> Follow_to {
        get { return follow_to; } set { follow_to = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> Followed_by {
        get { return followed_by; } set { followed_by = value;  }
}



public virtual bool Premium {
        get { return premium; } set { premium = value;  }
}



public virtual double Subscription_fee {
        get { return subscription_fee; } set { subscription_fee = value;  }
}





public TipsterEN() : base ()
{
        monthlyStats = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.StatsEN>();
        post = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PostEN>();
        follow_to = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
        followed_by = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
}



public TipsterEN(int id, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> monthlyStats, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> follow_to, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> followed_by, bool premium, double subscription_fee
                 , string alias, string email, String password, Nullable<DateTime> created_at, Nullable<DateTime> updated_at
                 )
{
        this.init (Id, monthlyStats, post, follow_to, followed_by, premium, subscription_fee, alias, email, password, created_at, updated_at);
}


public TipsterEN(TipsterEN tipster)
{
        this.init (Id, tipster.MonthlyStats, tipster.Post, tipster.Follow_to, tipster.Followed_by, tipster.Premium, tipster.Subscription_fee, tipster.Alias, tipster.Email, tipster.Password, tipster.Created_at, tipster.Updated_at);
}

private void init (int id
                   , System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> monthlyStats, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> follow_to, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> followed_by, bool premium, double subscription_fee, string alias, string email, String password, Nullable<DateTime> created_at, Nullable<DateTime> updated_at)
{
        this.Id = id;


        this.MonthlyStats = monthlyStats;

        this.Post = post;

        this.Follow_to = follow_to;

        this.Followed_by = followed_by;

        this.Premium = premium;

        this.Subscription_fee = subscription_fee;

        this.Alias = alias;

        this.Email = email;

        this.Password = password;

        this.Created_at = created_at;

        this.Updated_at = updated_at;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        TipsterEN t = obj as TipsterEN;
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
