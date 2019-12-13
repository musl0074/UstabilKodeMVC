using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UstabilKodeMVC.Models;
using UstabilKodeMVC.Services.UstabilkodeAPI;

namespace UstabilKodeMVC.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public SubscriptionController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            var subscriptions = await SubscriptionEndpoints.GetSubscriptions(user.Id);

            return View(subscriptions);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var subscription = await SubscriptionEndpoints.GetSubscription(id);

            return View(subscription);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await SubscriptionEndpoints.DeleteSubscription(id);

            return RedirectToAction("Index", "Subscription");
        }

        [HttpGet]
        public async Task<IActionResult> Renew(Subscription subscription)
        {
            subscription.ExpirationDate = subscription.ExpirationDate.AddMonths(1);

            var result = await SubscriptionEndpoints.RenewSubscription(subscription);

            return RedirectToAction("Get", "Subscription", new { id = subscription.ID });
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var expirationDate = DateTime.Now.AddMonths(1);

            var result = await SubscriptionEndpoints.CreateSubscription(id, user.Id, expirationDate);

            var resultBody = await result.Content.ReadAsStringAsync();
            var subscription = JsonConvert.DeserializeObject<Subscription>(resultBody);

            return RedirectToAction("Get", "Subscription", new { id = subscription.ID });
        }
    }
}