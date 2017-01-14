

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;

using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;


namespace PickadosGenNHibernate.CEN.Pickados
{
/*
 *      Definition of the class TimecastCEN
 *
 */
public partial class TimecastCEN
{
private ITimecastCAD _ITimecastCAD;

public TimecastCEN()
{
        this._ITimecastCAD = new TimecastCAD ();
}

public TimecastCEN(ITimecastCAD _ITimecastCAD)
{
        this._ITimecastCAD = _ITimecastCAD;
}

public ITimecastCAD get_ITimecastCAD ()
{
        return this._ITimecastCAD;
}
}
}
