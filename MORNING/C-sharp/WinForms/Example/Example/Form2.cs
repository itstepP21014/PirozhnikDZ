using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Example
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.label1.Text = "Здравствуйте, " + State.current_teacher["name"].InnerText;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void change_password_button_Click(object sender, EventArgs e)
        {
            State.form3 = new Form3();
            State.form3.Show();
            this.Hide();
        }

        private void start_lesson_button_Click(object sender, EventArgs e)
        {
            State.form4 = new Form4();
            State.form4.Show();
            this.Hide();
        }

        private void last_lessons_lable_Click(object sender, EventArgs e)
        {
            State.form5 = new Form5();
            State.form5.Show();
            this.Hide();
        }
    }
}
