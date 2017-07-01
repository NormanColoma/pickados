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

            Dictionary<string, double> loginsDict = new Dictionary<string, double>();
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

                return PartialView("_posts/_PostStat", _Post(initialDate, finalDate));
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
                IEnumerable<PostEN> posts = postCEN.GetMoreVoted(init, fin);

                return PartialView("_posts/_PostList", posts);
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

                return PartialView("_posts/_PostList", posts);
            }
            else
                return RedirectToAction("login", "account");
        }

        /*--- Stats by bet tipster --- */
        public ActionResult UsersBets()
        {
            return View();
        }

        public ActionResult _UsersBetsList()
        {
            /* --- Dates --- */
            DateTime fin = DateTime.Today;
            DateTime init = DateTime.Today.AddMonths(-11);

            PostCEN postCEN = new PostCEN();
            TipsterCEN tipsterCEN = new TipsterCEN();

            /* --- Get posts --- */
            List<IGrouping<int, PostEN>> postsGroup = postCEN.GetPostsBetweenDate(init, fin).GroupBy(p => p.Tipster.Id).ToList();

            StatModel sm = new StatModel();
            sm.ListInfo = new Dictionary<string, double>();

            foreach (var group in postsGroup)
            {
                TipsterEN tipsterEN = tipsterCEN.GetTipsterById(group.Key);
                sm.ListInfo.Add(tipsterEN.Alias, group.Count());
            }

            sm.completeInfoStat(sm.ListInfo);

            return PartialView("_usersbets/_UsersBetsList", sm);
        }

        [HttpPost]
        [ActionName("_UsersBetsList")]
        public ActionResult _UsersBetsListPost(StatModel stat)
        {

            string initialDate = stat.InitialDate.Month + "/" + stat.InitialDate.Year;
            string finalDate = stat.FinalDate.Month + "/" + stat.FinalDate.Year;

            string[] iDate = initialDate.Split('/');
            string[] fDate = finalDate.Split('/');

            DateTime init = new DateTime(Int32.Parse(iDate[1]), Int32.Parse(iDate[0]), 01);
            DateTime fin = new DateTime(Int32.Parse(fDate[1]), Int32.Parse(fDate[0]), 01);

            PostCEN postCEN = new PostCEN();
            TipsterCEN tipsterCEN = new TipsterCEN();

            /* --- Get posts --- */
            List<IGrouping<int, PostEN>> postsGroup = postCEN.GetPostsBetweenDate(init, fin).GroupBy(p => p.Tipster.Id).ToList();

            Dictionary<string, double> usersBetDict = new Dictionary<string, double>();
            for (int i = 0; i < postsGroup.Count(); i++)
            {
                TipsterEN tipsterEN = tipsterCEN.GetTipsterById(postsGroup[i].Key);
                usersBetDict.Add(tipsterEN.Alias, postsGroup[i].Count());
            }

            StatModel sm = new StatModel();
            sm.completeInfoStat(usersBetDict);

            return PartialView("_usersbets/_UsersBetsList", sm);
        }

        public ActionResult _UsersStakeList()
        {
            /* --- Dates --- */
            DateTime fin = DateTime.Today;
            DateTime init = DateTime.Today.AddMonths(-11);

            PostCEN postCEN = new PostCEN();
            TipsterCEN tipsterCEN = new TipsterCEN();

            /* --- Get posts --- */
            List<IGrouping<int, PostEN>> postsGroup = postCEN.GetPostsBetweenDate(init, fin).GroupBy(p => p.Tipster.Id).ToList();

            StatModel sm = new StatModel();
            sm.ListInfo = new Dictionary<string, double>();

            foreach (var group in postsGroup)
            {
                double value = 0;
                TipsterEN tipsterEN = tipsterCEN.GetTipsterById(group.Key);
                
                foreach (var item in group)
                {
                    value += item.Stake;
                }

                sm.ListInfo.Add(tipsterEN.Alias, value);
            }

            sm.completeInfoStat(sm.ListInfo);

            return PartialView("_usersbets/_UsersStakeList", sm);
        }
    }
}