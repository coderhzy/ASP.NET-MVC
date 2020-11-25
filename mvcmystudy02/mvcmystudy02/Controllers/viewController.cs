using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02.Controllers
{
    public class viewController : Controller
    {
        //
        // GET: /view/

        public ActionResult Index()
        {
            return View();
        }

        // 数据提交
        [HttpPost]
        public ActionResult submit(string userName,
            string intro,
            string password,
            string sex,
            string city,
            string[] love)
        {
            // 传递到show的参数并展示 
            TempData["userName"] = userName;
            TempData["intro"] = intro;
            TempData["password"] = password;
            TempData["sex"] = sex;
            TempData["city"] = city;
            string love1 = Request["love"].ToString();

            // 保存上传文件
            if(Request.Files.Count == 0){
                ViewData["msg"] = "文件无效";
                return RedirectToAction("show");
            }
            var file = Request.Files[0];
            string savePath = Server.MapPath("~/upload/");
            string fileName = DateTime.Now.ToString("yyyyMMddhhssmm") 
                + file.FileName;
            file.SaveAs(savePath + fileName);
            TempData["img"] = "/upload/" + fileName;


            // 跳转到show视图
            return RedirectToAction("show");
        }

        // 数据展示界面
        public ActionResult show()
        {
            return View();
        }

        // 列表
        [HttpGet]
        public ActionResult bookIndex()
        {
            List<db.Books> list = db.bll.books.getBooks();
            return View(list);
        }

        [HttpPost]
        public ActionResult bookIndex(string val, string oldtype)
        {
            string rowID = Request["detail.rowID"].ToString();
            string price = Request["detail.Price"].ToString();
            string booktype = Request["detail.booktype"].ToString();
            List<string> rowIDList = rowID.Split(',').ToList<string>();
            List<string> priceList = price.Split(',').ToList<string>();
            List<string> booktypeList = booktype.Split(',').ToList<string>();
            Dictionary<string, string> dicBookTag = new Dictionary<string, string>();
            foreach (var item in rowIDList)
            {
                string bookTag = Request["detail.BookTag." + item].ToString();
                dicBookTag.Add(item, bookTag);
            }
            db.bll.books.batchUpdatePrice(rowIDList, priceList, booktypeList, dicBookTag);
            return RedirectToAction("bookindex");
        }
        // 详情
        public ActionResult bookDetail(int id)
        {
            db.Books entry = db.bll.books.getEntry(id);
            return View(entry);
        }

        // 新增
        [HttpGet]
        public ActionResult bookInsert()
        {
            db.Books entry = new db.Books();
            return View(entry);
        }

        [HttpPost]
        public ActionResult bookInsert(db.Books entry)
        {
            if (Request["bookTag"] != null)
            {
                entry.BookTag = Request["bookTag"].ToString();
                if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
                {
                    // 上传以后将文件存起来
                    string savePath = "/upload/" + DateTime.Now.ToString("yyyyMMddhhmmss")
                        + Request.Files[0].FileName;
                    Request.Files[0].SaveAs(Server.MapPath(savePath));
                    entry.BookCoverUrl = savePath;
                }
            }

            db.bll.books.insertTwo(entry);
            return RedirectToAction("bookIndex");
        }

        // 修改
        [HttpGet]
        public ActionResult bookUpdate(int id)
        {
            db.Books entry = db.bll.books.getEntry(id);
            return View(entry);
        }

        [HttpPost]
        public ActionResult bookUpdate(db.Books entry)
        {
            if (Request["bookTag"] != null)
            {
                entry.BookTag = Request["bookTag"].ToString();
                if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
                {
                    // 上传以后将文件存起来
                    string savePath = "/upload/" + DateTime.Now.ToString("yyyyMMddhhmmss")
                        + Request.Files[0].FileName;
                    Request.Files[0].SaveAs(Server.MapPath(savePath));
                    entry.BookCoverUrl = savePath;
                }
            }

            db.bll.books.updateThree(entry);
            return RedirectToAction("bookIndex");
        }
    }
}
