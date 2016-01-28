using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolJournal
{
    [Serializable]
    public class Pupil
    {
        static private int last_id = 0;
        
        public Pupil()
        {
            id = last_id++;
        }

        public string name;
        public Lesson[] attended_classes;
        public int id;

        public Pupil(string _name) : this() // чтобы при вызове данного конструктора вызывался и конструктор по умолчанию
        {
            name = _name;
        }
    }
}
