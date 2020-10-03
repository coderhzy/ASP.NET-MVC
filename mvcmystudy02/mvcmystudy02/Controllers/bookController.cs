using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02.Controllers
{
    public class bookController : Controller
    {
        // 图书列表

        public ActionResult Index()
        {
            List<db.Books> list = db.bll.books.getBooks();
            return View(list);
        }

    }
}
