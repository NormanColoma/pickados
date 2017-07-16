using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class PickDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private double odd;
public double Odd
{
        get { return odd; }
        set { odd = value; }
}

private string description;
public string Description
{
        get { return description; }
        set { description = value; }
}

private string bookie;
public string Bookie
{
        get { return bookie; }
        set { bookie = value; }
}

private PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult;
public PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum PickResult
{
        get { return pickResult; }
        set { pickResult = value; }
}

        private IList<MatchDTOA> getAllMatchOfPick;
        public IList<MatchDTOA> GetAllMatchOfPick
        {
            get { return getAllMatchOfPick; }
            set { getAllMatchOfPick = value; }
        }
    }
}
