
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Tipster_login) ENABLED START*/
//  references to other libraries
using System.Security.Cryptography;
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class TipsterCEN
{
public PickadosGenNHibernate.EN.Pickados.TipsterEN Login (string user, string pass)
{
            /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Tipster_login) ENABLED START*/

            // Write here your custom code...
            UsuarioCEN userCEN = new UsuarioCEN();
            TipsterEN userFound = (TipsterEN)userCEN.Login(user, pass);

            return userFound;

            //throw new NotImplementedException ("Method Login() not yet implemented.");

            /*PROTECTED REGION END*/
        }
}
}
