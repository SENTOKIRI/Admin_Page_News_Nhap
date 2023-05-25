using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Home
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddatads();
                loaddata();
            }
        }
        public void loaddata()
        {
            List<Obj_News> lstnewshot3 = Dao_News.get6News();
            LV_Hot_Danhsach.DataSource = lstnewshot3;
            LV_Hot_Danhsach.DataBind();

        }

        public void loaddatads()
        {
            List<Obj_News> lstnewshot3 = Dao_News.getAllNewsStatus();
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