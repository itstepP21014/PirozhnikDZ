using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace xml
{
    class Automobile
    {
        public string manufactured, model, color, year, speed;

        public Automobile(string _manufactured, string _model, string _color, string _year, string _speed)
        {
            manufactured = _manufactured;
            model = _model;
            color = _color;
            year = _year;
            speed = _speed;
        }

        public Automobile(XmlElement node)
        {
            // manufactured = node["Manufactured"].ChildNodes[0].Value;
            manufactured = node["Manufactured"].InnerText;
            model = node["Model"].InnerText;
            color = node["Color"].InnerText;
            year = node["Year"].InnerText;
            speed = node["Speed"].InnerText;
        }


    }
}
