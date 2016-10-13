using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Collection
    {
        public List<Product> Coll { get; set; }

        public Collection()
        {
            Coll = new List<Product> {
                new Product {Name = "apple", Description = "red apple"},
                new Product {Name = "pineapple", Description = "yellow pineapple"},
                new Product {Name = "cucumber", Description = "green cucumber"}
            };
        }

        public void AddToColl(Product prod)
        {
            Coll.Add(new Product { Name = prod.Name, Description = prod.Description});
        }
    }
}