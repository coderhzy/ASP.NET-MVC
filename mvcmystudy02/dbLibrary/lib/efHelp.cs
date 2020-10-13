using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.lib
{
    class efHelp
    {
        public static void entryUpdate(object entry,dbEntities dc)
        {
            dc.Entry(entry).State
                = System.Data.EntityState.Unchanged;

            // 取当前请求的上下文,表的中元素
            List<string> list = System.Web.HttpContext.Current
                .Request.Form.AllKeys.ToList<string>();

            // 遍历读出 Books.cs中的类型
            foreach (var p in entry.GetType().GetProperties())
            {
                if (list.Contains(p.Name))
                    dc.Entry(entry).Property(p.Name).IsModified = true;
            }
        }
    }
}
