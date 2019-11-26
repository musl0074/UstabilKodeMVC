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
    public static class PostEndpoints
    {
        public static async Task<List<Post>>GetPosts()
        {
            string getPostsUrl = APISettings.APIUrl + "/post";

            HttpResponseMessage response = await APISettings.Client.GetAsync(getPostsUrl);
            string json = await response.Content.ReadAsStringAsync();

            List<Post> posts = JsonConvert.DeserializeObject<List<Post>>(json);

            return posts;
        }

        public static async Task<Post>GetPost(int id)
        {
            string getPostUrl = APISettings.APIUrl + "/post/" + id;

            HttpResponseMessage response = await APISettings.Client.GetAsync(getPostUrl);
            string json = await response.Content.ReadAsStringAsync();

            Post post = JsonConvert.DeserializeObject<Post>(json);

            return post;
        }

        public static async Task<HttpResponseMessage> CreatePost(string title, string content)
        {
            string createPostUrl = APISettings.APIUrl + "/post";

            Post post = new Post()
            {
                Title = title,
                Content = content
            };

            string json = JsonConvert.SerializeObject(post);
            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await APISettings.Client.PostAsync(createPostUrl, body);

            return response;
        }

        public static async Task<HttpResponseMessage> UpdatePost(int id, string title, string content, List<Comment> comments, byte[] rowVersion)
        {
            string updatePostUrl = APISettings.APIUrl + "/post";

            Post post = new Post()
            {
                ID = id,
                Title = title,
                Content = content,
                Comments = comments,
                RowVersion = rowVersion
            };

            string json = JsonConvert.SerializeObject(post, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            StringContent body = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await APISettings.Client.PutAsync(updatePostUrl, body);

            return response;
        }

        public static async Task<HttpResponseMessage> DeletePost(int id)
        {
            string deletePostUrl = APISettings.APIUrl + "/post/" + id;

            HttpResponseMessage response = await APISettings.Client.DeleteAsync(deletePostUrl);

            return response;
        }
    }
}
