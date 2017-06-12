
using System;
// Definición clase SportEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class SportEN
{
/**
 *	Atributo competition
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> competition;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo name
 */
private string name;



/**
 *	Atributo player
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> player;



/**
 *	Atributo image
 */
private string image;






public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> Competition {
        get { return competition; } set { competition = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual string Name {
        get { return name; } set { name = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> Player {
        get { return player; } set { player = value;  }
}



public virtual string Image {
        get { return image; } set { image = value;  }
}





public SportEN()
{
        competition = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.CompetitionEN>();
        player = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PlayerEN>();
}



public SportEN(int id, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> competition, string name, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> player, string image
               )
{
        this.init (Id, competition, name, player, image);
}


public SportEN(SportEN sport)
{
        this.init (Id, sport.Competition, sport.Name, sport.Player, sport.Image);
}

private void init (int id
                   , System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> competition, string name, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PlayerEN> player, string image)
{
        this.Id = id;


        this.Competition = competition;

        this.Name = name;

        this.Player = player;

        this.Image = image;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SportEN t = obj as SportEN;
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
