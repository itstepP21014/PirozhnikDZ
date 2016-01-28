using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace serialization
{
    [Serializable]
    public class Schollchild // классы для xml сериализации долны быть public
    {
        public Schollchild() { } // для xml сериализации обязательно должны прописываться конструкторы по умолчанию

        public Backpack ruckzack;
        public Pen[] pens;

        [XmlIgnore] // для сериализации в XML
        [NonSerialized] // для бинарной сериализации
        public Notebook[] notebook;
    }
}
