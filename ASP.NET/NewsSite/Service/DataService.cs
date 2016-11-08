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
            return db.News.Select(p => p).ToList();
        }

        public News GetNewsById(int _id)
        {
            //db.Database.Initialize(true);
            return db.News.Find(_id);
        }

        public List<News> GetNewsByName(string name)
        {
            return db.News.Where(p => p.Header == name).Select(n => n).ToList(); 
        }

        public News Create(string _header, string _body, bool _hot, TypeEnum _type)
        {
            News n = new News() { Header = _header, Body = _body, CreateData = DateTime.Now, Hot = _hot, Type = _type, Comments = new List<Comment>()};
            db.News.Add(n);
            db.SaveChanges();
            return db.News.Where(p => p.Header == _header).First();
        }

        public void Update(News _news)
        {
            var n = db.News.Find(_news.NewsID);
            n.Header = _news.Header;
            n.Body = _news.Body;
            n.Hot = _news.Hot;
            n.Type = _news.Type;
            db.SaveChanges();
        }
        public void Delete(int _id)
        {
            var n = db.News.Select(p => p).Where(p => p.NewsID == _id).First();
            db.News.Remove(n);
            db.SaveChanges();
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
