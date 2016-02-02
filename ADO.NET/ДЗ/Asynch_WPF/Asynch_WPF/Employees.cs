using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Asynch_WPF
{
    class Employees
    {
        public Employees()
        {
            Photo = new Image();
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private DateTime birthday;

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        private string adress;

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        private string phone;

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        private Image photo;

        public Image Photo
        {
            get { return photo; }
            set { photo = value; }
        }


    }
}
