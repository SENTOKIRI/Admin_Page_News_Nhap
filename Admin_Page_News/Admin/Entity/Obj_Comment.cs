using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_Page_News.Admin.Entity
{
    public class Obj_Comment
    {
        public int CM_ID { get; set; }
        public int User_ID { get; set; }
        public string CM_Comment { get; set; }
        public string User_Full_Name { get; set; }
        public int News_ID { get; set; }       
        public string News_Title { get; set; }
        public string CM_Email { get; set; }
        public string CM_Rep { get; set; }
        public int bai_viet_chua_xem { get; set; }   
    }
}