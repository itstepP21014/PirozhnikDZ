using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary;

namespace BankNavigation
{
    public partial class CreateObjectForm : Form
    {
        public CreateObjectForm()
        {
            InitializeComponent();
            Load += CreateObjectForm_Load;
        }

        public double PositionX { get; set; }
        public double PositionY { get; set; }

        void CreateObjectForm_Load(object sender, EventArgs e)
        {
            cbBank.DataSource = DBHandler.getBanks();
            cbBank.DisplayMember = "Name";

            List<MyLibrary.Service> services = DBHandler.getServices();
            foreach (var item in services)
            {
                chlbServices.Items.Add(item.Name);
            }       
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbPhone.Text == "" || tbCity.Text == "" || tbStreet.Text == "" ||
                tbBuild.Text == "" || tbWorkTime.Text == "" || tbFirstName.Text == "" ||
                tbLastName.Text == "" || chlbServices.CheckedItems.Count == 0)
            {
                MessageBox.Show("Заполните необходимые поля!");
            }
            else
            {
                Adress newAdress = new Adress()
                {
                    City = tbCity.Text,
                    Street = tbStreet.Text,
                    Build = tbBuild.Text,
                    Body = tbBody.Text,
                    Cabinet = tbCabinete.Text
                };

                Cashier newCashier = new Cashier()
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text
                };

                List<Service> services = new List<Service>();
                foreach (var item in chlbServices.CheckedItems)
                {
                    services.Add(new Service() { Name = item.ToString() });
                }

                Branch newObject = new Branch()
                {
                    Name = tbName.Text,
                    Bank = (Bank)cbBank.SelectedItem,
                    Phone = tbPhone.Text,
                    Adress = newAdress,
                    XPosition = PositionX,
                    YPositon = PositionY,
                    CreationDate = DateTime.Now,
                    Time = tbWorkTime.Text,
                    Cashier = newCashier,
                    Services = services
                };

                DBHandler.add(newObject);
                this.Hide();
            }
        }

    }
}
