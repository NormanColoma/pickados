
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
public class PickRESTCAD : PickCAD
{
public PickRESTCAD()
        : base ()
{
}

public PickRESTCAD(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
