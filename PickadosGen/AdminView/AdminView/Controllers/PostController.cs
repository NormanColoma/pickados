using PickadosGenNHibernate.CEN.Pickados;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Enumerated.Pickados;
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
            ViewBag.PostID = post;
            return View(postTotal);
        }

        [HttpPost]
        public ActionResult EditPick(int idPost, int id, FormCollection collection)
        {

            //int post = idPost;
            PickCEN picks = new PickCEN();
            PickEN pick = picks.GetPickById(id);
            pick.Odd = Convert.ToDouble(collection["Odd"].ToString());
            pick.Description = collection["Description"].ToString();
            PickResultEnum result = (PickResultEnum)Enum.Parse(typeof(PickResultEnum), collection["PickResult"].ToString());
            pick.Bookie = collection["Bookie"].ToString();


            picks.ModifyPick(id, pick.Odd, pick.Description, result, pick.Bookie);
            return RedirectToAction("PostDetails", "Post", new { post = idPost });
        }

        [HttpPost]
        public ActionResult editPost(int id, FormCollection collection)
        {
            PostCEN posts = new PostCEN();
            PostEN post = posts.GetPostById(id);
            post.Description = collection["Description"].ToString();
            post.Stake = Convert.ToDouble(collection["Stake"].ToString());
            PickResultEnum result  = (PickResultEnum)Enum.Parse(typeof(PickResultEnum), collection["PostResult"].ToString());
            post.Report = Convert.ToInt32(collection["Report"].ToString());
            posts.ModifyPost(id, post.Created_at, post.Modified_at, post.Stake, post.Description, post.Private_, post.TotalOdd, result, post.Likeit, post.Report);

            return RedirectToAction("PostDetails", "Post", new { post = id });
        }
    }
}