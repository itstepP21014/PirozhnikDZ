using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization
{
    public partial class AutorizForm : Form
    {


        public AutorizForm()
        {
            InitializeComponent();
        }


        private void AutorizForm_Load(object sender, EventArgs e)
        {


        }

        void tbPassword_GotFocus(object sender, EventArgs e)
        {
            if (tbPassword.Text == "Пароль")
            {
                tbPassword.ForeColor = Color.Black;
                tbPassword.Text = "";
                tbPassword.PasswordChar = '*';
            }
        }

        void tbPassword_LostFocus(object sender, EventArgs e)
        {
            if (tbPassword.Text.Length == 0)
            {
                tbPassword.ForeColor = Color.LightGray;
                tbPassword.Text = "Пароль";
                tbPassword.PasswordChar = '\0';
            }
        }

        void tbName_LostFocus(object sender, EventArgs e)
        {
            if (tbName.Text.Length == 0)
            {
                tbName.ForeColor = Color.LightGray;
                tbName.Text = "Имя пользователя";
            }
        }

        void tbName_GotFocus(object sender, EventArgs e)
        {
            if (tbName.Text == "Имя пользователя")
            {
                tbName.ForeColor = Color.Black;
                tbName.Text = "";
            }
        }

        private void linkPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PasswordForm frmPass = new PasswordForm();
            frmPass.ShowDialog();
        }

        private void linkReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrForm frmReg = new RegistrForm();
            frmReg.ShowDialog();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["CSApp"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand(String.Format("SELECT id FROM Users WHERE" +
                    " (Name = '{0}' and Password='{1}')", tbName.Text, tbPassword.Text), connection);

                SqlDataReader reader = command.ExecuteReader();
                // Проходимся по результатам работы запроса строка за строкой
                if (reader.Read() == true)
                {
                    MainForm mainForm = new MainForm();


                    command = new SqlCommand(String.Format("SELECT LastName, FirstName, Adres," +
                        " Phone FROM UsersInfo WHERE UsersInfo.Id = {0}", reader[0]), connection);
                    reader.Close();
                    reader = command.ExecuteReader();
                    if (reader.Read() == true)
                    {
                        mainForm.UserInfo = "Имя " + reader[0].ToString().TrimEnd() + Environment.NewLine +
                            "Фамилия " + reader[1].ToString().TrimEnd() + Environment.NewLine +
                            "Адрес " + reader[2].ToString().TrimEnd() + Environment.NewLine +
                            "Телефон " + reader[3].ToString().TrimEnd();
                    }
                    else
                        MessageBox.Show("Не нашлись данные пользователя");
                    mainForm.ShowDialog();

                }
                else
                    MessageBox.Show("Не верный логин, либо пароль");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }

}
