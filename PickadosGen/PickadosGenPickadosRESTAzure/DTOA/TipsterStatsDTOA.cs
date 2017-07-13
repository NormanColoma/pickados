using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class TipsterStatsDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string alias;
public string Alias
{
        get { return alias; }
        set { alias = value; }
}

private double subscription_fee;
public double Subscription_fee
{
        get { return subscription_fee; }
        set { subscription_fee = value; }
}

private bool premium;
public bool Premium
{
        get { return premium; }
        set { premium = value; }
}

        private string sport;
        public string Sport {
            get { return sport; }
            set { sport = value; }
        }

/* Rol: TipsterStats o--> Stats */
private IList<StatsDTOA> getStatsOfTipster;
public IList<StatsDTOA> GetStatsOfTipster
{
        get { return getStatsOfTipster; }
        set { getStatsOfTipster = value; }
}
}
}
