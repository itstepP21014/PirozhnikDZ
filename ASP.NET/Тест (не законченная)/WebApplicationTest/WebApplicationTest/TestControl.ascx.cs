using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTest
{
    public partial class TestControl : System.Web.UI.UserControl
    {
        Test test = new Test();
        int numberOfQuestion = 0;

        public object DataSource
        {
            get
            {
                return test.QuestionCollection[numberOfQuestion];
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
                RadioButtonList1.Items.Add(i.AnswerText);
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            numberOfQuestion++;
            DataSource = test.QuestionCollection[numberOfQuestion];     
            
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}