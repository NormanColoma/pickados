using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class PickController : Controller
    {
        // GET: Pick
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailsPick(int idPick)
        {
            PickCEN picks = new PickCEN();
            PickEN pick = picks.GetPickById(idPick);
            return PartialView("DetailsPick", pick);
        }
    }
}