using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace db.bll
{
    public class listHepler
    {
        public static List<SelectListItem> getCity()
        {
            // 城市下拉框
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem(){ Text="南京",Value="nj",Selected = true});
            list.Add(new SelectListItem(){ Text="苏州",Value="sz"});
            list.Add(new SelectListItem() { Text = "上海", Value = "sh"});
            return list;
        }

        public static List<SelectListItem> getSex()
        {
            // 性别下拉框
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "男", Value = "F", Selected = true });
            list.Add(new SelectListItem() { Text = "女", Value = "M" });
            return list;
        }

        public static List<SelectListItem> getHobby()
        {
            // 爱好下拉框
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "读书", Value = "book", Selected = true });
            list.Add(new SelectListItem() { Text = "音乐", Value = "Music" });
            list.Add(new SelectListItem() { Text = "跑步", Value = "Play" });
            return list;
        }

        public static List<SelectListItem> getBookType()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "计算机", Value = "计算机", Selected = true });
            list.Add(new SelectListItem() { Text = "外语", Value = "外语" });
            list.Add(new SelectListItem() { Text = "艺术", Value = "艺术" });
            return list;
        }

        public static List<SelectListItem> getBookTag()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "低折扣", Value = "低折扣", Selected = true });
            list.Add(new SelectListItem() { Text = "畅销书", Value = "畅销书" });
            list.Add(new SelectListItem() { Text = "促销书", Value = "促销书" });
            return list;
        }
    }
}
