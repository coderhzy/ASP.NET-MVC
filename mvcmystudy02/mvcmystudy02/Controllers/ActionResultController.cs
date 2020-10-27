using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02.Controllers
{
    public class ActionResultController : Controller
    {
        //
        // GET: /ActionResult/

        public ActionResult Index()
        {
            //方式一： 通过网址跳转，缺点：路由固定
            // return new RedirectResult("/actionResult/BookList1");
            //方式二： 根据路由方式来跳转，兼容性好
            //return RedirectToAction("BookList1", "ActionResult");
            return View();
        }

        // 不允许单独运行
        //[ChildActionOnly]
        public PartialViewResult BookList1()
        {
            List<db.Books> list = db.bll.books.getBooks1();
            return PartialView(list);
        }

        //[ChildActionOnly]
        public PartialViewResult BookList2()
        {
           List<db.Books> list = db.bll.books.getBooks2();
           return PartialView(list);
        }

        public ContentResult css(string color)
        {
            if (color == "red")
            {
                return Content("body{color:red}", "text/css");
            }
            if (color == "blue")
            {
                return Content("body{color:blue}", "text/css");
            }
            return Content("body{color:black}", "text/css");
        }

        // 下载文件
        public FileResult downLoad()
        {
            return File(Server.MapPath("~/test.txt"), "text/plain", "我的文件.txt");
        }

        // JSON
        public JsonResult json1()
        {
            var person = new
            {
                Name = "小王",
                Age = 12,
                parent = new[]{
                    new {Name = "小王父亲",Age=40},
                    new {Name = "小王母亲",Age=41},
                }
            };

            return Json(person, JsonRequestBehavior.AllowGet);
        }

        public JsonResult json2()
        {
            List<db.Books> list = db.bll.books.getBooks();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        //
        public JavaScriptResult js()
        {
            return JavaScript("alert('1233oqiwje')");
        }
    }
}
