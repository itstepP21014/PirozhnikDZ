using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataObject data = new DataObject();
        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater1.DataSource = data.GetCollection();
            Repeater1.DataBind();
        }
    }
}