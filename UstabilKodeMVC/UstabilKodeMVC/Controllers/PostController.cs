using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UstabilKodeMVC.Models.ForumViewModels;
using UstabilKodeMVC.Services.UstabilkodeAPI;

namespace UstabilKodeMVC.Controllers
{
    public class PostController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public PostController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(string title, string content)
        {
            string userId = _userManager.GetUserId(User);
            HttpResponseMessage response = await PostEndpoints.CreatePost(userId, title, content);

            return RedirectToAction("Index", "Forum");
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var post = await PostEndpoints.GetPost(id);
            var username = _userManager.Users.Where((user) => user.Id == post.UserID).FirstOrDefault().UserName;
            var currentUser = await _userManager.GetUserAsync(User);

            return View(new PostUsername() { Post = post, Username = username, CurrentUser = currentUser });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await PostEndpoints.DeletePost(id);

            return RedirectToAction("Index", "Forum");
        }
    }
}