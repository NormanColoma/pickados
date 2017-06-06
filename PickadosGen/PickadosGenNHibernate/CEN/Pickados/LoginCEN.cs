

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
 *      Definition of the class LoginCEN
 *
 */
public partial class LoginCEN
{
private ILoginCAD _ILoginCAD;

public LoginCEN()
{
        this._ILoginCAD = new LoginCAD ();
}

public LoginCEN(ILoginCAD _ILoginCAD)
{
        this._ILoginCAD = _ILoginCAD;
}

public ILoginCAD get_ILoginCAD ()
{
        return this._ILoginCAD;
}

public int NewLogin (string p_alias, Nullable<DateTime> p_date)
{
        LoginEN loginEN = null;
        int oid;

        //Initialized LoginEN
        loginEN = new LoginEN ();
        loginEN.Alias = p_alias;

        loginEN.Date = p_date;

        //Call to LoginCAD

        oid = _ILoginCAD.NewLogin (loginEN);
        return oid;
}

public System.Collections.Generic.IList<LoginEN> GetAllLogins (int first, int size)
{
        System.Collections.Generic.IList<LoginEN> list = null;

        list = _ILoginCAD.GetAllLogins (first, size);
        return list;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.LoginEN> GetLoginBetweenMonths (Nullable<DateTime> initialDate, Nullable<DateTime> finalDate)
{
        return _ILoginCAD.GetLoginBetweenMonths (initialDate, finalDate);
}
}
}
