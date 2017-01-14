

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
 *      Definition of the class SportCEN
 *
 */
public partial class SportCEN
{
private ISportCAD _ISportCAD;

public SportCEN()
{
        this._ISportCAD = new SportCAD ();
}

public SportCEN(ISportCAD _ISportCAD)
{
        this._ISportCAD = _ISportCAD;
}

public ISportCAD get_ISportCAD ()
{
        return this._ISportCAD;
}

public int New_ (string p_name)
{
        SportEN sportEN = null;
        int oid;

        //Initialized SportEN
        sportEN = new SportEN ();
        sportEN.Name = p_name;

        //Call to SportCAD

        oid = _ISportCAD.New_ (sportEN);
        return oid;
}

public void Modify (int p_Sport_OID, string p_name)
{
        SportEN sportEN = null;

        //Initialized SportEN
        sportEN = new SportEN ();
        sportEN.Id = p_Sport_OID;
        sportEN.Name = p_name;
        //Call to SportCAD

        _ISportCAD.Modify (sportEN);
}

public void Destroy (int id
                     )
{
        _ISportCAD.Destroy (id);
}
}
}
