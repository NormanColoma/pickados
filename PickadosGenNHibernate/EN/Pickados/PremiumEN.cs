
using System;
// Definición clase PremiumEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class PremiumEN                                                                      : PickadosGenNHibernate.EN.Pickados.TipsterEN


{
/**
 *	Atributo subscription_fee
 */
private float subscription_fee;






public virtual float Subscription_fee {
        get { return subscription_fee; } set { subscription_fee = value;  }
}





public PremiumEN() : base ()
{
}



public PremiumEN(int id, float subscription_fee
                 , System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> monthlyStats, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> follow_to, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> followed_by
                 , TimeSpan createdAt, TimeSpan modifiedAt, string alias, string email, String password
                 )
{
        this.init (Id, subscription_fee, monthlyStats, post, follow_to, followed_by, createdAt, modifiedAt, alias, email, password);
}


public PremiumEN(PremiumEN premium)
{
        this.init (Id, premium.Subscription_fee, premium.MonthlyStats, premium.Post, premium.Follow_to, premium.Followed_by, premium.CreatedAt, premium.ModifiedAt, premium.Alias, premium.Email, premium.Password);
}

private void init (int id
                   , float subscription_fee, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> monthlyStats, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> follow_to, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> followed_by, TimeSpan createdAt, TimeSpan modifiedAt, string alias, string email, String password)
{
        this.Id = id;


        this.Subscription_fee = subscription_fee;

        this.MonthlyStats = monthlyStats;

        this.Post = post;

        this.Follow_to = follow_to;

        this.Followed_by = followed_by;

        this.CreatedAt = createdAt;

        this.ModifiedAt = modifiedAt;

        this.Alias = alias;

        this.Email = email;

        this.Password = password;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PremiumEN t = obj as PremiumEN;
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
