using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            DateTime init = DateTime.Now.AddMonths(-12);
            DateTime fin = DateTime.Now;
            
            string initialDate = init.Month + "/" + init.Year;
            string finalDate = fin.Month + "/" + fin.Year;

            return _Login(initialDate, finalDate);
        }

        public ActionResult _Login(string initialDate, string finalDate)
        {
            string[] iDate = initialDate.Split('/');
            string[] fDate = finalDate.Split('/');

            DateTime init = new DateTime(Int32.Parse(iDate[1]), Int32.Parse(iDate[0]), 01);
            DateTime fin = new DateTime(Int32.Parse(fDate[1]), Int32.Parse(fDate[0]), 01);

            LoginCEN loginCEN = new LoginCEN();
            List<LoginEN> logins = loginCEN.GetLoginBetweenMonths(init, fin).ToList();

            return View();
        }
    }
}