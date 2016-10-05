using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    public interface IService
    {
        List<DataObject> GetAll();

        DataObject GetItem(int id_item);

        void DeleteItem(int id_tem);

        void AddItem(DataObject item);

        void UpdateItem(int id_item, DataObject value);
    }
}