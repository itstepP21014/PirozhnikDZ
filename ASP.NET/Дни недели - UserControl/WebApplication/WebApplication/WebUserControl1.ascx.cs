using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        public object DataSource
        {
            get
            {
                return this.Repeater1.DataSource;
            }
            set
            {
                this.Repeater1.DataSource = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}