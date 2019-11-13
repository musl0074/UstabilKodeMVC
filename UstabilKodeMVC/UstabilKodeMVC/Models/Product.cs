using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UstabilKodeMVC.Models
{
    public class Product
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string Details { get; set; }
        
        public double Price { get; set; }
       
        public byte[] RowVersion { get; set; }
    }
}
