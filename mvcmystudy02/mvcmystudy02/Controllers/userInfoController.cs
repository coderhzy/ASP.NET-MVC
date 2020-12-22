using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02.Controllers
{
    public class userInfoController : Controller
    {
        //
        // GET: /userInfo/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(db.userinfo userInfo)
        {
            if (ModelState.IsValid)
            {
                @TempData["username"] = userInfo.userName;
                @TempData["age"] = userInfo.age;
                @TempData["email"] = userInfo.email;
                @TempData["id"] = userInfo.identId;
                @TempData["tel"] = userInfo.tel;
                return RedirectToAction("showInfo");
            }
            return View();
        }

        public ActionResult showInfo()
        {
            return View();
        }

    }
}
