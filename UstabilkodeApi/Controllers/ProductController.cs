using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UstabilkodeApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UstabilkodeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private UstabilkodeContext _context;

        public ProductController(UstabilkodeContext context)
        {
            _context = context;
        }


        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products
               //Include(i => i.Administrator)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ID == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST: api/product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.ID }, product);
        }

        // PUT: api/Product/5
        //[HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult<Product>> PutProduct(int? id, Product product, byte[] rowVersion)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    //(i => i.Administrator).

        //    var productToUpdate = await _context.Products.FirstOrDefaultAsync(m => m.ID == id);

        //    if (productToUpdate == null)
        //    {
        //        Product deletedProduct = new Product();
        //        await TryUpdateModelAsync(deletedProduct);
        //        ModelState.AddModelError(string.Empty,
        //            "Unable to save changes. The product was deleted by another user.");
        //        //ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", deletedDepartment.InstructorID);
        //        return View(deletedProduct);
        //    }

        //    _context.Entry(productToUpdate).Property("RowVersion").OriginalValue = rowVersion;

        //    if (await TryUpdateModelAsync<Product>(
        //        productToUpdate,
        //        "",
        //        s => s.Name, s => s.Details, s => s.Price))
        //    {
        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(GetProducts));
        //        }
        //        catch (DbUpdateConcurrencyException ex)
        //        {
        //            var exceptionEntry = ex.Entries.Single();
        //            var clientValues = (Product)exceptionEntry.Entity;
        //            var databaseEntry = exceptionEntry.GetDatabaseValues();
        //            if (databaseEntry == null)
        //            {
        //                ModelState.AddModelError(string.Empty,
        //                    "Unable to save changes. The department was deleted by another user.");
        //            }
        //            else
        //            {
        //                var databaseValues = (Product)databaseEntry.ToObject();

        //                if (databaseValues.Name != clientValues.Name)
        //                {
        //                    ModelState.AddModelError("Name", $"Current value: {databaseValues.Name}");
        //                }
        //                if (databaseValues.Details != clientValues.Details)
        //                {
        //                    ModelState.AddModelError("Budget", $"Current value: {databaseValues.Details:c}");
        //                }
        //                if (databaseValues.Price != clientValues.Price)
        //                {
        //                    ModelState.AddModelError("StartDate", $"Current value: {databaseValues.Price:d}");
        //                }

        //                ModelState.AddModelError(string.Empty, "The record you attempted to edit "
        //                        + "was modified by another user after you got the original value. The "
        //                        + "edit operation was canceled and the current values in the database "
        //                        + "have been displayed. If you still want to edit this record, click "
        //                        + "the Save button again. Otherwise click the Back to List hyperlink.");
        //                productToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
        //                ModelState.Remove("RowVersion");
        //            }
        //        }
        //    }
        //    //ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", departmentToUpdate.InstructorID);
        //    return View(productToUpdate);
        //    //if (id != product.ID)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    //_context.Entry(product).State = EntityState.Modified;
        //    //await _context.SaveChangesAsync();

        //    //return NoContent();
        //}

        // DELETE: api/Product/5

        
        [HttpPut("Edit")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            Product productToUpdate = await _context.Products.FindAsync(product.ID);
            ModelState.IsValid.ToString();

            if (productToUpdate == null)
                return NotFound(); 

            productToUpdate.Name = product.Name;
            productToUpdate.Details = product.Details;
            productToUpdate.Price = product.Price;

            _context.Entry(productToUpdate).Property("RowVersion").OriginalValue = product.RowVersion;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(DbUpdateConcurrencyException e) { return Conflict(); }
        }
        
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}