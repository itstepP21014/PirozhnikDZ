using DataContext;
using DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DataService : IService
    {
        //public FakeRepository repository;

        //public DataService(FakeRepository _repository)
        //{
        //    repository = _repository;
        //}


        DataContext.Context db = new Context();

        public List<News> GetAllNews()
        
        {
            //db.Database.Initialize(true);
            db.News.Add(new News());
            db.News.Add(new News());
            db.News.Add(new News());
            db.SaveChanges();

            return db.News.Select(p => p).ToList();
        }

        //public DataObject GetItem(int id_item)
        //{
        //    return repository.GetItem(id_item);
        //}

        //public void DeleteItem(int id_tem)
        //{
        //    repository.DeleteItem(id_tem);
        //}

        //public void AddItem(DataObject item)
        //{
        //    repository.AddItem(item);
        //}

        //public void UpdateItem(int id_item, DataObject value)
        //{
        //    repository.UpdateItem(id_item, value);
        //}
    }
}
