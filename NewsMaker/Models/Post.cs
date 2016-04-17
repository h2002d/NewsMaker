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
        private int type;
        private string title;

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

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public static List<Post> GetPosts(int? id)
        {
            return PostDAO.getPosts(id);
        }
        public bool SavePost()
        {
            return PostDAO.savePost(this);
        }
    }
}