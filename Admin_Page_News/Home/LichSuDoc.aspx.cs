using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Home
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        int queryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              //  Loaddata();
                loaddatads();
            }
        }
        public void loaddatads()
        {
            queryId = Convert.ToInt32(Page.Request.QueryString["User_ID"]);
            if (queryId != 0){
            List<Obj_News> lstlichsu = Dao_LichSu_Theodoi.getAllLichSu(queryId);
            LV_News_All.DataSource = lstlichsu;
            LV_News_All.DataBind();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void LV_News_All_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            dtpArticles.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            loaddatads();
        }

        protected void LV_News_All_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
                int _id = Convert.ToInt32(e.CommandName);
                string strSql = "Delete from TB_Lichsu where  [News_ID] = " + _id + " ";
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

                using (SqlConnection sqlConnection = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand(strSql, sqlConnection);
                    cmd.CommandType = System.Data.CommandType.Text;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                  
                }
            loaddatads();


        }
       
    }
}