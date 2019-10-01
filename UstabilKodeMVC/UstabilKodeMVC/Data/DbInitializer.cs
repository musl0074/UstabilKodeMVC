using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UstabilKodeMVC.Models;

namespace UstabilKodeMVC.Data
{
    public class DbInitializer
    {
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
            new Product{ProductName="G-Pen",Details="This is a Pen",Price=500},
            new Product{ProductName="G-Pen",Details="This is a Pen",Price=500},
            new Product{ProductName="G-Pen",Details="This is a Pen",Price=500},
            new Product{ProductName="G-Pen",Details="This is a Pen",Price=500},
            new Product{ProductName="G-Pen",Details="This is a Pen",Price=500},
            new Product{ProductName="G-Pen",Details="This is a Pen",Price=500},
            new Product{ProductName="G-Pen",Details="This is a Pen",Price=500},
            };
            foreach (Product s in products)
            {
                context.Products.Add(s);
            }
            context.SaveChanges();

        }
    }
}

