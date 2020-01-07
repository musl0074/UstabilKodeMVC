//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Net.Http;
//using System.IO;
//using UstabilKodeMVC.Models;
//using Newtonsoft.Json;
//using System.Text;

//namespace UstabilKodeMVC.Services.UstabilkodeAPI
//{
//    public class SubscriptionEndpoints
//    {
//        public async static Task<List<Subscription>> GetSubscriptions(string userId)
//        {
//            string getUrl = APISettings.APIUrl + "/Subscription/" + userId;


//            HttpResponseMessage response = await APISettings.Client.GetAsync(getUrl);
//            string subscriptionsString = await response.Content.ReadAsStringAsync();


//            List<Subscription> subscriptions = JsonConvert.DeserializeObject<List<Subscription>>(subscriptionsString);

//            return subscriptions;
//        }

//        public async static Task<Subscription> GetSubscription(int id)
//        {
//            string getUrl = APISettings.APIUrl + "/Subscription/" + id;

//            HttpResponseMessage response = await APISettings.Client.GetAsync(getUrl);
//            string subscriptionString = await response.Content.ReadAsStringAsync();

//            Subscription subscription = JsonConvert.DeserializeObject<Subscription>(subscriptionString);

//            return subscription;
//        }

//        public async static Task<HttpResponseMessage> CreateSubscription(int productId, string userId, DateTime expirationDate)
//        {
//            string postUrl = APISettings.APIUrl + "/Subscription";

//            Subscription subscription = new Subscription()
//            {
//                UserID = userId,
//                ProductID = productId,
//                ExpirationDate = expirationDate
//            };

//            string json = JsonConvert.SerializeObject(subscription);
//            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

//            var response = await APISettings.Client.PostAsync(postUrl, body);

//            return response;
//        }

//        public async static Task<HttpResponseMessage> RenewSubscription(Subscription subscription)
//        {
//            string postUrl = APISettings.APIUrl + "/Subscription/Renew";

//            string json = JsonConvert.SerializeObject(subscription);
//            StringContent message = new StringContent(json, Encoding.UTF8, "application/json");

//            return await APISettings.Client.PutAsync(postUrl, message);
//        }

//        public async static Task<HttpResponseMessage> DeleteSubscription(int id)
//        {
//            string deleteURL = APISettings.APIUrl + "/Subscription/" + id;

//            HttpResponseMessage response = await APISettings.Client.DeleteAsync(deleteURL);

//            return response;
//        }
//    }
//}
