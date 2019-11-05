using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using UstabilKodeMVC.Models;
using Newtonsoft.Json;

namespace UstabilKodeMVC.Services
{
    public static class UstabilkodeAPI
    {
        private const string apiurl = "https://ustabilkode-api.azurewebsites.net/api";
        private static HttpClient client = new HttpClient();

        #region Products
        public async static Task<List<Product>> GetProducts()
        {
            string getProductsUrl = "https://ustabilkode-api.azurewebsites.net/api/Product";

            //  var request = (HttpWebRequest)WebRequest.Create(getProductsUrl);
            //var response = (HttpWebResponse)request.GetResponse();
            HttpResponseMessage response =await client.GetAsync(getProductsUrl);
            string productsString=await response.Content.ReadAsStringAsync();

           // string productsString = new StreamReader(response.Content).ReadToEnd();

            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsString);

            return products;
        }

        public async static Task<Product> GetProduct(int id)
        {
            string getProductUrl = "https://ustabilkode-api.azurewebsites.net/api/Product/" + id;

            //  var request = (HttpWebRequest)WebRequest.Create(getProductUrl);
            //var response = (HttpWebResponse)request.GetResponse();
            string productString = await client.GetStringAsync(getProductUrl);
           // string productString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            Product product = JsonConvert.DeserializeObject<Product>(productString);

            return product;
        }

        public async static Task<HttpResponseMessage> CreateProduct(string name, string details, double price)
        {
            string postCreateProductUrl = "https://ustabilkode-api.azurewebsites.net/api/product";
            

            Product product = new Product()
            {
                ProductName = name,
                Details = details,
                Price = price
            };
            string json = JsonConvert.SerializeObject(product);
            StringContent message = new StringContent(json);

            //   var request = (HttpWebRequest)WebRequest.Create(postCreateProductUrl);

           return await client.PostAsync(postCreateProductUrl,message);

        }

        public async static Task<HttpResponseMessage> UpdateProduct(int id,string name,string details,double price)
        {
            string postUpdateProductUrl = "https://ustabilkode-api.azurewebsites.net/api/product/" + id;

            Product product = new Product()
            {
                ID = id,
                ProductName = name,
                Details = details,
                Price = price
            };

            string json = JsonConvert.SerializeObject(product);
            StringContent message = new StringContent(json);

            return await client.PutAsync(postUpdateProductUrl, message);
        }

        public async static Task<HttpResponseMessage> DeleteProduct(int id)
        {
            string deleteProductURL = "https://ustabilkode-api.azurewebsites.net/api/product/" + id;

            Product product = new Product
            {
                ID = id
            };

            string json = JsonConvert.SerializeObject(product);
            StringContent message = new StringContent(json);

            return await client.DeleteAsync(deleteProductURL);
        }
        #endregion

        #region Posts
        public static void GetPosts()
        {

        }

        public static void GetPost(int id)
        {

        }

        public static void CreatePost()
        {

        }

        public static void UpdatePost()
        {

        }

        public static void DeletePost()
        {

        }
        #endregion

        #region Comments
        public static void GetComments()
        {

        }

        public static void GetComment(int id)
        {

        }

        public static void CreateComment()
        {

        }

        public static void UpdateComment()
        {

        }

        public static void DeleteComment()
        {

        }
        #endregion
    }
}
