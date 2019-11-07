using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Models
{
    public class Post
    {
        public int ID { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
