using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class MyWebForm : System.Web.UI.Page
    {

        DataService service = new DataService(new FakeRepository());
        List<DataObject> collection = new List<DataObject>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                collection = service.GetAll();
                collection.ForEach(p => { ListBoxProducts.Items.Add(p.Name); });
            }

        }

        protected void ButtonToBusket_Click(object sender, EventArgs e)
        {
            var lstStr = new List<string>();
            
            foreach (var i in ListBoxProducts.GetSelectedIndices())
            {
                var str = ListBoxProducts.Items[i].Value;
                lstStr.Add(str);
                ListBoxBusket.Items.Add(str);                
            }
            foreach (var i in lstStr)
            { 
                ListBoxProducts.Items.Remove(i); 
            }
        }

        protected void ButtonFromBusket_Click(object sender, EventArgs e)
        {
            var lstStr = new List<string>();

            foreach (var i in ListBoxBusket.GetSelectedIndices())
            {
                var str = ListBoxBusket.Items[i].Value;
                lstStr.Add(str);
                ListBoxProducts.Items.Add(str);
            }
            foreach (var i in lstStr)
            {
                ListBoxBusket.Items.Remove(i);
            }
        }
    }
}