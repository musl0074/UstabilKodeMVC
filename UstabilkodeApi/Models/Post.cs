using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilkodeApi.Data
{
    public class Post
    {
        // Keys
        public int ID { get; set; }

        // Navigation properties
        public ICollection<Comment> Comments { get; set; }

        // Data-Properties
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
