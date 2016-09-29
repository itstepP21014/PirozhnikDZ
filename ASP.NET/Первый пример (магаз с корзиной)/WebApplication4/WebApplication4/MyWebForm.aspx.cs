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

        List<Product> collection = new List<Product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var products = GetProducts();
                products.ForEach(p => { ListBoxProducts.Items.Add(p.Name); } );
            }

        }


        protected void ButtonToBusket_Click(object sender, EventArgs e)
        {
            foreach (var i in collection)
            {
                ListBoxBusket.Items.Add(i.ToString());
                ListBoxProducts.Items.Remove(i.ToString());
            }
            collection.Clear();
        }

        protected void ButtonFromBusket_Click(object sender, EventArgs e)
        {
            foreach (var i in collection)
            {
                ListBoxProducts.Items.Add(i.ToString());
                ListBoxProducts.Items.Remove(i.ToString());
            }
            collection.Clear();
        }

        protected class Product
        {
            public string Name {get; set;}
        }

        protected List<Product> GetProducts()
        {
            var list = new List<Product>();
            list.Add(new Product() { Name="бананы"});
            list.Add(new Product() { Name = "яблоки" });
            list.Add(new Product() { Name = "груша" });
            list.Add(new Product() { Name = "капуста" });
            list.Add(new Product() { Name = "картофель" });
            list.Add(new Product() { Name = "огурцы" });
            list.Add(new Product() { Name = "помидоры" });
   
            return list;
        }

        protected void ListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            //var builder = new StringBuilder();

            foreach (ListItem i in ListBoxProducts.Items)
            {
                if (i.Selected)
                {
                    //builder.AppendLine(i.Value);
                    collection.Add(new Product() { Name = i.Value });
                }
            }
            
            //Repeater1.DataSource = collection;
            //Repeater1.DataBind();
            //this.Response.Output.WriteLine(builder.ToString());

        }

        protected void ListBoxBusket_SelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (ListItem i in ListBoxBusket.Items)
            {
                if (i.Selected)
                {
                    collection.Add(new Product() { Name = i.Value });
                }
            }
        }
    }
}