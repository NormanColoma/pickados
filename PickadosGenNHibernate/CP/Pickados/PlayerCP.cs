
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using PickadosGenNHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CEN.Pickados;


namespace PickadosGenNHibernate.CP.Pickados
{
public partial class PlayerCP : BasicCP
{
public PlayerCP() : base ()
{
}

public PlayerCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
