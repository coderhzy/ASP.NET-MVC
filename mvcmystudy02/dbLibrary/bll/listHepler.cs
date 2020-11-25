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
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "南京", Value = "nj" });
            list.Add(new SelectListItem() { Text = "苏州", Value = "sz" });
            list.Add(new SelectListItem() { Text = "泰州", Value = "tz" });
            return list;
        }
        public static List<SelectListItem> getSex()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "男", Value = "F" });
            list.Add(new SelectListItem() { Text = "女", Value = "M" });
            list.Add(new SelectListItem() { Text = "保密", Value = "null" });
            return list;
        }
        public static List<SelectListItem> getHobby()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "读书", Value = "readBook" });
            list.Add(new SelectListItem() { Text = "跑步", Value = "run" });
            list.Add(new SelectListItem() { Text = "看电影", Value = "film" });
            return list;
        }
        public static List<SelectListItem> getBookType()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "计算机", Value = "计算机" });
            list.Add(new SelectListItem() { Text = "外语", Value = "外语" });
            list.Add(new SelectListItem() { Text = "艺术", Value = "艺术" });
            return list;
        }
        public static List<SelectListItem> getBookType(string oldValue)
        {
            oldValue = oldValue == null ? "" : oldValue;
            List<string> selectedList = oldValue.Split(',').ToList<string>();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "计算机", Value = "计算机" });
            list.Add(new SelectListItem() { Text = "外语", Value = "外语" });
            list.Add(new SelectListItem() { Text = "艺术", Value = "艺术" });

            foreach (var item in list)
            {
                if (selectedList.Contains(item.Value))
                {
                    item.Selected = true;
                }
            }
            return list;
        }
        public static List<SelectListItem> getBookTag()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "低折扣", Value = "低折扣" });
            list.Add(new SelectListItem() { Text = "畅销书", Value = "畅销书" });
            list.Add(new SelectListItem() { Text = "促销书", Value = "促销书" });
            return list;
        }
        public static List<SelectListItem> getBookTag(string oldValue)
        {
            oldValue = oldValue == null ? "" : oldValue;
            List<string> selectedList = oldValue.Split(',').ToList<string>();
            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Text = "低折扣", Value = "低折扣" });
            list.Add(new SelectListItem() { Text = "畅销书", Value = "畅销书" });
            list.Add(new SelectListItem() { Text = "促销书", Value = "促销书" });

            foreach (var item in list)
            {
                if (selectedList.Contains(item.Value))
                {
                    item.Selected = true;
                }
            }
            return list;
        }
    }
}

