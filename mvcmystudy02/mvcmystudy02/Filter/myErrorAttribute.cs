using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02.Filter
{
    public class myErrorAttribute: FilterAttribute,IExceptionFilter
    {

        public void OnException(ExceptionContext fc)
        {
            // 获取信息
            string msg = "";
            if (fc.Exception != null)
            {
                msg += fc.Exception.Message;
            }
            if (fc.Exception.InnerException != null)
            {
                msg += fc.Exception.InnerException.Message;
            }
            // 保存获取的信息 
            fc.HttpContext.Session["errorMsg"] = msg;
            // 代表异常被处理
            fc.ExceptionHandled = true;
            // 跳出转到错误展示界面
            fc.Result = new RedirectResult("/login/error");
        }
    }
}