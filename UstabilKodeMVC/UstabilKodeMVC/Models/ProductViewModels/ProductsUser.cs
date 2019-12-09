using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UstabilKodeMVC.Models.ProductViewModels
{
    public class ProductsUser
    {
        public List<Product> Products { get; set; }
        public IdentityUser CurrentUser { get; set; }
    }
}
