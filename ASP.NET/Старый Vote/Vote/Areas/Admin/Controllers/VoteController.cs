using MyService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vote.Areas.Admin.Controllers
{
    public class VoteController : Controller
    {
        private IService _service = null;
        public VoteController(IService ser)
        {
            _service = ser;
        }
        // GET: Admin/Vote
        public ActionResult Index()
        {
            return View(_service.GetAllCandidates());
        }

        // GET: Admin/Vote/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Vote/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Vote/Create
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

        // GET: Admin/Vote/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Vote/Edit/5
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

        // GET: Admin/Vote/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Vote/Delete/5
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
