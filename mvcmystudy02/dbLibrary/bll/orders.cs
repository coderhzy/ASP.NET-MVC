using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.bll
{
    public class orders
    {
        public static void insert(int BookId, int? Num, string Address)
        {
            //数据新增的代码
            dbEntities dc = new dbEntities();
            Orders entry = new Orders();
            entry.BookId = BookId;
            entry.Num = Num;
            entry.Address = Address;
            dc.Orders.Add(entry);
            dc.SaveChanges();
        }

        public static List<db.sv_Orders> getOrders()
        {
            dbEntities dc = new dbEntities();
            List<sv_Orders> list = (from a in dc.sv_Orders select a).ToList<sv_Orders>();
            return list;
        }
    }
}
