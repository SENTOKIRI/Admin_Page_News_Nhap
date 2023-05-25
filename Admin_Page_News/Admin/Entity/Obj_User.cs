using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_Page_News.Admin.Entity
{
    public class Obj_User
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public string User_Full_Name { get; set; }
        public string Email { get; set; }
        public string Admin { get; set; }
        public int Admin_Int { get; set; }
        public string User_Avata { get; set; }
       
    }
}