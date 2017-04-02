
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Admin_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class AdminCEN
{
public bool Login (string name, string password)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Admin_login) ENABLED START*/

        // Write here your custom code...
        UsuarioCEN userCEN = new UsuarioCEN ();
        UsuarioEN userFound = userCEN.Login (name, password);

        if (userFound.Admin && userFound != null) {
                return true;
        }
        return false;
        /*PROTECTED REGION END*/
}
}
}
