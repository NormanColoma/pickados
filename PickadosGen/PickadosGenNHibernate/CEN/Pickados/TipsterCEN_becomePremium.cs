
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Tipster_becomePremium) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class TipsterCEN
{
public void BecomePremium (int p_oid, double fee)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Tipster_becomePremium) ENABLED START*/

        // Write here your custom code...

        TipsterEN cambio = GetTipsterById (p_oid);

        ModifyTipster (p_oid, cambio.Alias, cambio.Email, cambio.Password, cambio.Created_at, cambio.Updated_at, cambio.Nif, true, fee);

        /*PROTECTED REGION END*/
}
}
}
