using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }
        public string Content { get; set; }
        public string UserID { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
