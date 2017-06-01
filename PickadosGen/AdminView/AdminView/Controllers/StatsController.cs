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

        public ActionResult _Stat(string alias)
        {
            StatsCEN statsCEN = new StatsCEN();
            IList<StatsEN> statsEN = statsCEN.GetStatsByTipster(alias);

            return View();
        }
    }
}