using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UstabilKodeMVC.Services.UstabilkodeAPI;

namespace UstabilKodeMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var posts = await PostEndpoints.GetPosts();

            // Delete all comments from the user
            foreach (var post in posts)
            {
                foreach (var comment in post.Comments)
                {
                    if (comment.UserID == user.Id)
                    {
                        await CommentEndpoints.DeleteComment(comment.ID);
                    }
                }
            }

            // Delete all posts by user
            foreach (var post in posts)
            {
                if(post.UserID == user.Id)
                {
                    // First delete all comments on that post
                    foreach (var comment in post.Comments)
                    {
                        await CommentEndpoints.DeleteComment(comment.ID);
                    }

                    // Then delete the post
                    await PostEndpoints.DeletePost(post.ID);
                }
            }

            // Delete the user from the database
            var result = await _userManager.DeleteAsync(user);

            return RedirectToAction("Index", "User");
        }
    }
}