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
            List<MyLibrary.Bank> banks = DBHandler.getBanks();
            foreach (var item in banks)
            {
                cbBank.Items.Add(item.Name);
            }

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
            //добавление в базу
            Adress newAdress = new Adress()
            {
                City = tbCity.Text,
                Street = tbStreet.Text,
                Build = Int32.Parse(tbBuild.Text),
                Body = Int32.Parse(tbBody.Text),
                Cabinet = Int32.Parse(tbCabinete.Text)
            };

            Cashier newCashier = new Cashier()
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text
            };

            List<Service> services = new List<Service>();
            foreach (var item in chlbServices.CheckedItems)
            {
                services.Add(new Service() { Name = item.ToString() } );
            }


            Bank bank = DBHandler.getBanks().FirstOrDefault(b => b.Name == cbBank.SelectedItem.ToString());

            Branch newObject = new Branch()
            {
                Name = tbName.Text,
                Bank = bank,
                Phone = tbPhone.Text,
                Adress = newAdress,
                XPosition = PositionX,
                YPositon = PositionY,
                CreationDate = DateTime.Now,
                Time = tbWorkTime.ToString(),
                Cashier = newCashier,
                Services = services
            };

            DBHandler.add(newObject);

            // перезагружаем карту

        }


    }
}
