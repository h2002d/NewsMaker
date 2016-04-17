using NewsMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsMaker.Controllers
{
    public class PostController : ApiController
    {
        // GET api/post
        public List<Post> Get()
        {
            List<Post> postList = NewsMaker.Models.Post.GetPosts(null);
            return postList;
        }

        // GET api/post/5
        public List<Post> Get(int id)
        {
            List<Post> post = Post.GetPosts(id);
            return post;
        }

        //// POST api/post
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/post/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/post/5
        //public void Delete(int id)
        //{
        //}
    }
}
