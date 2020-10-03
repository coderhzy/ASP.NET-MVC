using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02.Controllers
{
    public class storeController : Controller
    {
        // 图书列表
        public ActionResult bookList()
        {
           List<db.Books> list =  db.bll.books.getBooks();
            return View(list);
        }

        // 购书
        [HttpGet]
        public ActionResult order(int id)
        {
            db.Books entry = db.bll.books.getEntry(id);
            return View(entry);
        }

        //下单
        [HttpPost]
        public ActionResult order(int BookId, int? Num, string Address)
        {
            //数据新增的代码
            db.bll.orders.insert(BookId, Num, Address);
            return RedirectToAction("orderList");
        }

        // 订单列表

        public ActionResult orderList()
        {
            List<db.sv_Orders> list = db.bll.orders.getOrders();
            return View(list);
        }

    }
}
