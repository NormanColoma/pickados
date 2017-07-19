using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class TipsterDTOA
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

private string email;
public string Email
{
        get { return email; }
        set { email = value; }
}

private Nullable<DateTime> created_at;
public Nullable<DateTime> Created_at
{
        get { return created_at; }
        set { created_at = value; }
}

private bool premium;
public bool Premium
{
        get { return premium; }
        set { premium = value; }
}

private double subscription_fee;
public double Subscription_fee
{
        get { return subscription_fee; }
        set { subscription_fee = value; }
}

private string nif;
public string Nif
{
        get { return nif; }
        set { nif = value; }
}

private string sport;
public string Sport
{
    get { return sport; }
    set { sport = value; }
}
    }
}
