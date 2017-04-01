using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace PickadosGenPickadosRESTAzure.DTOA
{
public class RequestDTOA
{
private PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum type;
public PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum Type
{
        get { return type; }
        set { type = value; }
}

private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}

private string reason;
public string Reason
{
        get { return reason; }
        set { reason = value; }
}

private PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum state;
public PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum State
{
        get { return state; }
        set { state = value; }
}

private Nullable<DateTime> date;
public Nullable<DateTime> Date
{
        get { return date; }
        set { date = value; }
}
}
}
