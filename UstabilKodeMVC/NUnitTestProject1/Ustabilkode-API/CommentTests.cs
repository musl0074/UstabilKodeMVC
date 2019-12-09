using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UstabilKodeMVC.Models;
using UstabilKodeMVC.Services.UstabilkodeAPI;

namespace NUnitTestProject1.Ustabilkode_API
{
    public class CommentTests : IUnitTestAPI
    {
        [Test]
        public void Concurrency()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void Delete()
        {
            Comment comment = GetValidComment();

            var response = CommentEndpoints.DeleteComment(comment.ID).Result;

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public void Get()
        {
            Comment comment = GetValidComment();

            Assert.IsTrue(comment != null);
        }

        [Test]
        public void GetAll()
        {
            var comments = CommentEndpoints.GetComments().Result;

            Assert.IsTrue(comments.Count != 0);
        }

        [Test]
        public void Post()
        {
            //int postId = GetValidPostID();

            //Comment comment = new Comment() { Content = "Test" };

            //var response = CommentEndpoints.CreateComment(postId, comment.Content).Result;


            //Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [Test]
        public void Put()
        {
            throw new NotImplementedException();
        }



        private Comment GetValidComment()
        {
            for (int i = 1; i < 100; i++)
            {
                Comment comment = CommentEndpoints.GetComment(i).Result;

                if(comment != null && comment.ID != 0)
                {
                    return comment;
                }
            }

            return null;
        }

        private int GetValidPostID()
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
