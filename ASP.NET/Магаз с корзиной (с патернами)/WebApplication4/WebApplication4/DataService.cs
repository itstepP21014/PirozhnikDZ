using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public class DataService : IService
    {
        public FakeRepository repository;

        public DataService(FakeRepository _repository)
        {
            repository = _repository;
        }

        public List<DataObject> GetAll()
        {
            return repository.GetAll();
        }

        public DataObject GetItem(int id_item)
        {
            return repository.GetItem(id_item);
        }

        public void DeleteItem(int id_tem)
        {
            repository.DeleteItem(id_tem);
        }

        public void AddItem(DataObject item)
        {
            repository.AddItem(item);
        }

        public void UpdateItem(int id_item, DataObject value)
        {
            repository.UpdateItem(id_item, value);
        }
    }
}