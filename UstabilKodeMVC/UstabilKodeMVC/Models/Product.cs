using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
