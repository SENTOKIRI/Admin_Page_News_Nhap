using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Home
{
    public partial class WebForm10 : System.Web.UI.Page
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
            string lb1 = Convert.ToString(Request.QueryString["News_Title"]);
            Label1.Text = lb1;

            List<Obj_News> lstnewshot3 = Dao_News.get_Title_News(lb1);
            LV_News_All.DataSource = lstnewshot3;
            LV_News_All.DataBind();

        }

        protected void LV_News_All_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dtpArticles.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loaddatads();
        }
    }
}