using AdminView.Assemblers;
using AdminView.Models;
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
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                DateTime fin = DateTime.Today;
                DateTime init = DateTime.Today.AddMonths(-11);

                string initialDate = init.Month + "/" + init.Year;
                string finalDate = fin.Month + "/" + fin.Year;

                return _Login(initialDate, finalDate);
            }
            else
                return RedirectToAction("login", "account");
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginPost(LoginModel stat)
        {
            if (User.Identity.IsAuthenticated)
            {
                string initialDate = stat.InitialDate.Month + "/" + stat.InitialDate.Year;
                string finalDate = stat.FinalDate.Month + "/" + stat.FinalDate.Year;

                return _Login(initialDate, finalDate);
            }
            else
                return RedirectToAction("login", "account");
        }

        private ActionResult _Login(string initialDate, string finalDate)
        {
            string[] iDate = initialDate.Split('/');
            string[] fDate = finalDate.Split('/');

            DateTime init = new DateTime(Int32.Parse(iDate[1]), Int32.Parse(iDate[0]), 01);
            DateTime fin = new DateTime(Int32.Parse(fDate[1]), Int32.Parse(fDate[0]), 01);

            LoginCEN loginCEN = new LoginCEN();
            List<LoginEN> logins = loginCEN.GetLoginBetweenMonths(init, fin).ToList();

            var loginsGroupby = logins.GroupBy(x => new { Month = x.Date.Value.Month, Year = x.Date.Value.Year }).ToList();

            Dictionary<string, int> logs = new Dictionary<string, int>();
            for (DateTime date = init; date <= fin; date = date.AddMonths(1))
            {
                logs.Add(date.Month + "/" + date.Year, 0);
            }

            LoginModel lm = new LoginModel();

            for (int i = 0; i < loginsGroupby.Count; i++)
                logs[loginsGroupby[i].Key.Month + "/" + loginsGroupby[i].Key.Year] = loginsGroupby[i].Count();

            lm.completeInfoStat(logs);

            return View(lm);
        }
    }
}