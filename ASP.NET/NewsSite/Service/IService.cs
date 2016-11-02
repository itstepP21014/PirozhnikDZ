using DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IService
    {
        List<News> GetAllNews();

        //DataObject GetItem(int id_item);

        //void DeleteItem(int id_tem);

        //void AddItem(DataObject item);

        //void UpdateItem(int id_item, DataObject value);
    }
}
