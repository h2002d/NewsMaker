using NewsMaker.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsMaker.Models
{
    public class Post
    {
        private int id;
        private string content;
        private DateTime createDate;
        private int userId;


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        public DateTime CreateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public static List<Post> GetPosts(int? id)
        {
            return PostDAO.getPosts(id);
        }


    }
}