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

        public static List<db.Books> getBooks1()
        {
            dbEntities dc = new dbEntities();
            List<Books> list = dc.Books.Where(a=>a.Price<20).ToList<Books>();
            return list;
        }


        public static List<db.Books> getBooks2()
        {
            dbEntities dc = new dbEntities();
            List<Books> list = dc.Books.Where(a=>a.Price>=20).ToList<Books>();
            return list;
        }


        // 新增方法一
        public static void insertOne(string AuthorName, string Title, Nullable<decimal> Price)
        {
            // 新增数据
            db.dbEntities dc = new dbEntities();
            db.Books entry = new Books();
            entry.AuthorName = AuthorName;
            entry.Title = Title;
            entry.Price = Price;
            dc.Books.Add(entry);
            dc.SaveChanges();
        }

        // 新增方法二
        public static void insertTwo(db.Books entry)
        {
            db.dbEntities dc = new dbEntities();
            dc.Books.Add(entry);
            dc.SaveChanges();

        }

       // 更新方法一
        public static void updateOne(string AuthorName, string Title, Nullable<decimal> Price, int BookId)
        {
            db.dbEntities dc = new dbEntities();
            db.Books entry = dc.Books.Single(a => a.BookId == BookId);
            entry.AuthorName = AuthorName;
            entry.Title = Title;
            entry.Price = Price;
            dc.SaveChanges();
        }

        // 更新方法二
        public static void updateTwo(db.Books entry)
        {
            db.dbEntities dc = new dbEntities();
            // 1. 将entry附加到entry 2. 附加之后，将他的状态改成修改状态
            dc.Entry<db.Books>(entry).State
                = System.Data.EntityState.Modified;
            dc.SaveChanges();
        }


        // 更新方法三
        public static void updateThree(db.Books entry)
        {
            db.dbEntities dc = new dbEntities();

            db.lib.efHelp.entryUpdate(entry, dc);
            dc.SaveChanges();
        }

        // 删除方法
        public static void delete(int bookid)
        {
            db.dbEntities dc = new dbEntities();
            db.Books entry = dc.Books.SingleOrDefault(a => a.BookId == bookid);
            dc.Books.Remove(entry);
            dc.SaveChanges();
        }

        public static db.Books getEntry(int id)
        {
            dbEntities dc = new dbEntities();
            Books entry = dc.Books.Single(a => a.BookId == id);
            return entry;
        }


        public static void batchUpdatePrice(List<string> rowIDList, List<string> priceList, List<string> booktypeList, Dictionary<string, string> dicBookTag)
        {
            dbEntities dc = new dbEntities();
            for (int i = 0; i < rowIDList.Count; i++)
            {
                int rowID = Convert.ToInt32(rowIDList[i]);
                db.Books entry = dc.Books.FirstOrDefault(b => b.BookId == rowID);
                entry.Price = Convert.ToDecimal(priceList[i]);
                entry.BookType = booktypeList[i];
                entry.BookTag = dicBookTag[rowIDList[i]];
            }
            dc.SaveChanges();
        }

    }
}
