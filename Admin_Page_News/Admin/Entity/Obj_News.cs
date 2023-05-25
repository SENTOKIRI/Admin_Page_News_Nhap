using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Admin_Page_News.Admin.Entity
{
    public class Obj_News
    {      
        public int News_ID { get; set; }      
        public string News_Content { get; set; }
        public string News_Title { get; set; }
        public DateTime News_Create_Date { get; set; }
        public DateTime News_Edit_Date { get; set; }
        public int News_Views_Count { get; set; }
        public string News_Avata { get; set; }
        public int News_Status { get; set; }
        public string News_Status_str { get; set; }
        public int Tag_ID { get; set; }
        public string Tag_Name { get; set; }    
        public int Tong_Bai_Viet { get; set; }  
        public int News_Hot { get; set; }   
        public string News_Hot_str { get; set; }
        public int User_ID { get; set; }
        public string News_Comment { get; set; }
        public int STT { get; set; }
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }

      
        public string User_Name { get; set; }
     
        public string User_Full_Name { get; set; }
        public string Email { get; set; }
        public string Admin { get; set; }
        public int Admin_Int { get; set; }
        public string User_Avata { get; set; }
    }
}