using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Example
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            var new_password = new_password_textBox.Text;
            var check_password = check_new_password_textBox.Text;
            if (new_password == check_password)
            {
                State.current_teacher["password"].InnerText = new_password;
                State.doc.Save("C:/users/st/teachers.xml");
                MessageBox.Show("Your password was successfully changed!", "Success", MessageBoxButtons.OK);
                this.Hide();
                State.form2.Show();
                
            }
            else
            {
                MessageBox.Show("Пароль не совпадает!", "Error", MessageBoxButtons.OK);
                //private ToolTip tt;

                //private void textBox1_Enter(object sender, EventArgs e) {
                //  tt = new ToolTip();
                //  tt.InitialDelay = 0;
                //  tt.IsBalloon = true;
                //  tt.Show(string.Empty, textBox1);
                //  tt.Show("I need help", textBox1, 0);
                //}

                //private void textBox1_Leave(object sender, EventArgs e) {
                //  tt.Dispose();
                //}

               
            }

        }
    }
}
