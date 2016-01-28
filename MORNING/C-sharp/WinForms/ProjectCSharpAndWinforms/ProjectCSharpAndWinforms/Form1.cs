using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCSharpAndWinforms
{

    public partial class Form1 : Form
    {
        double x_drag_walk;
        double y_drag_walk;

        LinkedList<Shape> shapes = new LinkedList<Shape>();
        Shape selected_shape;

        public Form1()
        {
            InitializeComponent();

            this.SetStyle(
               System.Windows.Forms.ControlStyles.UserPaint |
               System.Windows.Forms.ControlStyles.AllPaintingInWmPaint |
               System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer,
               true);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (selected_shape != null)
            {
                if (selected_shape.x < 0)
                    selected_shape.x = 0;

                if (selected_shape.y < 0)
                    selected_shape.y = 0;

                if (selected_shape.x > main_panel.Width - selected_shape.width)
                    selected_shape.x = main_panel.Width - selected_shape.width;

                if (selected_shape.y > main_panel.Height - selected_shape.height)
                    selected_shape.y = main_panel.Height - selected_shape.height;

                x_pos_numeric.Value = (decimal)selected_shape.x;
                y_pos_numeric.Value = (decimal)selected_shape.y;
                width_numeric.Value = (decimal)selected_shape.width;
                height_numeric.Value = (decimal)selected_shape.height;
                border_width_numeric.Value = (decimal)selected_shape.stroke_width;
                fill_color_panel.BackColor = selected_shape.fill_color.Color;
                border_color_panel.BackColor = selected_shape.stroke.Color;
                
            }
            else
            {
                x_pos_numeric.Value = 0;
                y_pos_numeric.Value = 0;
                width_numeric.Value = 0;
                height_numeric.Value = 0;
                border_width_numeric.Value = 0;
                fill_color_panel.BackColor = Color.White;
                border_color_panel.BackColor = Color.White;
            }
        }

        private void fill_color_panel_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog1.ShowDialog();
            fill_color_panel.BackColor = colorDialog1.Color;
            if (selected_shape != null)
            {
                selected_shape.fill_color.Color = colorDialog1.Color;
            }
            this.Refresh();
        }

        private void square_draw_button_MouseClick(object sender, MouseEventArgs e)
        {
            selected_shape = new Square();
            shapes.AddLast(selected_shape);
            this.Refresh();
        }

        private void main_panel_Paint(object sender, PaintEventArgs e)
        {
            Graphics ggg = main_panel.CreateGraphics();
            foreach (var shape in shapes)
            {
                shape.draw(ggg);
            }
        }

        private void x_pos_numeric_ValueChanged(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                selected_shape.x = (double)x_pos_numeric.Value;
                this.Refresh();
            }
        }

        private void y_pos_numeric_ValueChanged(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                selected_shape.y = (double)y_pos_numeric.Value;
                this.Refresh();
            }
        }

        private void width_numeric_ValueChanged(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                selected_shape.width = (double)width_numeric.Value;
                this.Refresh();
            }
        }

        private void height_numeric_ValueChanged(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                selected_shape.height = (double)height_numeric.Value;
                this.Refresh();
            }
        }

        private void delete_button_MouseClick(object sender, MouseEventArgs e)
        {
            if (selected_shape != null)
            {
                shapes.Remove(selected_shape);
                selected_shape = null;
                this.Refresh();
            }
        }

        private void border_width_numeric_ValueChanged(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                selected_shape.stroke_width = (double)border_width_numeric.Value;
                selected_shape.stroke = new Pen(selected_shape.stroke.Color, (int)selected_shape.stroke_width);
                main_panel.Refresh();
            }
        }

        private void border_color_panel_MouseClick(object sender, MouseEventArgs e)
        {
            colorDialog1.ShowDialog();
            border_color_panel.BackColor = colorDialog1.Color;
            if (selected_shape != null)
            {
                selected_shape.stroke.Color = colorDialog1.Color;
            }
           this.Refresh();
        }

        private void main_panel_MouseDown(object sender, MouseEventArgs e)
        {
            selected_shape = null;

            foreach (var shape in shapes)
            {
                if (shape.isSelected(e) == true)
                {
                    selected_shape = shape;
                    x_drag_walk = e.X - selected_shape.x;
                    y_drag_walk = e.Y - selected_shape.y;
                }
            }
        }

        private void main_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (selected_shape != null)
                {
                    contextMenuStrip1.Show(Control.MousePosition);
                }
            }

            if (selected_shape != null)
            {
                selected_shape.x = e.X - x_drag_walk;
                selected_shape.y = e.Y - y_drag_walk;
                main_panel.Refresh();
            }
            this.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (selected_shape != null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete:
                        shapes.Remove(selected_shape);
                        selected_shape = null;
                        this.Refresh();
                        break;
                    default:
                        break;
                }
            }
        }

        private void circle_draw_button_MouseClick(object sender, MouseEventArgs e)
        {
            selected_shape = new Circle();
            shapes.AddLast(selected_shape);
            this.Refresh();
        }

        private void triangle_draw_button_Click(object sender, EventArgs e)
        {
            selected_shape = new Traingle();
            shapes.AddLast(selected_shape);
            this.Refresh();
        }

        private void border_style_button_Click(object sender, EventArgs e)
        {
           contextMenuStrip2.Show(border_style_button.Location.X + this.Bounds.X + 8, border_style_button.Location.Y + this.Bounds.Y + 50);
        }

        private void Solid_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                selected_shape.stroke.DashStyle = DashStyle.Solid;
                this.Refresh();
            }
        }

        private void Dot_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                foreach (var shape in shapes)
                {
                    if (shape == selected_shape)
                    {
                        DashStyle dash = new DashStyle();
                        dash = DashStyle.Dot;
                        shape.stroke.DashStyle = dash;
                        this.Refresh();
                    }
                }
            }
            
        }

        private void Dash_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                selected_shape.stroke.DashStyle = DashStyle.Dash;
                this.Refresh();
            }
        }

        private void DashDot_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                selected_shape.stroke.DashStyle = DashStyle.DashDot;
                this.Refresh();
            }
        }

        private void to_first_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapes.AddLast(selected_shape);
            shapes.Remove(selected_shape);
            this.Refresh();
        }

        private void to_next_eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinkedListNode<Shape> n = shapes.Find(selected_shape);
            shapes.AddAfter(n.Next, selected_shape);
            shapes.Remove(selected_shape);
            this.Refresh();
        }

        private void to_last_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapes.Remove(selected_shape);
            shapes.AddFirst(selected_shape);
            this.Refresh();
        }

        private void copy_button_Click(object sender, EventArgs e)
        {
            Shape copy = selected_shape.inicialize_type();

            copy.fill_color = new SolidBrush(selected_shape.fill_color.Color);
            copy.height = selected_shape.height;
            copy.width = selected_shape.width;
            copy.stroke = new Pen(selected_shape.stroke.Color, (int)selected_shape.stroke_width);

            DashStyle border_style = new DashStyle();
            border_style = selected_shape.stroke.DashStyle;
            copy.stroke.DashStyle = border_style;

            copy.stroke_width = selected_shape.stroke_width;
            
            copy.x = 0;
            copy.y = 0;

            shapes.AddLast(copy);
            main_panel.Refresh();
        }

        private void DashDotDot_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected_shape != null)
            {
                selected_shape.stroke.DashStyle = DashStyle.DashDotDot;
                this.Refresh();
            }
        }

        private void safe_button_Click(object sender, EventArgs e)
        {
            //http://www.ucancode.net/ActiveX_Programming_Article_Com_Tutorial/Create-Open-Load-Save-Import-Export-Edit-SVG-File-Document-With-C-NET-Class-Library.htm

        }

    }
}
