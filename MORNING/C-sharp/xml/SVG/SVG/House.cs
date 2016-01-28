using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVG
{
    class House
    {
        public int width, height, deep, x_pos, y_pos, stroke_width;
        public string fill_color, stroke_color;

        public House(int _width, int _height, int _deep, int x, int y, string fill, int _stroke_width, string stroke)
        {
            width = _width;
            height = _height;
            deep = _deep;
            x_pos = x;
            y_pos = y;
            fill_color = fill;
            stroke_width = _stroke_width;
            stroke_color = stroke;
        }

        public void Draw_house(XmlWriter writer)
        {
            writer.WriteStartElement("polyline");
            string points = x_pos.ToString() + "," + y_pos.ToString() + " " +
                            (x_pos + deep).ToString() + "," + (y_pos - deep).ToString() + " " +
                            (x_pos + deep + width).ToString() + "," + (y_pos - deep).ToString() + " " +
                            (x_pos + deep + width).ToString() + "," + (y_pos - deep + height).ToString() + " " +
                            (x_pos + width).ToString() + "," + (y_pos + height).ToString() + " " +
                            x_pos.ToString() + "," + (y_pos + height).ToString() + " " +
                            x_pos.ToString() + "," + y_pos.ToString();
            writer.WriteAttributeString("points", points);
            writer.WriteAttributeString("fill", fill_color);
            writer.WriteAttributeString("stroke", stroke_color);
            writer.WriteAttributeString("stroke-width", stroke_width.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("polyline");
            string points_2 = x_pos.ToString() + "," + y_pos.ToString() + " " +
                              (x_pos + width).ToString() + "," + y_pos.ToString() + " " +
                              (x_pos + width).ToString() + "," + (y_pos + height).ToString();
            writer.WriteAttributeString("points", points_2);
            writer.WriteAttributeString("fill", fill_color);
            writer.WriteAttributeString("stroke", stroke_color);
            writer.WriteAttributeString("stroke-width", stroke_width.ToString());
            writer.WriteEndElement();
            writer.WriteStartElement("polyline");
            string points_3 = (x_pos + width).ToString() + "," + y_pos.ToString() + " " +
                              (x_pos + width + deep).ToString() + "," + (y_pos - deep).ToString();
            writer.WriteAttributeString("points", points_3);
            writer.WriteAttributeString("stroke", stroke_color);
            writer.WriteAttributeString("stroke-width", stroke_width.ToString());
            writer.WriteEndElement();



        }



    }
}
