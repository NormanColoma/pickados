﻿using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CP.Pickados;
using System.Collections.Generic;
using System.Web.Mvc;
using AdminView.Assemblers;
using AdminView.Models;
using System;

namespace AdminView.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ListaTipstersFree(int page)
        {
            int first = page*15;
            int size = 15;

            TipsterCP tipsterCP = new TipsterCP();
            IList<TipsterEN> tipsters = tipsterCP.GetTipstersFree(first, size);

            if (tipsters.Count < 0)
                return new EmptyResult();

            return PartialView("_index/_ListaTipstersFree", UserAssembler.ConverterUserENtoModel(new List<UsuarioEN> (tipsters)));
        }

        public ActionResult _ListaTipstersPremium(int page)
        {
            int first = page * 15;
            int size = first + 15;

            TipsterCP tipsterCP = new TipsterCP();
            IList<TipsterEN> tipsters = tipsterCP.GetTipstersPremium(first, size);

            if (tipsters.Count < 0)
                return new EmptyResult();

            return PartialView("_index/_ListaTipstersPremium", UserAssembler.ConverterUserENtoModel(new List<UsuarioEN>(tipsters)));
        }

        public ActionResult _ListaAdmins(int page)
        {
            int first = page * 15;
            int size = first + 15;

            AdminCEN adminCEN = new AdminCEN();
            IList<AdminEN> admins = adminCEN.GetAllAdmins(first, size);

            if (admins.Count < 0)
                return new EmptyResult();

            return PartialView("_index/_ListaAdmins", UserAssembler.ConverterUserENtoModel(new List<UsuarioEN>(admins)));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            UsuarioEN usuarioEN = usuarioCEN.GetUserById(id);

            return View("Edit", UserAssembler.ConverterUserENtoModel(usuarioEN));
        }

        [HttpPost]
        public ActionResult Edit(UserModel user)
        {
            try
            {
                if(user.Admin == true)
                {
                    AdminCEN adminCEN = new AdminCEN();
                    adminCEN.ModifyAdmin(user.Id, user.Alias, user.Email, user.Password, user.Created_at, DateTime.Now, user.Nif, true);
                }
                else
                {
                    TipsterCEN tipsterCEN = new TipsterCEN();
                    if (user.Tipsterp == true)
                        tipsterCEN.ModifyTipsterByAdmin(user.Id, user.Alias, user.Email, DateTime.Now, user.Nif, true, user.Subscription_fee, user.Locked);
                    else
                        tipsterCEN.ModifyTipsterByAdmin(user.Id, user.Alias, user.Email, DateTime.Now, user.Nif, false, 0, user.Locked);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            usuarioCEN.DeleteUser(id);

            return RedirectToAction("Index");
        }
        
    }
}