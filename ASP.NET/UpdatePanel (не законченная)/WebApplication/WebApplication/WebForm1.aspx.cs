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
        Collection data = new Collection();

        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshRepeater();
        }

        protected void ButtonOk_Click(object sender, EventArgs e)
        {
            if (TextBoxDescription.Text != null && TextBoxName.Text != null)
            {
                data.AddToColl(new Product { Name = TextBoxName.Text, Description = TextBoxDescription.Text });
                RefreshRepeater();
                ClearAllBoxes();
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearAllBoxes();
        }






        public void RefreshRepeater()
        {
            Repeater1.DataSource = data.Coll;
            Repeater1.DataBind();
        }

        public void ClearAllBoxes()
        {
            TextBoxDescription.Text = null;
            TextBoxName.Text = null;
        }
    }
}