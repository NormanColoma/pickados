using AdminView.Models;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminView.Assemblers
{
    public static class UserAssembler
    {
        public static UserModel ConverterUserENtoModel(UsuarioEN userEN)
        {
            UserModel user = new UserModel();

            user.Id = userEN.Id;
            user.Alias = userEN.Alias;
            user.Email = userEN.Email;
            user.Created_at = userEN.Created_at;
            user.Updated_at = userEN.Updated_at;
            user.Nif = userEN.Nif;
            user.Password = userEN.Password;

            string UserType = userEN.GetType().Name;
            if (UserType.Equals("AdminEN"))
               ConverterAdminENtoModel((AdminEN) userEN, user);
            else
                ConverterTipsterENtoModel((TipsterEN) userEN, user);

            return user;
        }

        public static void ConverterAdminENtoModel(AdminEN usuario, UserModel user)
        {
            user.Admin = true;
        }

        public static void ConverterTipsterENtoModel(TipsterEN usuario, UserModel user)
        {
            user.Tipsterp = usuario.Premium;
            if(user.Tipsterp != false)
                user.Subscription_fee = usuario.Subscription_fee;

            user.Locked = usuario.Locked;
        }
    }
}