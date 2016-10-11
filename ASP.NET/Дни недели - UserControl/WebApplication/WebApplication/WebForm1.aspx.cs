using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DaysOfWeek data = new DaysOfWeek();
        protected void Page_Load(object sender, EventArgs e)
        {
            control1.DataSource = data.GetWeeksDaysNames();
            control1.DataBind();
        }
  
    }
}