using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class City
    {
        public string Name { get; set; }
        public string Language { get; set; }

        public List<City> GetCityCollection(string sortColumns, int startRecord, int maxRecords)
        {
            return new List<City> {
                new City {Name = "Moskow", Language = "Russian"},
                new City {Name = "Minsk", Language = "Belorussian"},
                new City {Name = "Vilnus", Language = "Lithuanian"},
                new City {Name = "Paris", Language = "French"},
                new City {Name = "Berlin", Language = "German"},
                new City {Name = "Tokio", Language = "Japanise"}
            };
        }
    }
}