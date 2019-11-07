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
        private const string apiurl = "https://ustabilkode-api.azurewebsites.net/api";
        private static HttpClient client = new HttpClient();

        public async static Task<List<Product>> GetProducts()
        {
            string getProductsUrl = apiurl + "/Product";

            
            HttpResponseMessage response =await client.GetAsync(getProductsUrl);
            string productsString=await response.Content.ReadAsStringAsync();


            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsString);

            return products;
        }

        public async static Task<Product> GetProduct(int id)
        {
            string getProductUrl = apiurl + "/Product/" + id;

            
            string productString = await client.GetStringAsync(getProductUrl);

            Product product = JsonConvert.DeserializeObject<Product>(productString);

            return product;
        }

        public async static Task<HttpResponseMessage> CreateProduct(string name, string details, double price)
        {
            string postCreateProductUrl = apiurl + "/Product";
            

            Product product = new Product()
            {
                Name = name,
                Details = details,
                Price = price
            };
            string json = JsonConvert.SerializeObject(product);
            StringContent message = new StringContent(json, Encoding.UTF8, "application/json");


           return await client.PostAsync(postCreateProductUrl,message);

        }

        public async static Task<HttpResponseMessage> UpdateProduct(int id,string name,string details,double price, byte[] rowVersion)
        {
            string postUpdateProductUrl = apiurl + "/Product/Edit";

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

            return await client.PutAsync(postUpdateProductUrl, message);
        }

        public async static Task<HttpResponseMessage> DeleteProduct(int id)
        {
            string deleteProductURL = apiurl + "/Product/" + id;

            Product product = new Product
            {
                ID = id
            };

            string json = JsonConvert.SerializeObject(product);
            StringContent message = new StringContent(json, Encoding.UTF8, "application/json");

            return await client.DeleteAsync(deleteProductURL);
        }
    }
}
