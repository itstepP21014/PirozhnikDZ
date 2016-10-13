using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class MyHandler : IHttpHandler
    {
        public void ProcessRequest(System.Web.HttpContext context)
        {
            HttpResponse response = context.Response;

            string imageName = context.Request["name"];

            string imagePath = context.Server.MapPath(string.Format("~/Images/{0}.jpg", imageName));

            response.ContentType = "image/" + Path.GetExtension(imagePath).ToLower().Substring(1);

            response.WriteFile(imagePath);
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}