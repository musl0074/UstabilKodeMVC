using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UstabilKodeMVC.Models;
using UstabilKodeMVC.Models.ProductViewModels;
using UstabilKodeMVC.Services.UstabilkodeAPI;

namespace UstabilKodeMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProductController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var products = await ProductEndpoints.GetProducts();
            var currentUser = await _userManager.GetUserAsync(User);

            return View(new ProductsUser() { Products = products, CurrentUser = currentUser });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name, string details, double price)
        {
            var result = await ProductEndpoints.CreateProduct(name, details, price);

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await ProductEndpoints.GetProduct(id);
            
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            var result = await ProductEndpoints.UpdateProduct(product);

            return RedirectToAction("Index", "Product");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ProductEndpoints.DeleteProduct(id);
            
            return RedirectToAction("Index", "Product");
        }

    }
}