using NewsMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsMaker.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }
        #region Post
        [HttpPost]
        public JsonResult SavePost(Post newPost)
        {
            newPost.CreateDate = DateTime.Now;
            bool success = newPost.SavePost();
            return Json(new { success = success, responseText = "Your Post Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddPost()
        {
            var typeList = NewsMaker.Models.Type.GetType(null);
            var typeSelect = typeList.ToList().Select(t => new SelectListItem
            {
                Text = t.TypeName,
                Value = t.TypeId.ToString()
            }).ToList();
            ViewBag.Types = typeSelect;
            return View();
        }
        #endregion

        #region Types
        public ActionResult Types()
        {
            var typeList = NewsMaker.Models.Type.GetType(null);
            var typeSelect = typeList.ToList().Select(t => new SelectListItem
            {
                Text = t.TypeName,
                Value = t.TypeId.ToString()
            }).ToList();
            ViewBag.Types = typeSelect;
            return View();
        }
        [HttpGet]
        public ActionResult TypePartial(int id)
        {
            var typeList = NewsMaker.Models.Type.GetType(id);
            return PartialView(typeList);
        }

        [HttpPost]
        public JsonResult SaveType(NewsMaker.Models.Type newType)
        {
            bool success = newType.SaveType();
            return Json(new { success = success, responseText = "Your Type Saved Successfully" }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}
