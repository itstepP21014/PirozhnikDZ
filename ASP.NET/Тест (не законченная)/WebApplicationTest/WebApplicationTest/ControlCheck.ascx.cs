using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTest
{
    public partial class ControlCheck : System.Web.UI.UserControl
    {
        public object DataSource
        {
            get
            {
                return DataSource;
            }
            set
            {
                DataSource = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var coll = DataSource as Question;
            foreach (var i in coll.AnswersCollection)
                CheckBoxList1.Items.Add(i.AnswerText);
        }
    }
}