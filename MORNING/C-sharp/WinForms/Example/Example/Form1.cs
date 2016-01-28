using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Text = "Hello";
            //this.button1.Text = "Что-нибудь";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // действия, кторые будут после того, как форма создастся

        }

        private void OK_button_Click(object sender, EventArgs e)
        {
            var check = State.doc.SelectSingleNode("teachers/teacher[login='" + login_textBox.Text + "']");
            if (check != null)
            {
                check = State.doc.SelectSingleNode("teachers/teacher[password='" + password_textBox.Text + "' and login='" + login_textBox.Text + "']");
                if (check != null)
                {
                    State.current_teacher = check;
                    State.form2 = new Form2();
                    State.form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Неверный пароль!", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем не существует.", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
