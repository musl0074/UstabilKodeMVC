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
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string ProductName { get; set; }
        [JsonProperty("details")]
        public string Details { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
