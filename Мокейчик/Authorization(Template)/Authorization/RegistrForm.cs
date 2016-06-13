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
    public partial class RegistrForm : Form
    {

     
        public RegistrForm()
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
                SqlCommand command = new SqlCommand(String.Format("SELECT Name FROM Users WHERE" +
                    " Name = '{0}'", tbLogin.Text), connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read() != true)
                {
                    if (tbPas.Text == tbPas2.Text && 
                        tbPas.Text.Length > 5 &&
                        tbLogin.Text.Length>0 &&
                        tbEmail.Text.Length>0)
                    {
                        reader.Close();

                        SqlCommand commandInsert = connection.CreateCommand();
                        commandInsert.CommandText = String.Format("INSERT INTO Users (Name, Password, Email) VALUES ('{0}','{1}','{2}')",
                            tbLogin.Text, tbPas.Text,tbEmail.Text);
                        
                        if (commandInsert.ExecuteNonQuery() > 0)
                        {
                            commandInsert = connection.CreateCommand();
                            commandInsert.CommandText = String.Format("INSERT INTO UsersInfo (FirstName, LastName) VALUES ('{0}','{1}')",
                            tbName.Text, tbSurName.Text);
                            if (commandInsert.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("данные успешно добавлены");
                                Close();
                            }
                            
                        }
                        else
                            MessageBox.Show("данные не добавлены");
                    }
                    else
                       MessageBox.Show("данные введены не верно");
                }
                else 
                    MessageBox.Show("Такой логин уже существует");

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
