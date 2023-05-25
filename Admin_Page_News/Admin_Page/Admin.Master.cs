using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (HttpContext.Current.Session["fullname"] != null)
            {
                LB_Admin.Text = Page.Session["fullname"].ToString();
            }
           
        }
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void User_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Page/Users.aspx");
        }
        protected void Tag_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Page/Tag.aspx");
        }
        protected void My_News_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Page/News.aspx");
        }
        protected void Add_News_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Page/Add_News.aspx");
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home/Home.aspx");
        }

       
    }
}