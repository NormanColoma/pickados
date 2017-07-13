
using System;
// Definición clase StatsEN
namespace PickadosGenNHibernate.EN.Pickados
{
public partial class StatsEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo benefit
 */
private double benefit;



/**
 *	Atributo stakeAverage
 */
private double stakeAverage;



/**
 *	Atributo yield
 */
private float yield;



/**
 *	Atributo oddAverage
 */
private double oddAverage;



/**
 *	Atributo totalPicks
 */
private int totalPicks;



/**
 *	Atributo date
 */
private Nullable<DateTime> date;



/**
 *	Atributo tipster
 */
private PickadosGenNHibernate.EN.Pickados.TipsterEN tipster;



/**
 *	Atributo oddAccumulator
 */
private double oddAccumulator;



/**
 *	Atributo totalStaked
 */
private double totalStaked;



/**
 *	Atributo wins
 */
private int wins;



/**
 *	Atributo voids
 */
private int voids;



/**
 *	Atributo lost
 */
private int lost;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Benefit {
        get { return benefit; } set { benefit = value;  }
}



public virtual double StakeAverage {
        get { return stakeAverage; } set { stakeAverage = value;  }
}



public virtual float Yield {
        get { return yield; } set { yield = value;  }
}



public virtual double OddAverage {
        get { return oddAverage; } set { oddAverage = value;  }
}



public virtual int TotalPicks {
        get { return totalPicks; } set { totalPicks = value;  }
}



public virtual Nullable<DateTime> Date {
        get { return date; } set { date = value;  }
}



public virtual PickadosGenNHibernate.EN.Pickados.TipsterEN Tipster {
        get { return tipster; } set { tipster = value;  }
}



public virtual double OddAccumulator {
        get { return oddAccumulator; } set { oddAccumulator = value;  }
}



public virtual double TotalStaked {
        get { return totalStaked; } set { totalStaked = value;  }
}



public virtual int Wins {
        get { return wins; } set { wins = value;  }
}



public virtual int Voids {
        get { return voids; } set { voids = value;  }
}



public virtual int Lost {
        get { return lost; } set { lost = value;  }
}





public StatsEN()
{
}



public StatsEN(int id, double benefit, double stakeAverage, float yield, double oddAverage, int totalPicks, Nullable<DateTime> date, PickadosGenNHibernate.EN.Pickados.TipsterEN tipster, double oddAccumulator, double totalStaked, int wins, int voids, int lost
               )
{
        this.init (Id, benefit, stakeAverage, yield, oddAverage, totalPicks, date, tipster, oddAccumulator, totalStaked, wins, voids, lost);
}


public StatsEN(StatsEN stats)
{
        this.init (Id, stats.Benefit, stats.StakeAverage, stats.Yield, stats.OddAverage, stats.TotalPicks, stats.Date, stats.Tipster, stats.OddAccumulator, stats.TotalStaked, stats.Wins, stats.Voids, stats.Lost);
}

private void init (int id
                   , double benefit, double stakeAverage, float yield, double oddAverage, int totalPicks, Nullable<DateTime> date, PickadosGenNHibernate.EN.Pickados.TipsterEN tipster, double oddAccumulator, double totalStaked, int wins, int voids, int lost)
{
        this.Id = id;


        this.Benefit = benefit;

        this.StakeAverage = stakeAverage;

        this.Yield = yield;

        this.OddAverage = oddAverage;

        this.TotalPicks = totalPicks;

        this.Date = date;

        this.Tipster = tipster;

        this.OddAccumulator = oddAccumulator;

        this.TotalStaked = totalStaked;

        this.Wins = wins;

        this.Voids = voids;

        this.Lost = lost;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        StatsEN t = obj as StatsEN;
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
