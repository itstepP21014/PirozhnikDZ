using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharpAndWinforms
{
    class Circle : Shape
    {
        public Circle(): base()
        {
            
        }

        public override void draw(Graphics g)
        {
            g.FillEllipse(fill_color, (int)x, (int)y, (int)width, (int)height);
            g.DrawEllipse(stroke, (int)x + (int)stroke_width / 2, (int)y + (int)stroke_width/2, (int)width - (int)stroke_width, (int)height - (int)stroke_width);
        }

        public override bool isSelected(MouseEventArgs e)
        {
            bool result = false;
            int x_0 = (int)(this.x + this.width / 2);
            int y_0 = (int)(this.y + this.height / 2);
            if (Math.Pow((e.X - x_0), 2) / Math.Pow((this.width / 2), 2) + Math.Pow((e.Y - y_0), 2) / Math.Pow((this.height / 2), 2) <= 1)
            {
                result = true;
            }
            return result;
        }
    }
}
