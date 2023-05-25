using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace Admin_Page_News.Home
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        int idtheloai = 0;
        int idchuyenmuc = 0;

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
            List<Obj_Category> lstcategory = Dao_Category.getAllCategory();
            LV_ChuyenMuc.DataSource = lstcategory;
            LV_ChuyenMuc.DataBind();

            List<Obj_Tag> lstTag = Dao_Tag.getAllTag();
            LV_Theloai.DataSource = lstTag;
            LV_Theloai.DataBind();
            
        }

        public void loaddatads()
        {
            idtheloai = Convert.ToInt32(Request.QueryString["Tag_ID"]);
            idchuyenmuc = Convert.ToInt32(Request.QueryString["Category_ID"]);
            if (idtheloai != 0 )
            {
                List<Obj_News> lstnewshot3 = Dao_News.get_Id_Tag_News_ds(idtheloai);
                LV_News_All.DataSource = lstnewshot3;
                LV_News_All.DataBind();
            }
            else if (idchuyenmuc != 0)
            {
                List<Obj_News> lstchuenmuc = Dao_News.get_Id_Category_News_ds(idchuyenmuc);
                LV_News_All.DataSource = lstchuenmuc;
                LV_News_All.DataBind();
            }
            else
            {
                Response.Redirect("../Default.aspx");
            }
            
        }

        protected void LV_News_All_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dtpArticles.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loaddatads();
        }
    }
}