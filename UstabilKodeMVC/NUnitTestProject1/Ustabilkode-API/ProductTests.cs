using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using UstabilKodeMVC.Models;
using UstabilKodeMVC.Services.UstabilkodeAPI;

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
            var products = ProductEndpoints.GetProducts().Result;

            Assert.IsTrue(products != null);
        }
        [Test]
        public void Get()
        {
            int validID = GetValidID();


            var product = ProductEndpoints.GetProduct(validID).Result;

            Assert.IsTrue(product != null);
        }
        [Test]
        public void Post()
        {
            Product product = new Product() { Name = "Test", Details = "Test", Price = 0 };

            var response = ProductEndpoints.CreateProduct(product.Name, product.Details, product.Price).Result;

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }
        [Test]
        public void Put()
        {
            int validID = GetValidID();


            var productFirstGet = ProductEndpoints.GetProduct(validID).Result;

            var response = ProductEndpoints.UpdateProduct(productFirstGet.ID, productFirstGet.Name, "test", productFirstGet.Price, productFirstGet.RowVersion).Result;

            var productSecondGet = ProductEndpoints.GetProduct(validID).Result;
            string secondGetDetails = productSecondGet.Details;

            var response2 = ProductEndpoints.UpdateProduct(productSecondGet.ID, productSecondGet.Name, "default", productSecondGet.Price, productSecondGet.RowVersion).Result;

            Assert.IsTrue(productSecondGet.Details == "test");
        }
        [Test]
        public void Delete()
        {
            int validID = GetValidID();

            var response = ProductEndpoints.DeleteProduct(validID).Result;

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
        [Test]
        public void Concurrency()
        {
            int validID = GetValidID();


            var productFirstGet = ProductEndpoints.GetProduct(validID).Result;

            var response1 = ProductEndpoints.UpdateProduct(productFirstGet.ID, productFirstGet.Name, productFirstGet.Details, 100, productFirstGet.RowVersion).Result;
            
            var response2 = ProductEndpoints.UpdateProduct(productFirstGet.ID, productFirstGet.Name, productFirstGet.Details, 200, productFirstGet.RowVersion).Result;

            // Set value with proper rowVersion, so its ready for another test
            var productSecondGet = ProductEndpoints.GetProduct(validID).Result;
            var response3 = ProductEndpoints.UpdateProduct(productSecondGet.ID, productSecondGet.Name, productSecondGet.Details, 200, productSecondGet.RowVersion).Result;


            Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.Conflict);
        }
        


        private int GetValidID()
        {
            int validID = 0;

            for (int i = 1; i < 100; i++)
            {
                Product product = ProductEndpoints.GetProduct(i).Result;

                if (product != null && product.ID != 0)
                {
                    validID = product.ID;
                    break;
                }
            }

            return validID;
        }
    }
}