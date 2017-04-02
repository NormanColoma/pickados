
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
public class StatsRESTCAD : StatsCAD
{
public StatsRESTCAD()
        : base ()
{
}

public StatsRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
