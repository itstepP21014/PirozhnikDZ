using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharpAndWinforms
{
    abstract public class Shape
    {
        Color color = new Color();
        public static Random r = new Random();
        public Pen stroke;
        public SolidBrush fill_color;
        public double x, y, height, width, stroke_width;

        protected Shape()
        {
            x = r.Next(0, 500);
            y = r.Next(0, 300);
            height = 100;
            width = 100;
            stroke_width = 10;
            stroke = new Pen(Color.Black, (int)stroke_width);
            color = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            fill_color = new SolidBrush(color);
        }

        abstract public void draw(Graphics e);
        abstract public bool isSelected(MouseEventArgs e);

        public Shape inicialize_type()
        {
            if (Object.ReferenceEquals(this.GetType(), (new Square()).GetType()) == true)
            {
                Shape copy = new Square();
                return copy;
            }

            if (Object.ReferenceEquals(this.GetType(), (new Circle()).GetType()) == true)
            {
                Shape copy = new Circle();
                return copy;
            }

            if (Object.ReferenceEquals(this.GetType(), (new Traingle()).GetType()) == true)
            {
                Shape copy = new Traingle();
                return copy;
            }
            return null;
        }
    }
}
