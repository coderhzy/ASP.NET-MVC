using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02.Controllers
{
    [AllowAnonymous]
    public class loginController : Controller
    {
        // 登录界面
        [HttpGet]
        public ActionResult Index()
        {
            // 异常处理过滤器返回友好界面给客户
            //int a = 2, b = 0, c;
            //c = a / b;

            return View();
        }


        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            if (userName == "admin" && password == "123456")
            {
                // 创建登录标识
                Session["isLogin"] = true;
                // 判断来源
                if (Session["toUrl"] != null)
                {
                    return new RedirectResult(Session["toUrl"].ToString());
                }
                return new RedirectResult("/store/bookList");
            }
            ViewData["msg"] = "账号或密码不正确";
            return View();
        }
        public ActionResult error()
        {
            return View();
        }
    }
}
