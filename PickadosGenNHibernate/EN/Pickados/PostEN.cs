
using System;
// Definición clase PostEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class PostEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo created_at
 */
private TimeSpan created_at;



/**
 *	Atributo modified_at
 */
private TimeSpan modified_at;



/**
 *	Atributo stake
 */
private double stake;



/**
 *	Atributo description
 */
private string description;



/**
 *	Atributo private_
 */
private bool private_;



/**
 *	Atributo pick
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick;



/**
 *	Atributo tipster
 */
private PickadosGenNHibernate.EN.Pickados.TipsterEN tipster;



/**
 *	Atributo totalOdd
 */
private double totalOdd;



/**
 *	Atributo postResult
 */
private PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum postResult;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual TimeSpan Created_at {
        get { return created_at; } set { created_at = value;  }
}



public virtual TimeSpan Modified_at {
        get { return modified_at; } set { modified_at = value;  }
}



public virtual double Stake {
        get { return stake; } set { stake = value;  }
}



public virtual string Description {
        get { return description; } set { description = value;  }
}



public virtual bool Private_ {
        get { return private_; } set { private_ = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> Pick {
        get { return pick; } set { pick = value;  }
}



public virtual PickadosGenNHibernate.EN.Pickados.TipsterEN Tipster {
        get { return tipster; } set { tipster = value;  }
}



public virtual double TotalOdd {
        get { return totalOdd; } set { totalOdd = value;  }
}



public virtual PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum PostResult {
        get { return postResult; } set { postResult = value;  }
}





public PostEN()
{
        pick = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
}



public PostEN(int id, TimeSpan created_at, TimeSpan modified_at, double stake, string description, bool private_, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick, PickadosGenNHibernate.EN.Pickados.TipsterEN tipster, double totalOdd, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum postResult
              )
{
        this.init (Id, created_at, modified_at, stake, description, private_, pick, tipster, totalOdd, postResult);
}


public PostEN(PostEN post)
{
        this.init (Id, post.Created_at, post.Modified_at, post.Stake, post.Description, post.Private_, post.Pick, post.Tipster, post.TotalOdd, post.PostResult);
}

private void init (int id
                   , TimeSpan created_at, TimeSpan modified_at, double stake, string description, bool private_, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick, PickadosGenNHibernate.EN.Pickados.TipsterEN tipster, double totalOdd, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum postResult)
{
        this.Id = id;


        this.Created_at = created_at;

        this.Modified_at = modified_at;

        this.Stake = stake;

        this.Description = description;

        this.Private_ = private_;

        this.Pick = pick;

        this.Tipster = tipster;

        this.TotalOdd = totalOdd;

        this.PostResult = postResult;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PostEN t = obj as PostEN;
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
