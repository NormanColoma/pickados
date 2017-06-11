

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
 *      Definition of the class PickCEN
 *
 */
public partial class PickCEN
{
private IPickCAD _IPickCAD;

public PickCEN()
{
        this._IPickCAD = new PickCAD ();
}

public PickCEN(IPickCAD _IPickCAD)
{
        this._IPickCAD = _IPickCAD;
}

public IPickCAD get_IPickCAD ()
{
        return this._IPickCAD;
}

public int NewPick (double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel)
{
        PickEN pickEN = null;
        int oid;

        //Initialized PickEN
        pickEN = new PickEN ();
        pickEN.Odd = p_odd;

        pickEN.Description = p_description;

        pickEN.PickResult = p_pickResult;

        pickEN.Bookie = p_bookie;


        if (p_event_rel != -1) {
                // El argumento p_event_rel -> Property event_rel es oid = false
                // Lista de oids id
                pickEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN ();
                pickEN.Event_rel.Id = p_event_rel;
        }

        //Call to PickCAD

        oid = _IPickCAD.NewPick (pickEN);
        return oid;
}

public void ModifyPick (int p_Pick_OID, double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie)
{
        PickEN pickEN = null;

        //Initialized PickEN
        pickEN = new PickEN ();
        pickEN.Id = p_Pick_OID;
        pickEN.Odd = p_odd;
        pickEN.Description = p_description;
        pickEN.PickResult = p_pickResult;
        pickEN.Bookie = p_bookie;
        //Call to PickCAD

        _IPickCAD.ModifyPick (pickEN);
}

public void DeletePick (int id
                        )
{
        _IPickCAD.DeletePick (id);
}

public PickEN GetPickById (int id
                           )
{
        PickEN pickEN = null;

        pickEN = _IPickCAD.GetPickById (id);
        return pickEN;
}

public System.Collections.Generic.IList<PickEN> GetAllPicks (int first, int size)
{
        System.Collections.Generic.IList<PickEN> list = null;

        list = _IPickCAD.GetAllPicks (first, size);
        return list;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> GetPicksByResult (PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum ? p_pickResult)
{
        return _IPickCAD.GetPicksByResult (p_pickResult);
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> GetPicksByPost (int ? post_id)
{
        return _IPickCAD.GetPicksByPost (post_id);
}
}
}
