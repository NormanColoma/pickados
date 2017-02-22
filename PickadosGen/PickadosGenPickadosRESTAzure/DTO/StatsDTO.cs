using System;
using System.Runtime.Serialization;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenPickadosRESTAzure.DTO
{
public partial class StatsDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private double benefit;
public double Benefit {
        get { return benefit; } set { benefit = value;  }
}
private double stakeAverage;
public double StakeAverage {
        get { return stakeAverage; } set { stakeAverage = value;  }
}
private float yield;
public float Yield {
        get { return yield; } set { yield = value;  }
}
private double oddAverage;
public double OddAverage {
        get { return oddAverage; } set { oddAverage = value;  }
}
private int totalPicks;
public int TotalPicks {
        get { return totalPicks; } set { totalPicks = value;  }
}
private Nullable<DateTime> initialDate;
public Nullable<DateTime> InitialDate {
        get { return initialDate; } set { initialDate = value;  }
}


private int tipster_oid;
public int Tipster_oid {
        get { return tipster_oid; } set { tipster_oid = value;  }
}

private double oddAccumulator;
public double OddAccumulator {
        get { return oddAccumulator; } set { oddAccumulator = value;  }
}
private double totalStaked;
public double TotalStaked {
        get { return totalStaked; } set { totalStaked = value;  }
}
}
}
