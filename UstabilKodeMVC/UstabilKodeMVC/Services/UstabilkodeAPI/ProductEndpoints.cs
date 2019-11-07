using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using UstabilKodeMVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace UstabilKodeMVC.Services.UstabilkodeAPI
{
    public static class ProductEndpoints
    {
        public async static Task<List<Product>> GetProducts()
        {
            string getProductsUrl = APISettings.APIUrl + "/Product";

            
            HttpResponseMessage response = await APISettings.Client.GetAsync(getProductsUrl);
            string productsString = await response.Content.ReadAsStringAsync();


            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsString);

            return products;
        }

        public async static Task<Product> GetProduct(int id)
        {
            string getProductUrl = APISettings.APIUrl + "/Product/" + id;

            HttpResponseMessage response = await APISettings.Client.GetAsync(getProductUrl);
            string productString = await response.Content.ReadAsStringAsync();

            Product product = JsonConvert.DeserializeObject<Product>(productString);

            return product;
        }

        public async static Task<HttpResponseMessage> CreateProduct(string name, string details, double price)
        {
            string postCreateProductUrl = APISettings.APIUrl + "/Product";
            
            Product product = new Product()
            {
                Name = name,
                Details = details,
                Price = price
            };

            string json = JsonConvert.SerializeObject(product);
            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await APISettings.Client.PostAsync(postCreateProductUrl, body);

            return response;
        }

        public async static Task<HttpResponseMessage> UpdateProduct(int id,string name,string details,double price, byte[] rowVersion)
        {
            string postUpdateProductUrl = APISettings.APIUrl + "/Product/Edit";

            Product product = new Product()
            {
                ID = id,
                Name = name,
                Details = details,
                Price = price,
                RowVersion = rowVersion
            };

            string json = JsonConvert.SerializeObject(product);
            StringContent message = new StringContent(json, Encoding.UTF8, "application/json");

            return await APISettings.Client.PutAsync(postUpdateProductUrl, message);
        }

        public async static Task<HttpResponseMessage> DeleteProduct(int id)
        {
            string deleteProductURL = APISettings.APIUrl + "/Product/" + id;

            HttpResponseMessage response = await APISettings.Client.DeleteAsync(deleteProductURL);

            return response;
        }
    }
}
