using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Models.ForumViewModels
{
    public class PostUsername
    {
        public Post Post { get; set; }
        public string Username;
        public IdentityUser CurrentUser { get; set; }

        public List<string> Username_comments { get; set; }

    }
}
