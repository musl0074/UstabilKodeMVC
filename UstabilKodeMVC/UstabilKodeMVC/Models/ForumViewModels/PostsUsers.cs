﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Models.ForumViewModels
{
    public class PostsUsers
    {
        public List<Post> Posts { get; set; }
        public List<string> Usernames { get; set; }
    }
}
