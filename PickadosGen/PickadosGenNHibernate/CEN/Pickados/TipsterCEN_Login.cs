
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
        string codedPass;
        TipsterCEN usuario = new TipsterCEN ();
        TipsterEN us = usuario.FindByUser (user);

        if (us != null) {
                StringBuilder hash = new StringBuilder ();
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider ();
                byte[] bytes = md5provider.ComputeHash (new UTF8Encoding ().GetBytes (pass));

                for (int i = 0; i < bytes.Length; i++) {
                        hash.Append (bytes [i].ToString ("x2"));
                }
                codedPass = hash.ToString ();
                if (us.Password == codedPass) {
                        return us;
                }
        }
        return null;

        //throw new NotImplementedException ("Method Login() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
