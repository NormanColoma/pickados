
using System;
// Definición clase SeasonEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class SeasonEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo initDate
 */
private Nullable<DateTime> initDate;



/**
 *	Atributo finalDate
 */
private Nullable<DateTime> finalDate;



/**
 *	Atributo competition
 */
private PickadosGenNHibernate.EN.Pickados.CompetitionEN competition;



/**
 *	Atributo round
 */
private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RoundEN> round;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual Nullable<DateTime> InitDate {
        get { return initDate; } set { initDate = value;  }
}



public virtual Nullable<DateTime> FinalDate {
        get { return finalDate; } set { finalDate = value;  }
}



public virtual PickadosGenNHibernate.EN.Pickados.CompetitionEN Competition {
        get { return competition; } set { competition = value;  }
}



public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RoundEN> Round {
        get { return round; } set { round = value;  }
}





public SeasonEN()
{
        round = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.RoundEN>();
}



public SeasonEN(int id, Nullable<DateTime> initDate, Nullable<DateTime> finalDate, PickadosGenNHibernate.EN.Pickados.CompetitionEN competition, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RoundEN> round
                )
{
        this.init (Id, initDate, finalDate, competition, round);
}


public SeasonEN(SeasonEN season)
{
        this.init (Id, season.InitDate, season.FinalDate, season.Competition, season.Round);
}

private void init (int id
                   , Nullable<DateTime> initDate, Nullable<DateTime> finalDate, PickadosGenNHibernate.EN.Pickados.CompetitionEN competition, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RoundEN> round)
{
        this.Id = id;


        this.InitDate = initDate;

        this.FinalDate = finalDate;

        this.Competition = competition;

        this.Round = round;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        SeasonEN t = obj as SeasonEN;
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
