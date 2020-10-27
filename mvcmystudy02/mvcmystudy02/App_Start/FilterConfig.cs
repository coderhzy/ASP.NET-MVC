using mvcmystudy02.Filter;
using System.Web;
using System.Web.Mvc;

namespace mvcmystudy02
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new myErrorAttribute());
            // 全局过滤器
            filters.Add(new myAuthAttribute());
            filters.Add(new myActionAttribute());
        }
    }
}