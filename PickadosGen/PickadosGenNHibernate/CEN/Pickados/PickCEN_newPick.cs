
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Pick_newPick) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class PickCEN
{
public int NewPick (double p_odd, string p_description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_pickResult, string p_bookie, int p_event_rel)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Pick_newPick_customized) START*/

        PickEN pickEN = null;

        int oid;

        //Initialized PickEN
        pickEN = new PickEN ();
        pickEN.Odd = p_odd;

        pickEN.Description = p_description;

        pickEN.PickResult = p_pickResult;

        pickEN.Bookie = p_bookie;


        if (p_event_rel != -1) {
                pickEN.Event_rel = new PickadosGenNHibernate.EN.Pickados.Event_EN ();
                pickEN.Event_rel.Id = p_event_rel;
        }

        //Call to PickCAD

        oid = _IPickCAD.NewPick (pickEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
