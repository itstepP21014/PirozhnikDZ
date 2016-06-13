using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authorization
{
    public partial class PasswordForm : Form
    {
      
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["CSApp"].ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand(String.Format("SELECT Email FROM Users WHERE" +
                    " Email = '{0}'", tbEmail.Text), connection);

                SqlDataReader reader = command.ExecuteReader();
               
                if (reader.Read() == true)
                {
                    if (tbNewPas.Text == tbNewPas2.Text && tbNewPas.Text.Length > 5)
                    {
                        SqlCommand commandUpdate = connection.CreateCommand();
                        commandUpdate.CommandText = String.Format("UPDATE Users SET Password = {0} WHERE Email = '{1}'", tbNewPas.Text, reader[0]);
                        reader.Close();
                        if (commandUpdate.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("пароль успешно изменен");
                            Close();
                        }
                        else
                            MessageBox.Show("пароль не изменен");
                    }
                    else
                        MessageBox.Show("Пароли не совпадают, либо длина меньше 6 символов");
                }
                else
                    MessageBox.Show("Такой Email не найден в базе данных");

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
