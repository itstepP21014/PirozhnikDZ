using DataContext;
using DomainObjects;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSite.Areas.AdminArea.Controllers
{
    public class NewsController : Controller
    {
        DataService service = new DataService();

        // GET: AdminArea/News
        public ActionResult Index()
        {
            var _news = service.GetAllNews();
            return View(_news);
        }

        public ActionResult Details(int? id)
        {
            var news = service.GetNewsById(id.Value);
            return View(news);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            return View(id);
        }

        //public ActionResult Update()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Update(News _news)
        {
            service.Update(_news);
            return RedirectToAction("Details", new { id = _news.NewsID });
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(News _news)
        {
            var n = service.Create(_news.Header, _news.Body, _news.Hot, _news.Type);
            return RedirectToAction("Details", new { id = n.NewsID });
        }
    }
}