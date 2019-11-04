using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UstabilKodeMVC.Data;
using UstabilKodeMVC.Models;
using UstabilKodeMVC.Models.ProductViewModels;

namespace UstabilKodeMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //public async Task<ActionResult> About()
        //{
        //    IQueryable<ProductGroup> data =
        //        from product in _context.Products
        //        group product by product.ProductName into productGroup
        //        select new ProductGroup()
        //        {
        //            ProductName = productGroup.Key,
        //            ProductCount = productGroup.Count()
        //        };
        //    return View(await data.AsNoTracking().ToListAsync());
        //}
    }
}
