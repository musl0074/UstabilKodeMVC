using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UstabilKodeMVC.Models;
using UstabilKodeMVC.Models.ForumViewModels;
using UstabilKodeMVC.Services.UstabilkodeAPI;

namespace UstabilKodeMVC.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public PostController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
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

            return RedirectToAction("Index", "Post");
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var post = await PostEndpoints.GetPost(id);
            var username = _userManager.Users.Where((user) => user.Id == post.UserID).FirstOrDefault().UserName;
            var currentUser = await _userManager.GetUserAsync(User);

            var username_comments = new List<string>();
            foreach (var comment in post.Comments)
            {
                var comment_username = _userManager.Users.Where((user) => user.Id == comment.UserID).FirstOrDefault().UserName;
                username_comments.Add(comment_username);
            }

            return View(new PostUsername() { Post = post, Username = username, CurrentUser = currentUser, Username_comments = username_comments});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await PostEndpoints.GetPost(id);
            
            if(_userManager.GetUserId(User) != post.UserID) // Wrong user, trying to edit another post
            {

            }

            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            var postToUpdate = await PostEndpoints.GetPost(post.ID);
            postToUpdate.Title = post.Title;
            postToUpdate.Content = post.Content;
            postToUpdate.RowVersion = post.RowVersion;

            var result = await PostEndpoints.UpdatePost(postToUpdate);

            return RedirectToAction("Get", "Post", new { id = postToUpdate.ID });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await PostEndpoints.DeletePost(id);

            return RedirectToAction("Index", "Post");
        }
    }
}