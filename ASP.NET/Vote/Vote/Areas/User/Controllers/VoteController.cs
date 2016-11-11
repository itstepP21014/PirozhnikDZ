using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vote.Areas.User.Controllers
{
    public class VoteController : Controller
    {
        // GET: User/Vote
        public ActionResult Index()
        {
            if (HttpContext.Request.Browser == )
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        // GET: User/Vote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Vote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Vote/Create
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

        // GET: User/Vote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Vote/Edit/5
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

        // GET: User/Vote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Vote/Delete/5
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
