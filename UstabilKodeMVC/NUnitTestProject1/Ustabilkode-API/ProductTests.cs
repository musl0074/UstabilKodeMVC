using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UstabilKodeMVC.Models;
using UstabilKodeMVC.Services;

namespace NUnitTestProject1.Ustabilkode_API
{
    [TestFixture]
    public class ProductTests : IUnitTestAPI
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAll()
        {
            var products = UstabilkodeAPI.GetProducts().Result;

            Assert.IsTrue(products != null);
        }
        [Test]
        public void Get()
        {
            var product = UstabilkodeAPI.GetProduct(1).Result;

            Assert.IsTrue(product != null);
        }
        [Test]
        public void Post()
        {
            Product product = new Product() { ProductName = "Test", Details = "Test", Price = 0 };

            var response = UstabilkodeAPI.CreateProduct(product.ProductName, product.Details, product.Price).Result;

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }
        [Test]
        public void Put()
        {
            var productFirstGet = UstabilkodeAPI.GetProduct(1).Result;

            var response = UstabilkodeAPI.UpdateProduct(productFirstGet.ID, productFirstGet.ProductName, "test", productFirstGet.Price, productFirstGet.RowVersion).Result;

            var productSecondGet = UstabilkodeAPI.GetProduct(1).Result;
            string secondGetDetails = productSecondGet.Details;

            var response2 = UstabilkodeAPI.UpdateProduct(productSecondGet.ID, productSecondGet.ProductName, "default", productSecondGet.Price, productSecondGet.RowVersion).Result;

            Assert.IsTrue(secondGetDetails == "test");
        }
        [Test]
        public void Delete()
        {
            var response = UstabilkodeAPI.DeleteProduct(14).Result;

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
        [Test]
        public void Concurrency()
        {
            var productFirstGet = UstabilkodeAPI.GetProduct(1).Result;

            var response1 = UstabilkodeAPI.UpdateProduct(productFirstGet.ID, productFirstGet.ProductName, productFirstGet.Details, 100, productFirstGet.RowVersion).Result;
            
            var response2 = UstabilkodeAPI.UpdateProduct(productFirstGet.ID, productFirstGet.ProductName, productFirstGet.Details, 200, productFirstGet.RowVersion).Result;

            // Set value with proper rowVersion, so its ready for another test
            var productSecondGet = UstabilkodeAPI.GetProduct(1).Result;
            var response3 = UstabilkodeAPI.UpdateProduct(productSecondGet.ID, productSecondGet.ProductName, productSecondGet.Details, 200, productSecondGet.RowVersion).Result;


            Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.Conflict);
        }
        
    }
}