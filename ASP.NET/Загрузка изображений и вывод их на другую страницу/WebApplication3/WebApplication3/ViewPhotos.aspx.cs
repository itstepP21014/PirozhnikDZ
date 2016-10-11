using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
    public partial class ViewPhotos : System.Web.UI.Page
    {
        List<MyImage> imgColl = new List<MyImage>();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPictures();
        }

        public void LoadPictures()
        {
            // достаем файлы из папки Images
            foreach (var item in Directory.GetFiles(Server.MapPath("/Images")))
            {
                if (System.IO.File.Exists(item))
                    imgColl.Add(new MyImage { Url = "/Images/" + Path.GetFileName(item).ToString()});
            }

            Repeater1.DataSource = imgColl;
            Repeater1.DataBind();
        }
    }
}