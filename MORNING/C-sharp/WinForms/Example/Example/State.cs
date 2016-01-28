using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Example
{
    public static class State
    {
        public static XmlDocument doc;
        public static XmlNode current_teacher;
        public static Form2 form2;
        public static Form3 form3;
        public static Form4 form4;
        public static Form5 form5;

        static State()
        {
            doc = new XmlDocument();
            doc.Load("C:/users/st/teachers.xml");

        }

    }
}
