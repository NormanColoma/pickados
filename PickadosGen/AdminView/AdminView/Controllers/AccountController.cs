using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using AdminView.Models;
using Microsoft.Owin;
using PickadosGenNHibernate.CEN.Pickados;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Enumerated.Pickados;

namespace AdminView.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToRoute("Dashboard");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                AdminCEN adminCEN = new AdminCEN();
                // TODO call UsarioCEN.Login here
                try
                {
                    if (adminCEN.Login(model.UserName, model.Password))
                    {
                        var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, model.UserName),
                        },
                            DefaultAuthenticationTypes.ApplicationCookie,
                            ClaimTypes.Name, ClaimTypes.Role);

                        //Necesario crear el interfaz para poder tener acceso a la operación SignIn
                        IOwinContext owinContext = HttpContext.GetOwinContext();
                        IAuthenticationManager authenticationManager = owinContext.Authentication;
                        authenticationManager.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = model.RememberMe
                        }, identity);
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nombre de usuario o contraseña no válidos.");
                    }
                }catch(Exception ex)
                {
                    ModelState.AddModelError("", "Se produjo un error al iniciar sesión.");
                    return View(model);
                }
               
            }

            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(model);
            
        }
        //
        // POST: /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        #region Aplicaciones auxiliares
        // Se usa para la protección XSRF al agregar inicios de sesión externos
        public const string XsrfKey = "XsrfId";

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}