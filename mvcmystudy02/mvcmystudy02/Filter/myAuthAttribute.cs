using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02.Filter
{
    public class myAuthAttribute : FilterAttribute,IAuthorizationFilter
    {
        // 完成登录检测
        public void OnAuthorization(AuthorizationContext 
            ac)
        {
            // 设置全局过滤器以后选择性选择过滤

            // 方法一：获取Controller和action名称
            // TODO: 方法一代码断点没法正常获取
            
            //string controllerName = ac.Controller.ToString();
            //string actionName = ac.ActionDescriptor.ActionName;
            //if (controllerName == "mvcmystudy02.Controllers.loginController")
            //    return;

            
            // 方法二： 给不要登录的页面加上AllowAnonymous
            // 方法二第一步:获取action和controller是否有AllowAnonymousAttribute

            var actionAnony = ac.
                ActionDescriptor.
                GetCustomAttributes(
                typeof(AllowAnonymousAttribute), true)
                as IEnumerable<AllowAnonymousAttribute>;
            var controllerAnony = ac.Controller
                .GetType().GetCustomAttributes(
                typeof(AllowAnonymousAttribute), true)
                as IEnumerable<AllowAnonymousAttribute>;

            // 方法二第二步: 获取以后判断特性有效，谁有不过滤谁
            if ((actionAnony != null && actionAnony.Any()) ||
              (controllerAnony != null && controllerAnony.Any()))
                return;

            // 未登录
            if (ac.HttpContext.
                Session["isLogin"] == null)
            {
                // 获取请求的网址
                string url = ac.HttpContext
                    .Request.RawUrl;
                // 保存刚才获取的网址
                ac.HttpContext.Session["toUrl"] = url;
                // 跳转
                ac.Result = new RedirectResult("/login/index");
               
            }
        }
    }
}