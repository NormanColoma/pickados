using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CP.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            int size = first+15;

            TipsterCP tipsterCP = new TipsterCP();
            IList<TipsterEN> tipsters = tipsterCP.GetTipstersFree(first, size);

            if (tipsters.Count < 0)
                return new EmptyResult();

            return PartialView("_ListaTipstersFree", tipsters);
        }

        public ActionResult _ListaTipstersPremium(int page)
        {
            int first = page * 15;
            int size = first + 15;

            TipsterCP tipsterCP = new TipsterCP();
            IList<TipsterEN> tipsters = tipsterCP.GetTipstersPremium(first, size);

            if (tipsters.Count < 0)
                return new EmptyResult();

            return PartialView("_ListaTipstersPremium", tipsters);
        }

        public ActionResult _ListaAdmins(int page)
        {
            int first = page * 15;
            int size = first + 15;

            AdminCEN adminCEN = new AdminCEN();
            IList<AdminEN> admins = adminCEN.GetAllAdmins(first, size);

            if (admins.Count < 0)
                return new EmptyResult();

            return PartialView("_ListaAdmins", admins);
        }
    }
}