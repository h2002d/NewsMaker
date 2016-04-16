using NewsMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsMakerAdmin.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost ]
        public JsonResult SavePost(Post newPost)
        {
            newPost.CreateDate = DateTime.Now;
            bool success=newPost.SavePost();
            return Json(new { success = success, responseText = "The attached file is not supported." }, JsonRequestBehavior.AllowGet);
        }

    }
}
