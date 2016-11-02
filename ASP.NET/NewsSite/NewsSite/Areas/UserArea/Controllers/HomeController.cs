using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsSite.Areas.NewsArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: NewsArea/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}