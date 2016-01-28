using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileKeys;

namespace FileDataBase
{
    class DataBase
    {
        // позиции строк в файле
        public Key key;
        public int RecordCount
        {
            get
            {
                return key.keys.Count;
            }
        }

        public DataBase(string filePath)
        {
            key = new Key(filePath);
        }

        public Record selectByName(string name)
        {
            // открываем файл
            // читаем первую строчку и получаем record
            // берем record.name И сравниваем с name
            // if(record.name.Compareto(name) == 0){
            // return этот record;
            // }
            // else if{record.name.Compareto(name) > 0) {
            // name
            // record.name
            // }
            // else { }
            Record res = new Record();
            return res;
        }
    }
}
