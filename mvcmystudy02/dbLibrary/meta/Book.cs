using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db
{
    [MetadataType(typeof(metaData))]

    public partial class Books
    {
        public class metaData
        {
            [Display(Name = "编号")]
            public int BookId { get; set; }
            [Display(Name = "作者名")]
            public string AuthorName { get; set; }
            [Display(Name = "标题")]
            public string Title { get; set; }
            [Display(Name = "图书价格")]
            public Nullable<decimal> Price { get; set; }
            [Display(Name = "封面图")]
            public string BookCoverUrl { get; set; }
            [Display(Name = "图书类别")]
            public string BookType { get; set; }
            [Display(Name = "图书标签")]
            public string BookTag { get; set; }
        }
    }
}
