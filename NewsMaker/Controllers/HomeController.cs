using NewsMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsMaker.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Post> postsList = Post.GetPosts(2);
            return View(postsList);
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
