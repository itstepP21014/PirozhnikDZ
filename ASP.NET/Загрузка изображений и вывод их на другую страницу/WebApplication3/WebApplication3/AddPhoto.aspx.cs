using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            // загружаем файлы в папку Images
            var ralativePath = Path.Combine("Images", this.FileUpload1.FileName);
            var path = Server.MapPath(ralativePath);
            File.WriteAllBytes(path, this.FileUpload1.FileBytes);
        }

        protected void ButtonSeeResult_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewPhotos.aspx");
        }
    }
}