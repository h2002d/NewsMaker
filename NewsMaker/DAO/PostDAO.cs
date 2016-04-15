using NewsMaker.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NewsMaker.DAO
{
    public class PostDAO
    {
        private static SqlConnection sqlConnection = null;

        public static List<Post> getPosts(int? id)
        {
            List<Post> postList = new List<Post>();
            Post post = new Post();
            post.Id = 1;
            post.Content = @"<img src='https://pbs.twimg.com/profile_images/473506797462896640/_M0JJ0v8.png' alt='Smiley face' height='42' width='42'>";
            post.CreateDate = DateTime.Now;
            post.UserId = 35;
            postList.Add(post);
            return postList;
        }
        
    }
}