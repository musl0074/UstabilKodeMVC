using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilkodeApi.Data
{
    public class Post
    {
        // Keys
        public int ID { get; set; }

        // Navigation properties
        public List<Comment> Comments { get; set; } = new List<Comment>();

        // Data-Properties
        public string UserID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
