
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





public TipsterEN() : base ()
{
        monthlyStats = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.StatsEN>();
        post = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PostEN>();
        follow_to = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
        followed_by = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.TipsterEN>();
}



public TipsterEN(int id, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> monthlyStats, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> follow_to, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> followed_by
                 , TimeSpan createdAt, TimeSpan modifiedAt, string alias, string email, String password
                 )
{
        this.init (Id, monthlyStats, post, follow_to, followed_by, createdAt, modifiedAt, alias, email, password);
}


public TipsterEN(TipsterEN tipster)
{
        this.init (Id, tipster.MonthlyStats, tipster.Post, tipster.Follow_to, tipster.Followed_by, tipster.CreatedAt, tipster.ModifiedAt, tipster.Alias, tipster.Email, tipster.Password);
}

private void init (int id
                   , System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.StatsEN> monthlyStats, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> follow_to, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> followed_by, TimeSpan createdAt, TimeSpan modifiedAt, string alias, string email, String password)
{
        this.Id = id;


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
