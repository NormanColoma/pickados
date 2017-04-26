﻿using PickadosGenNHibernate.CEN.Pickados;
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
            IList<RequestEN> list = requestCEN.GetByState(RequestStateEnum.Open);
            return View(list);
        }

        // GET: Request/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Request/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Request/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Accept(int id, FormCollection collection)
        {
            try
            {
                RequestCEN requestCEN = new RequestCEN();
                RequestEN requestEN = requestCEN.GetById(id);
                PostCEN postCEN = new PostCEN();

                if (requestEN != null) {
                    RequestTypeEnum requestType = requestEN.Type;

                    if (requestType.Equals(RequestTypeEnum.modify)){
                        //TODO Update post 
                    }
                    else {
                        //TODO this better as transaction
                        postCEN.DeletePost(requestEN.Post.Id);
                        requestCEN.Modify(id, requestEN.Type, requestEN.Reason, RequestStateEnum.Accepted, requestEN.Date);
                    }
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Review(int id, FormCollection collection)
        {
            try
            {
                // TODO: Send email notification and set inReview(4) state.

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Request/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Request/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Request/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
