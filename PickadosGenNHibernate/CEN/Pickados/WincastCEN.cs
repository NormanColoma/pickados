

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
 *      Definition of the class WincastCEN
 *
 */
public partial class WincastCEN
{
private IWincastCAD _IWincastCAD;

public WincastCEN()
{
        this._IWincastCAD = new WincastCAD ();
}

public WincastCEN(IWincastCAD _IWincastCAD)
{
        this._IWincastCAD = _IWincastCAD;
}

public IWincastCAD get_IWincastCAD ()
{
        return this._IWincastCAD;
}
}
}
