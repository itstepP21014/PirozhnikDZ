using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal
{
    [Serializable]
    public class Teacher
    {
        static private int last_id = 0;

        public Teacher()
        {
            id = last_id++;
        }

        public string name;
        public int id;


        public Teacher(string _name): this() // чтобы при вызове данного конструктора вызывался и конструктор по умолчанию
        {
            name = _name;
        }

    }
}
