using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Home
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        int _ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string name = Convert.ToString(Request.QueryString["User_Name"]);
                Label1.Text = name;
                loaddatads();
                
            }
        }
        public void loaddatads()
        {
            _ID = Convert.ToInt32(Request.QueryString["User_ID"]);

            List<Obj_News> lstnew = Dao_News.getIDUserNews(_ID);
            LV_News_All.DataSource = lstnew;
            LV_News_All.DataBind();

        }

        protected void LV_News_All_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dtpArticles.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loaddatads();
        }
    
    }
}