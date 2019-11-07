using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UstabilKodeMVC.Models;
using UstabilKodeMVC.Services.UstabilkodeAPI;

namespace NUnitTestProject1.Ustabilkode_API
{
    public class PostTests : IUnitTestAPI
    {
        [Test]
        public void Concurrency()
        {
            int validID = GetValidID();

            Post post = PostEndpoints.GetPost(validID).Result;

            var response = PostEndpoints.UpdatePost(post.ID, "Updated1", post.Content, post.Comments, post.RowVersion).Result;
            var response2 = PostEndpoints.UpdatePost(post.ID, "Updated2", post.Content, post.Comments, post.RowVersion).Result;

            // Reset update, to be ready for next test run
            var postUpdated = PostEndpoints.GetPost(validID).Result;
            var response3 = PostEndpoints.UpdatePost(postUpdated.ID, "Reset", postUpdated.Content, postUpdated.Comments, postUpdated.RowVersion).Result;


            Assert.IsTrue(response2.StatusCode == System.Net.HttpStatusCode.Conflict);
        }

        [Test]
        public void Delete()
        {
            int validID = GetValidID();


            var response = PostEndpoints.DeletePost(validID).Result;


            Assert.IsTrue(response.StatusCode != System.Net.HttpStatusCode.NotFound);
        }

        [Test]
        public void Get()
        {
            int validID = GetValidID();

            var post = PostEndpoints.GetPost(validID).Result;

            Assert.IsTrue(post != null);
        }

        [Test]
        public void GetAll()
        {
            var posts = PostEndpoints.GetPosts().Result;

            Assert.IsTrue(posts.Count != 0);
        }

        [Test]
        public void Post()
        {
            var response = PostEndpoints.CreatePost("UnitTest", "UnitTest").Result;

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [Test]
        public void Put()
        {
            int validID = GetValidID();

            var postToUpdate = PostEndpoints.GetPost(validID).Result;

            postToUpdate.Title = "Put";

            var response = PostEndpoints.UpdatePost(postToUpdate.ID, postToUpdate.Title, postToUpdate.Content, postToUpdate.Comments, postToUpdate.RowVersion);
            
            var updatedPost = PostEndpoints.GetPost(validID).Result;

            // Reset updated value
            var response2 = PostEndpoints.UpdatePost(updatedPost.ID, "Reset", updatedPost.Content, updatedPost.Comments, updatedPost.RowVersion);



            Assert.IsTrue(updatedPost.Title == "Put");
        }


        private int GetValidID()
        {
            int validID = 0;

            for (int i = 1; i < 100; i++)
            {
                Post post = PostEndpoints.GetPost(i).Result;

                if (post != null && post.ID != 0)
                {
                    validID = post.ID;
                    break;
                }
            }

            return validID;
        }
    }
}
