
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
public class CompetitionRESTCAD : CompetitionCAD
{
public CompetitionRESTCAD()
        : base ()
{
}

public CompetitionRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
