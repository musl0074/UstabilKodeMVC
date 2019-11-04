using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilkodeApi.Models
{
    public class Product
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }


        public Product()
        {

        }

        public Product(string name, string details, double price)
        {
            Name = name;
            Details = details;
            Price = price;
        }
    }
}
