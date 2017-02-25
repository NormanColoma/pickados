
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
using System.Security.Cryptography;


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Usuario_Login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class UsuarioCEN
{
public PickadosGenNHibernate.EN.Pickados.UsuarioEN Login (string user, string pass)
{
            /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Usuario_Login) ENABLED START*/

            // Write here your custom code...
            string codedPass;
                UsuarioCEN usuario = new UsuarioCEN();
                UsuarioEN us = usuario.FindByUser(user);

                if (us != null)
                {
                    StringBuilder hash = new StringBuilder();
                    MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                    byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(pass));

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        hash.Append(bytes[i].ToString("x2"));
                    }
                    codedPass = hash.ToString();
                    if (us.Password == codedPass)
                    {
                        return us;
                    }
                }
            return null;
        }

        //throw new NotImplementedException ("Method Login() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
