using mvcmystudy02.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02.Controllers
{

    [myAuth]
    public class bookController : Controller
    {
        // 展示图书列表
        [OutputCache(CacheProfile = "sqlCache")]
        public ActionResult Index()
        {
            List<db.Books> list = db.bll.books.getBooks();
            return View(list);
        }

        // 新增方法一
        [HttpGet]
        public ActionResult insertOne()
        {
            db.Books entry = new db.Books();
            return View(entry);
        }

        [HttpPost]
        public ActionResult insertOne(string AuthorName, string Title, Nullable<decimal> Price)
        {
            db.bll.books.insertOne(AuthorName, Title, Price);

            // 新增完成重定向回主页
            return RedirectToAction("Index");
        }



        // 新增方法二
        [HttpGet]
        public ActionResult insertTwo()
        {
            db.Books entry = new db.Books();
            return View(entry);
        }

        [HttpPost]
        // 前端传过来的值，会匹配属性值，匹配到传入进去(参数绑定)
        // action自带参数，和request来匹配属性
        public ActionResult insertTwo(db.Books entry)
        {
            db.bll.books.insertTwo(entry);

            // 新增完成重定向回主页
            return RedirectToAction("Index");
        }


        // 图书修改
        // 图书修改第一种方式
        [HttpGet]
        public ActionResult updateOne(int id)
        {
            db.Books entry = db.bll.books.getEntry(id);
            return View(entry);
        }

        [HttpPost]
        public ActionResult updateOne(string AuthorName, string Title, Nullable<decimal> Price, int BookId)
        {
            db.bll.books.updateOne( AuthorName, Title, Price,BookId);
            
            // 新增完成重定向回主页
            return RedirectToAction("Index");
        }


        // 图书修改第二种方式
        [HttpGet]
        public ActionResult updateTwo(int id)
        {
            db.Books entry = db.bll.books.getEntry(id);
            return View(entry);
        }

        [HttpPost]
        public ActionResult updateTwo(db.Books entry)
        {
            db.bll.books.updateTwo(entry);

            // 新增完成重定向回主页
            return RedirectToAction("Index");
        }

        // 图书修改第三种方式
        [HttpGet]
        public ActionResult updateThree(int id)
        {
            db.Books entry = db.bll.books.getEntry(id);
            return View(entry);
        }

        [HttpPost]
        public ActionResult updateThree(db.Books entry)
        {
            db.bll.books.updateThree(entry);

            // 新增完成重定向回主页
            return RedirectToAction("Index");
        }

        // 删除方法
        public ActionResult delete(int id)
        {
            db.bll.books.delete(id);
            return RedirectToAction("Index");
        }

        // 具体信息在web.config文件内
        [OutputCache(CacheProfile = "myCache")]
        public ActionResult Details(int id)
        {
            db.Books entry = db.bll.books.getEntry(id);
            return View(entry);
        }
    }
}
