using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminView.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostDetails(int post=0)
        {
            PostCEN posts = new PostCEN();
            PickCEN picks = new PickCEN();
            PostEN postTotal = posts.GetPostById(post);
            ViewBag.picks = picks.GetPicksByPost(post);
            return View(postTotal);
        }
    }
}