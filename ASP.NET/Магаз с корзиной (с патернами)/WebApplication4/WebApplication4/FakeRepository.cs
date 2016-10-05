using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class FakeRepository : IRepository
    {
        public List<DataObject> repository = new List<DataObject>();
        public FakeRepository()
        {
            repository.Add(new DataObject() { Name = "бананы" });
            repository.Add(new DataObject() { Name = "яблоки" });
            repository.Add(new DataObject() { Name = "груша" });
            repository.Add(new DataObject() { Name = "капуста" });
            repository.Add(new DataObject() { Name = "картофель" });
            repository.Add(new DataObject() { Name = "огурцы" });
            repository.Add(new DataObject() { Name = "помидоры" });
        }

        public List<DataObject> GetAll()
        {
            return repository;
        }

        public DataObject GetItem(int id_item)
        {
            foreach (var i in repository)
                if(i.Id == id_item) return i;

            return null;
        }

        public void DeleteItem(int id_item)
        {
            int d = 0;
            foreach (var i in repository)
                if (i.Id == id_item) d = i.Id;
            if(d != 0)
                repository.RemoveAt(d);
        }

        public void AddItem(DataObject item)
        {
            repository.Add(item);
        }

        public void UpdateItem(int id_item, DataObject value)
        {
            //foreach (var i in repository)
            //    if (i.Id == id_item)
            //    {
            //        i = value;
            //    }
        }
    }
}