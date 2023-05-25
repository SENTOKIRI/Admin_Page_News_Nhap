using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Content_Creator
{
    public partial class ContentCreator : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lb_User_Name.Text = Convert.ToString(Session["fullname"]).ToString();
            }
            
        }
    }
}