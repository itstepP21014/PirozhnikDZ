using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharpAndWinforms
{
    class Square : Shape
    {
        public Square(): base()
        {
      
        }

        public override void draw(Graphics g)
        {
            g.FillRectangle(fill_color, (int)x, (int)y, (int)width, (int)height);
            g.DrawLine(stroke, (int)x, (int)y + (int)stroke_width / 2, (int)(x + width), (int)y + (int)stroke_width / 2);
            g.DrawLine(stroke, (int)(x + width) - (int)stroke_width / 2, (int)y, (int)(x + width) - (int)stroke_width / 2, (int)(y + height));
            g.DrawLine(stroke, (int)(x + width), (int)(y + height) - (int)stroke_width / 2, (int)x, (int)(y + height) - (int)stroke_width / 2);
            g.DrawLine(stroke, (int)x + (int)stroke_width / 2, (int)(y + height), (int)x + (int)stroke_width / 2, (int)y);
        }

        public override bool isSelected(MouseEventArgs e)
        {
            bool result = false;
                if (e.X >= this.x && e.X <= (this.x + this.width) &&
                          e.Y >= this.y && e.Y <= (this.y + this.height))
                {
                    result = true;
                }
            return result;
        }
    }
}
