using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilkodeApi.Data
{
    public class Comment
    {
        // Keys
        public int ID { get; set; }
        public int PostID { get; set; }

        // Navigation properties
        public Post Post { get; set; }

        // Data-Properties
        public string Content { get; set; }
        public string UserID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
