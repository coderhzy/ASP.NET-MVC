using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcmystudy02.Models;

namespace mvcmystudy02.Controllers
{
    public class storeController : Controller
    {
        // 图书列表
        public ActionResult bookList()
        {
            dbEntities dc = new dbEntities();
            List<Books> list = (from a in dc.Books select a).ToList<Books>();

            return View(list);
        }

        // 购书
        [HttpGet]
        public ActionResult order(int id)
        {
            dbEntities dc = new dbEntities();
            Books entry = dc.Books.Single(a => a.BookId == id);
            return View(entry);
        }

        //下单
        [HttpPost]
        public ActionResult order(int BookId, int? Num, string Address)
        {
            //数据新增的代码
            dbEntities dc = new dbEntities();
            Orders entry = new Orders();
            entry.BookId = BookId;
            entry.Num = Num;
            entry.Address = Address;
            dc.Orders.Add(entry);
            dc.SaveChanges();
            return RedirectToAction("orderList");
        }

        // 订单列表

        public ActionResult orderList()
        {
            dbEntities dc = new dbEntities();
            List<sv_Orders> list = (from a in dc.sv_Orders select a).ToList<sv_Orders>();

            return View(list);
        }

    }
}
