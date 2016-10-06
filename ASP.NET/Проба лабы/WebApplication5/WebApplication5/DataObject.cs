using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5
{
    public class DataObject
    {
        public string CategoryName { get; set; }

        public string Description { get; set; }


        public List<DataObject> GetCollection()
        {
            List<DataObject> coll = new List<DataObject>();
            coll.Add(new DataObject {CategoryName = "apple", Description = "just green apple"});
            coll.Add(new DataObject {CategoryName = "cucumber", Description = "just green cucumber"});
            coll.Add(new DataObject {CategoryName = "banana", Description = "just yellow banana"});
            coll.Add(new DataObject {CategoryName = "watermellon", Description = "just red-green watermellon"});
            return coll;
        }
    }

}