using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asynch_WPF
{
    class Orders
    {
        public Orders()
        {

        }

        // данные о клиенте

        private string companyName;

        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }

        private string contactName;

        public string ContactName
        {
            get { return contactName; }
            set { contactName = value; }
        }

        private string adress;

        public string Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }

        private string country;

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string phon;

        public string Phon
        {
            get { return phon; }
            set { phon = value; }
        }
        
        // данные о заказе

        private DateTime date_of_order;

        public DateTime Date_of_order
        {
          get { return date_of_order; }
          set { date_of_order = value; }
        }

        private DateTime date_of_supply;

        public DateTime Date_of_supply
        {
          get { return date_of_supply; }
          set { date_of_supply = value; }
        }

        private int transit_cost;

        public int Transit_cost
        {
            get { return transit_cost; }
            set { transit_cost = value; }
        }

        private string city_of_supply;

        public string City_of_supply
        {
          get { return city_of_supply; }
          set { city_of_supply = value; }
        }

        private string country_of_supply;

        public string Country_of_supply
        {
          get { return country_of_supply; }
          set { country_of_supply = value; }
        }

        private string region_of_supply;

        public string Region_of_supply
        {
          get { return region_of_supply; }
          set { region_of_supply = value; }
        }

        // дополнительные данные о заказе

        private int price;

        public int Price
        {
          get { return price; }
          set { price = value; }
        }

        private int count;

        public int Count
        {
          get { return count; }
          set { count = value; }
        }

        private int cost;

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
}
