using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class StatsDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private double benefit;
public double Benefit
{
        get { return benefit; }
        set { benefit = value; }
}

private double stakeAverage;
public double StakeAverage
{
        get { return stakeAverage; }
        set { stakeAverage = value; }
}

private float yield;
public float Yield
{
        get { return yield; }
        set { yield = value; }
}

private double oddAverage;
public double OddAverage
{
        get { return oddAverage; }
        set { oddAverage = value; }
}

private int totalPicks;
public int TotalPicks
{
        get { return totalPicks; }
        set { totalPicks = value; }
}

private double oddAccumulator;
public double OddAccumulator
{
        get { return oddAccumulator; }
        set { oddAccumulator = value; }
}

private double totalStaked;
public double TotalStaked
{
        get { return totalStaked; }
        set { totalStaked = value; }
}
}
}
