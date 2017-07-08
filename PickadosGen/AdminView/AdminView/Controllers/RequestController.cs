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
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            RequestCEN requestCEN = new RequestCEN();
            List<RequestEN> list = requestCEN.GetByState(RequestStateEnum.Open).ToList();
            List<RequestEN> list2 = requestCEN.GetByState(RequestStateEnum.inReview).ToList();
            list.AddRange(list2);
            list.OrderBy(r => r.Date);
            return View(list);
        }

        public ActionResult Finalizadas()
        {
            RequestCEN requestCEN = new RequestCEN();
            List<RequestEN> list = requestCEN.GetByState(RequestStateEnum.Accepted).ToList();
            List<RequestEN> list2 = requestCEN.GetByState(RequestStateEnum.Denied).ToList();
            list.AddRange(list2);
            list.OrderBy(r => r.Date);
            return View(list);
        }

        public ActionResult AddComment(int id, string content)
        {
            try
            {
                // TODO: Add delete logic here
                RequestCEN requests = new RequestCEN();
                RequestEN request = requests.GetById(id);
                requests.Modify(id, request.Type, request.Reason, RequestStateEnum.Denied, DateTime.Now, "", new DateTime());
                ViewBag.typeContent = content;
                return PartialView("AddComment", request);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult AddingComments(string content, int id, FormCollection collection)
        {
            RequestCEN requests = new RequestCEN();
            RequestEN request = requests.GetById(id);
            string comment = collection["AdminComment"].ToString();
            if (content.Equals("Aceptar"))
            {
                requests.Modify(id, request.Type, request.Reason, RequestStateEnum.Accepted, request.Date, comment, DateTime.Now);
            } else if(content.Equals("Denegar"))
            {
                requests.Modify(id, request.Type, request.Reason, RequestStateEnum.Denied, request.Date, comment, DateTime.Now);
            } else
            {
                requests.Modify(id, request.Type, request.Reason, RequestStateEnum.inReview, request.Date, comment, DateTime.Now);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public JsonResult CountRequests(string prefix)
        {
            RequestCEN requestCEN = new RequestCEN();
            List<RequestEN> list = requestCEN.GetByState(RequestStateEnum.Open).ToList();
            List<RequestEN> list2 = requestCEN.GetByState(RequestStateEnum.inReview).ToList();
            list.AddRange(list2);
            return Json(list.Count);
        }
    }
}
