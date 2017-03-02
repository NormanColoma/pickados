using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class PostDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private double stake;
public double Stake
{
        get { return stake; }
        set { stake = value; }
}

private string description;
public string Description
{
        get { return description; }
        set { description = value; }
}

private double totalOdd;
public double TotalOdd
{
        get { return totalOdd; }
        set { totalOdd = value; }
}
}
}
