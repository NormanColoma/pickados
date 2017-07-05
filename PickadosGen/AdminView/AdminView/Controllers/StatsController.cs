using AdminView.Assemblers;
using AdminView.Models;
using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.CP.Pickados;
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
        /* --- Stats by login --- */
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
                return RedirectToAction("login", "account");
        }

        [HttpGet]
        public ActionResult _LoginStat()
        {
            DateTime fin = DateTime.Today;
            DateTime init = DateTime.Today.AddMonths(-11);

            string initialDate = init.Month + "/" + init.Year;
            string finalDate = fin.Month + "/" + fin.Year;

            return PartialView("_logins/_loginstat", _Login(initialDate, finalDate));
        }

        [HttpPost]
        [ActionName("_LoginStat")]
        public ActionResult _LoginStatPost(string iDate, string fDate)
        {
            if (User.Identity.IsAuthenticated)
            {
                string[] iDateData = iDate.Split('-');
                string[] fDateData = fDate.Split('-');

                string initialDate = iDateData[1] + "/" + iDateData[0];
                string finalDate = fDateData[1] + "/" + fDateData[0];

                return PartialView("_logins/_loginstat", _Login(initialDate, finalDate));
            }
            else
                return RedirectToAction("login", "account");
        }

        private StatModel _Login(string initialDate, string finalDate)
        {
            string[] iDate = initialDate.Split('/');
            string[] fDate = finalDate.Split('/');

            DateTime init = new DateTime(Int32.Parse(iDate[1]), Int32.Parse(iDate[0]), 01);
            DateTime fin = new DateTime(Int32.Parse(fDate[1]), Int32.Parse(fDate[0]), DateTime.DaysInMonth(Int32.Parse(fDate[1]), Int32.Parse(fDate[0])));

            if (fin > DateTime.Now)
                fin = new DateTime(Int32.Parse(fDate[1]), Int32.Parse(fDate[0]), DateTime.Today.Day);

            LoginCEN loginCEN = new LoginCEN();
            List<LoginEN> logins = loginCEN.GetLoginBetweenDate(init, fin).ToList();

            var loginsGroupby = logins.GroupBy(x => new { Month = x.Date.Value.Month, Year = x.Date.Value.Year }).ToList();

            Dictionary<string, double> loginsDict = new Dictionary<string, double>();
            for (DateTime date = init; date <= fin; date = date.AddMonths(1))
            {
                loginsDict.Add(date.Month + "/" + date.Year, 0);
            }

            StatModel sm = new StatModel();

            for (int i = 0; i < loginsGroupby.Count; i++)
                loginsDict[loginsGroupby[i].Key.Month + "/" + loginsGroupby[i].Key.Year] = loginsGroupby[i].Count();

            sm.completeInfoStat(loginsDict);

            return sm;
        }

        /* --- Stats by posts --- */
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

                return PartialView("_posts/_poststat", _Post(initialDate, finalDate));
            }
            else
                return RedirectToAction("login", "account");
        }

        [HttpPost]
        [ActionName("_PostStat")]
        public ActionResult _PostStatPost(string iDate, string fDate)
        {
            if (User.Identity.IsAuthenticated)
            {
                string[] iDateData = iDate.Split('-');
                string[] fDateData = fDate.Split('-');

                string initialDate = iDateData[1] + "/" + iDateData[0];
                string finalDate = fDateData[1] + "/" + fDateData[0];

                return PartialView("_posts/_poststat", _Post(initialDate, finalDate));
            }
            else
                return RedirectToAction("login", "account");
        }

        private StatModel _Post(string initialDate, string finalDate)
        {
            string[] iDate = initialDate.Split('/');
            string[] fDate = finalDate.Split('/');

            DateTime init = new DateTime(Int32.Parse(iDate[1]), Int32.Parse(iDate[0]), 01);
            DateTime fin = new DateTime(Int32.Parse(fDate[1]), Int32.Parse(fDate[0]), DateTime.DaysInMonth(Int32.Parse(fDate[1]), Int32.Parse(fDate[0])));

            if (fin > DateTime.Now)
                fin = new DateTime(Int32.Parse(fDate[1]), Int32.Parse(fDate[0]), DateTime.Today.Day);

            PostCEN postCEN = new PostCEN();
            List<PostEN> posts = postCEN.GetPostsBetweenDate(init, fin).ToList();

            var postsGroupby = posts.GroupBy(x => new { Month = x.Created_at.Value.Month, Year = x.Created_at.Value.Year }).ToList();

            Dictionary<string, double> postsDict = new Dictionary<string, double>();
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
                DateTime fin = DateTime.Today;
                DateTime init = DateTime.Today.AddMonths(-11);

                PostCEN postCEN = new PostCEN();
                IList<PostEN> posts = postCEN.GetMoreVoted(init, fin);

                List<PostModel> postsmodel = PostAssembler.ConvertPostENtoModel(posts);

                return PartialView("_posts/_postlist", postsmodel);
            }
            else
                return RedirectToAction("login", "account");
        }

        [HttpPost]
        [ActionName("_PostList")]
        public ActionResult _PostListPost(string iDate, string fDate)
        {
            if (User.Identity.IsAuthenticated)
            {
                string[] iDateData = iDate.Split('-');
                string[] fDateData = fDate.Split('-');

                DateTime init = new DateTime(Int32.Parse(iDateData[0]), Int32.Parse(iDateData[1]), 01);
                DateTime fin = new DateTime(Int32.Parse(fDateData[0]), Int32.Parse(fDateData[1]), 01);

                PostCEN postCEN = new PostCEN();
                IEnumerable<PostEN> posts = postCEN.GetMoreVoted(init, fin);

                return PartialView("_posts/_postlist", posts);
            }
            else
                return RedirectToAction("login", "account");
        }

        /*--- Stats by bet tipster --- */
        public ActionResult Users()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
                return RedirectToAction("login", "account");
        }

        public ActionResult _UsersBetsList()
        {
            PostCEN postCEN = new PostCEN();
            TipsterCEN tipsterCEN = new TipsterCEN();

            /* --- Get posts --- */
            List<IGrouping<int, PostEN>> postsGroup = postCEN.GetAllPosts(0, int.MaxValue).GroupBy(p => p.Tipster.Id).ToList();

            StatModel sm = new StatModel();
            sm.ListInfo = new Dictionary<string, double>();

            for (int i = 0; i < postsGroup.Count(); i++)
            {
                TipsterEN tipsterEN = tipsterCEN.GetTipsterById(postsGroup[i].Key);
                sm.ListInfo.Add(tipsterEN.Alias, postsGroup[i].Count());
            }

            sm.ListInfo = sm.ListInfo.OrderByDescending(s => s.Value).Take(10).ToDictionary(k => k.Key, v => v.Value);
            sm.completeInfoStat(sm.ListInfo);

            return PartialView("_usersbets/_usersbetslist", sm);
        }

        public ActionResult _UsersStakeList()
        {
            PostCEN postCEN = new PostCEN();
            TipsterCEN tipsterCEN = new TipsterCEN();

            /* --- Get posts --- */
            List<IGrouping<int, PostEN>> postsGroup = postCEN.GetAllPosts(0, int.MaxValue).GroupBy(p => p.Tipster.Id).ToList();

            StatModel sm = new StatModel();
            sm.ListInfo = new Dictionary<string, double>();

            foreach (var group in postsGroup)
            {
                double value = 0;
                TipsterEN tipsterEN = tipsterCEN.GetTipsterById(group.Key);
                
                foreach (var item in group)
                    value += item.Stake;

                sm.ListInfo.Add(tipsterEN.Alias, value);
            }

            sm.ListInfo = sm.ListInfo.OrderByDescending(s => s.Value).Take(10).ToDictionary(k => k.Key, v => v.Value);
            sm.completeInfoStat(sm.ListInfo);

            return PartialView("_usersbets/_usersstakelist", sm);
        }

        public ActionResult _UsersYieldList()
        {
            /* --- Get posts --- */
            StatsCEN statsCEN = new StatsCEN();
            List<IGrouping<string, StatsEN>> statsGroup = statsCEN.GetAllStats(0, int.MaxValue).GroupBy(s => s.Tipster.Alias).ToList();

            StatModel sm = new StatModel();
            sm.ListInfo = new Dictionary<string, double>();

            foreach (var group in statsGroup)
            {
                int cont = 0;
                float yield = 0;

                foreach (var stat in group)
                {
                    cont++;
                    yield += stat.Yield;
                }

                sm.ListInfo.Add(group.Key, yield/cont);
            }

            sm.ListInfo = sm.ListInfo.OrderByDescending(s => s.Value).Take(10).ToDictionary(k => k.Key, v => v.Value);
            sm.completeInfoStat(sm.ListInfo);

            return PartialView("_usersbets/_usersyieldlist", sm);
        }
    }
}