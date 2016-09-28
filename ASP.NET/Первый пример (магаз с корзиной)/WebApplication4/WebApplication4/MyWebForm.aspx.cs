using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class MyWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var products = GetProducts();
                products.ForEach(p =>
                    {
                        ListBoxProducts.Items.Add(p.Name);
                    });
            }

        }
        // protected void Button1_Click(object sender, EventArgs e)
        //{
        //    this.Response.Output.WriteLine("Hello!");

        //}

        protected void ButtonToBusket_Click(object sender, EventArgs e)
        {
            

        }

        protected void ButtonFromBusket_Click(object sender, EventArgs e)
        {
            

        }

        protected class Product
        {
            public string Name {get; set;}
        }

        protected List<Product> GetProducts()
        {
            var list = new List<Product>();
            list.Add(new Product() { Name="понедельник"});
            list.Add(new Product() { Name = "вторник" });
            list.Add(new Product() { Name = "среда" });
            list.Add(new Product() { Name = "четверг" });
            list.Add(new Product() { Name = "пятница" });
            list.Add(new Product() { Name = "суббота" });
            list.Add(new Product() { Name = "воскресенье" });
   
            return list;
        }
    }
}