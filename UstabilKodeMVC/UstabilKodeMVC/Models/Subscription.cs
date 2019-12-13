using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Models
{
    public class Subscription
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
