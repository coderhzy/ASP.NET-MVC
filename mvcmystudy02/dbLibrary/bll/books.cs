using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.bll
{
    public class books
    {
        public static List<db.Books> getBooks()
        {
            dbEntities dc = new dbEntities();
            List<Books> list = (from a in dc.Books select a).ToList<Books>();

            return list;
        }

        public static db.Books getEntry(int id)
        {
            dbEntities dc = new dbEntities();
            Books entry = dc.Books.Single(a => a.BookId == id);
            return entry;
        }

    }
}
