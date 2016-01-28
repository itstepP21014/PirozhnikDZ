using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SVG
{
    class Windows
    {
        int width, height, stroke_width, rastoyaniye;
        string fill_color, stroke_color;
        House house;

        public Windows(House h, string fill, int _stroke_width, string _stoke_color)
        {
            width = ((int)(h.width * 0.3));
            height = ((int)(h.height * 0.17));
            rastoyaniye = ((h.width - 2 * (int)(h.width * 0.3)) / 3);
            fill_color = fill;
            stroke_width = _stroke_width;
            stroke_color = _stoke_color;
            house = h;
        }


        public void Draw_windows(XmlWriter writer)
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 2; ++i)
                {
                    writer.WriteStartElement("rect");
                    writer.WriteAttributeString("x", (house.x_pos + i * rastoyaniye + rastoyaniye + (i * width)).ToString());
                    writer.WriteAttributeString("y", (house.y_pos + j * rastoyaniye + rastoyaniye + (j * height)).ToString());
                    writer.WriteAttributeString("width", width.ToString());
                    writer.WriteAttributeString("height", height.ToString());
                    writer.WriteAttributeString("fill", fill_color);
                    writer.WriteAttributeString("stroke", stroke_color);
                    writer.WriteAttributeString("stroke-width", stroke_width.ToString());
                    writer.WriteEndElement();
                }
            }
        }

    }
}
