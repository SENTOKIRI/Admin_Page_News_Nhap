using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_Page_News.Admin.Entity
{
    public class Obj_Category
    {
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public int Category_Count { get; set; }
        public string Category_Img { get; set; }
        public int Tag_ID { get; set; }
        public string Tag_Name { get; set; }
    }
}