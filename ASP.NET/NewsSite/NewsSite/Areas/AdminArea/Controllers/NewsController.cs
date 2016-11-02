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

        public ActionResult Details(int _id)
        {
            return Details(_id);
        }

        [HttpPost]
        public ActionResult Delete(int _id)
        {
            return Delete(_id);
        }

        [HttpPost]
        public ActionResult Update(News _news)
        {
            return Update(_news);
        }

        public ActionResult Create()
        {
            return Create();
        }

        [HttpPost]
        public ActionResult Create(News _news)
        {
            return Create(_news);
        }
    }
}