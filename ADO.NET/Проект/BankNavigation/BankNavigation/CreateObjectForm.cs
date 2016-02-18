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

        void CreateObjectForm_Load(object sender, EventArgs e)
        {
            List<MyLibrary.Bank> banks = DBHandler.getBanks();
            foreach (var item in banks)
            {
                cbBank.Items.Add(item.Name);
            }

            List<MyLibrary.Cashier> cashiers = DBHandler.getCashiers();
            foreach (var item in cashiers)
            {
                cbCashier.Items.Add(item.FirstName + " " + item.LastName);
            }

            cbCashier.Items.Add("Добавить нового кассира");

            List<MyLibrary.Service> services = DBHandler.getServices();
            foreach (var item in services)
            {
                chlbServices.Items.Add(item.Name);
            }
            
        }


    }
}
