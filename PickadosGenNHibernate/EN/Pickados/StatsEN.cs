
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
 *	Atributo initialDate
 */
private Nullable<DateTime> initialDate;



/**
 *	Atributo tipster
 */
private PickadosGenNHibernate.EN.Pickados.TipsterEN tipster;


/**
 *	Atributo totalStaked
 */
private double totalStaked;



/**
 *	Atributo oddAccumulator
 */
private double oddAccumulator;




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



public virtual Nullable<DateTime> InitialDate {
        get { return initialDate; } set { initialDate = value;  }
}



public virtual PickadosGenNHibernate.EN.Pickados.TipsterEN Tipster {
        get { return tipster; } set { tipster = value;  }
}

        public virtual double TotalStaked
        {
            get { return totalStaked; }
            set { totalStaked = value; }
        }



        public virtual double OddAccumulator
        {
            get { return oddAccumulator; }
            set { oddAccumulator = value; }
        }



        public StatsEN()
{
            benefit = 0;
            stakeAverage = 0;
            yield = 0;
            oddAverage = 0;
            totalPicks = 0;
            InitialDate = DateTime.Now;
            totalStaked = 0;
            oddAccumulator = 0;
}



public StatsEN(int id, double benefit, double stakeAverage, float yield, double oddAverage, int totalPicks, Nullable<DateTime> initialDate, PickadosGenNHibernate.EN.Pickados.TipsterEN tipster, double totalStaked, double oddAccumulator
               )
{
        this.init (Id, benefit, stakeAverage, yield, oddAverage, totalPicks, initialDate, tipster, totalStaked, oddAccumulator);
}


public StatsEN(StatsEN stats)
{
        this.init (Id, stats.Benefit, stats.StakeAverage, stats.Yield, stats.OddAverage, stats.TotalPicks, stats.InitialDate, stats.Tipster, stats.TotalStaked, stats.OddAccumulator);
}

private void init (int id
                   , double benefit, double stakeAverage, float yield, double oddAverage, int totalPicks, Nullable<DateTime> initialDate, PickadosGenNHibernate.EN.Pickados.TipsterEN tipster, double totalStaked, double oddAccumulator)
{
        this.Id = id;


        this.Benefit = benefit;

        this.StakeAverage = stakeAverage;

        this.Yield = yield;

        this.OddAverage = oddAverage;

        this.TotalPicks = totalPicks;

        this.InitialDate = initialDate;

        this.Tipster = tipster;

        this.OddAccumulator = oddAccumulator;

        this.TotalStaked = TotalStaked;
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
