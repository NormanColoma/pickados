using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToRoute("Login");
            }
            return RedirectToAction("Post", "Stats");
            //return View();
        }

        public ActionResult idioma(string lang, string returnUrl)
        {
            Session["Cultura"] = new System.Globalization.CultureInfo(lang);
            return RedirectToRoute("Login");
        }
    }
}