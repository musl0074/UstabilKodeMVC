using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UstabilKodeMVC.Models;

namespace UstabilKodeMVC.Services.UstabilkodeAPI
{
    public static class CommentEndpoints
    {
        public static async Task<Comment> GetComment(int id)
        {
            string getUrl = APISettings.APIUrl + "/Comment/" + id;

            var response = await APISettings.Client.GetAsync(getUrl);
            var json = await response.Content.ReadAsStringAsync();

            var comment = JsonConvert.DeserializeObject<Comment>(json);

            return comment;
        }

        public static async Task<List<Comment>> GetComments()
        {
            string getUrl = APISettings.APIUrl + "/Comment";

            var response = await APISettings.Client.GetAsync(getUrl);
            var json = await response.Content.ReadAsStringAsync();

            var comments = JsonConvert.DeserializeObject<List<Comment>>(json);

            return comments;
        }

        public static async Task<HttpResponseMessage> CreateComment(int id, string userId, string content)
        {
            string createUrl = APISettings.APIUrl + "/Comment/" + id;
            
            Comment comment = new Comment() { UserID = userId, Content = content };
            var json = JsonConvert.SerializeObject(comment);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await APISettings.Client.PostAsync(createUrl, body);

            return response;
        }

        public static async Task<HttpResponseMessage> UpdateComment(Comment comment)
        {
            string updateUrl = APISettings.APIUrl + "/Comment";

            var json = JsonConvert.SerializeObject(comment);
            var body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await APISettings.Client.PutAsync(updateUrl, body);

            return response;
        }

        public static async Task<HttpResponseMessage> DeleteComment(int id)
        {
            string deleteUrl = APISettings.APIUrl + "/Comment/" + id;

            var response = await APISettings.Client.DeleteAsync(deleteUrl);

            return response;
        }
    }
}
