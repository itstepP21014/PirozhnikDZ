using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Message message = null)
        {
            string str1 = string.Empty;
            string str2 = string.Empty;

            if (message.Text != null)
            {
                str2  = message.Text;
            }
            else
            {
                str1 = "bla";
            }

            return View(new Message { Text = str1, Text2 = str2 });
        }



    }
}
