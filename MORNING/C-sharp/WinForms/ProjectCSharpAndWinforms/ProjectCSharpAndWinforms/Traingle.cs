using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharpAndWinforms
{
    class Traingle : Shape
    {
        public Traingle(): base()
        {
      
        }

        public override void draw(Graphics g)
        {
            Point point1 = new Point((int)x, (int)(y + height));
            Point point2 = new Point((int)(x + width/2), (int)y);
            Point point3 = new Point((int)(x + width), (int)(y + height));
            Point[] points = { point1, point2, point3};
            g.FillPolygon(fill_color, points);
            points[0].X += (int)(stroke_width / 2);
            points[0].Y -= (int)(stroke_width / 2);
            points[1].Y += (int)(stroke_width / 2);
            points[2].X -= (int)(stroke_width / 2);
            points[2].Y -= (int)(stroke_width / 2);
            g.DrawPolygon(stroke, points);
        }
        public override bool isSelected(MouseEventArgs e)
        {
            bool result = false;

            int a = ((int)x - e.X) * ((int)y - (int)(y + height)) - ((int)(x + width / 2) - (int)x) * ((int)(y + height) - e.Y);
            int b = ((int)(x + width / 2) - e.X) * ((int)(y + height) - (int)y) - ((int)(x + width) - (int)(x + width / 2)) * ((int)y - e.Y);
            int c = ((int)(x + width) - e.X) * ((int)(y + height) - (int)(y + height)) - ((int)x - (int)(x + width)) * ((int)(y + height) - e.Y);
 
            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
            {
                result = true;
            }

            return result;
        }
    }
}
