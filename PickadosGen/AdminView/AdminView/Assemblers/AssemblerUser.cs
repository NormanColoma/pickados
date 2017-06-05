using AdminView.Models;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminView.Assemblers
{
    public static class AssemblerUser
    {
        public static UserViewModels ConverterUserENtoModel(UsuarioEN usuario)
        {
            UserViewModels user = new UserViewModels();

            user.Id = usuario.Id;
            user.Alias = usuario.Alias;
            user.Email = usuario.Email;
            user.Created_at = usuario.Created_at;
            user.Updated_at = usuario.Updated_at;
            user.Nif = usuario.Nif;
            user.Password = usuario.Password;

            string UserType = usuario.GetType().Name;
            if (UserType.Equals("AdminEN"))
               ConverterAdminENtoModel((AdminEN) usuario, user);
            else
                ConverterTipsterENtoModel((TipsterEN) usuario, user);

            return user;
        }

        public static void ConverterAdminENtoModel(AdminEN usuario, UserViewModels user)
        {
            user.Admin = true;
        }

        public static void ConverterTipsterENtoModel(TipsterEN usuario, UserViewModels user)
        {
            user.Tipsterp = usuario.Premium;
            if(user.Tipsterp != false)
                user.Subscription_fee = usuario.Subscription_fee;

            user.Locked = usuario.Locked;
        }
    }
}