using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_Page_News.Admin.Entity
{
    public class Obj_UCN
    {
        public int UCN_ID { get; set; }
        public string UCN_Content { get; set; }
        public string UCN_Title { get; set; }
        public DateTime UCN_Create_Date { get; set; }
        public string UCN_Avata { get; set; }
        public int UCN_Status { get; set; }      
        public int Tag_ID { get; set; }
        public string Tag_Name { get; set; }
        public string UCN_Comment { get; set; }

    }
}