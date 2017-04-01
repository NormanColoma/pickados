
using System;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using System.Collections.Generic;

using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CEN.Pickados;

namespace PickadosGenPickadosRESTAzure.CAD
{
public class Event_RESTCAD : Event_CAD
{
public Event_RESTCAD()
        : base ()
{
}

public Event_RESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
