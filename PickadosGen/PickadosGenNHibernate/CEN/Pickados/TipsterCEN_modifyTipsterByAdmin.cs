
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Tipster_modifyTipsterByAdmin) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class TipsterCEN
{
public void ModifyTipsterByAdmin (int p_Tipster_OID, string p_alias, string p_email, Nullable<DateTime> p_updated_at, string p_nif, bool p_premium, double p_subscription_fee, bool p_locked)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Tipster_modifyTipsterByAdmin_customized) START*/

        TipsterEN tipsterEN = null;

        //Initialized TipsterEN
        tipsterEN = new TipsterEN ();
        tipsterEN.Id = p_Tipster_OID;
        tipsterEN.Alias = p_alias;
        tipsterEN.Email = p_email;
        tipsterEN.Updated_at = p_updated_at;
        tipsterEN.Nif = p_nif;
        tipsterEN.Premium = p_premium;
        tipsterEN.Subscription_fee = p_subscription_fee;
        tipsterEN.Locked = p_locked;
        //Call to TipsterCAD

        _ITipsterCAD.ModifyTipsterByAdmin (tipsterEN);

        /*PROTECTED REGION END*/
}
}
}
