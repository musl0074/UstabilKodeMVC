using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UstabilKodeMVC.Data;
using UstabilKodeMVC.Models.ForumViewModels;
using UstabilKodeMVC.Services.UstabilkodeAPI;

namespace UstabilKodeMVC.Controllers
{
    [Authorize] 
    public class ForumController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ForumController(DatabaseContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        public async Task<IActionResult> Index()
        {
            var posts = await PostEndpoints.GetPosts();
            var userNames = new List<string>();

            List<IdentityUser> users = _userManager.Users.ToList();
            for (int i = 0; i < posts.Count; i++)
            {
                foreach (var user in users)
                {
                    if (user.Id == posts[i].UserID)
                        userNames.Add(user.UserName);
                }
            }

            return View(new PostsUsers() { Posts = posts, Usernames = userNames });
        }
    }
}