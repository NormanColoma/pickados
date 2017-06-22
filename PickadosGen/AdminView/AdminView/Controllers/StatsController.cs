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
        public ActionResult LoginPost(StatModel stat)
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
            List<LoginEN> logins = loginCEN.GetLoginBetweenDate(init, fin).ToList();

            var loginsGroupby = logins.GroupBy(x => new { Month = x.Date.Value.Month, Year = x.Date.Value.Year }).ToList();

            Dictionary<string, int> loginsDict = new Dictionary<string, int>();
            for (DateTime date = init; date <= fin; date = date.AddMonths(1))
            {
                loginsDict.Add(date.Month + "/" + date.Year, 0);
            }

            StatModel sm = new StatModel();

            for (int i = 0; i < loginsGroupby.Count; i++)
                loginsDict[loginsGroupby[i].Key.Month + "/" + loginsGroupby[i].Key.Year] = loginsGroupby[i].Count();

            sm.completeInfoStat(loginsDict);

            return View(sm);
        }

        public ActionResult Post()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _PostStat()
        {
            if (User.Identity.IsAuthenticated)
            {
                DateTime fin = DateTime.Today;
                DateTime init = DateTime.Today.AddMonths(-11);

                string initialDate = init.Month + "/" + init.Year;
                string finalDate = fin.Month + "/" + fin.Year;

                return PartialView("_posts/_PostStat", _Post(initialDate, finalDate));
            }
            else
                return RedirectToAction("login", "account");
        }

        private StatModel _Post(string initialDate, string finalDate)
        {
            string[] iDate = initialDate.Split('/');
            string[] fDate = finalDate.Split('/');

            DateTime init = new DateTime(Int32.Parse(iDate[1]), Int32.Parse(iDate[0]), 01);
            DateTime fin = new DateTime(Int32.Parse(fDate[1]), Int32.Parse(fDate[0]), 01);

            PostCEN postCEN = new PostCEN();
            List<PostEN> posts = postCEN.GetPostsBetweenDate(init, fin).ToList();

            var postsGroupby = posts.GroupBy(x => new { Month = x.Created_at.Value.Month, Year = x.Created_at.Value.Year }).ToList();

            Dictionary<string, int> postsDict = new Dictionary<string, int>();
            for (DateTime date = init; date <= fin; date = date.AddMonths(1))
            {
                postsDict.Add(date.Month + "/" + date.Year, 0);
            }

            StatModel sm = new StatModel();

            for (int i = 0; i < postsGroupby.Count; i++)
                postsDict[postsGroupby[i].Key.Month + "/" + postsGroupby[i].Key.Year] = postsGroupby[i].Count();

            sm.completeInfoStat(postsDict);

            return sm;
        }

        [HttpGet]
        public ActionResult _PostList()
        {
            if (User.Identity.IsAuthenticated)
            {
                PostCEN postCEN = new PostCEN();
                IEnumerable<PostEN> posts = postCEN.GetMoreVoted();

                return PartialView("_posts/_PostList", posts);
            }
            else
                return RedirectToAction("login", "account");
        }
    }
}