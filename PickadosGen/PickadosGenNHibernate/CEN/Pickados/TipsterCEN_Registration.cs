
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Tipster_registration) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class TipsterCEN
{
public int Registration (string alias, string nif, string email, string pass)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Tipster_registration) ENABLED START*/

        // Write here your custom code...

        TipsterCEN nuevo = new TipsterCEN ();
        TipsterEN nifExists = nuevo.FindByNIF (nif);
        TipsterEN aliasExists = nuevo.FindByUser (alias);
        TipsterEN emailExists = nuevo.FindByMail (email);

        if (nifExists == null || aliasExists == null || emailExists == null) {
                int registered = nuevo.NewTipster (alias, email, pass, DateTime.Today, DateTime.Today, nif, false, 0);
                return registered;
        }

        return -1;

        //throw new NotImplementedException ("Method Registration() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
