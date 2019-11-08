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
            throw new NotImplementedException();
        }

        [Test]
        public void Get()
        {
            throw new NotImplementedException();
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
            int postId = GetValidPostID();
            Post post = PostEndpoints.GetPost(postId).Result;
            Comment comment = new Comment() { Content = "Test", Post = post };
            post.Comments.Add(comment);

            var responseUpdatePost = PostEndpoints.UpdatePost(post.ID, post.Title, post.Content, post.Comments, post.RowVersion).Result;

            var responseCreateComment = CommentEndpoints.CreateComment(comment.Content, comment.Post).Result;

            Assert.IsTrue(responseCreateComment.StatusCode == System.Net.HttpStatusCode.Created);
        }

        [Test]
        public void Put()
        {
            throw new NotImplementedException();
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
