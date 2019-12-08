using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UstabilKodeMVC.Models;
using UstabilKodeMVC.Services.UstabilkodeAPI;

namespace UstabilKodeMVC.Controllers
{
    public class CommentController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public CommentController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int postId, string content)
        {
            var userId = await _userManager.GetUserIdAsync(await _userManager.GetUserAsync(User));
            var result = CommentEndpoints.CreateComment(postId, userId, content);

            return RedirectToAction("Get", "Post", new { id = postId });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int postId, int commentId)
        {
            var result = await CommentEndpoints.DeleteComment(commentId);

            return RedirectToAction("Get", "Post", new { id = postId });
        }
    }
}