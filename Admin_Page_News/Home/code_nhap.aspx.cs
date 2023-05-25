using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Home
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddatads();
            }
        }

        public void loaddatads()
        {
           int _ID = Convert.ToInt32(Request.QueryString["User_ID"]);

            List<Obj_News> lstnew = Dao_News.getIDUserNews(20);
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