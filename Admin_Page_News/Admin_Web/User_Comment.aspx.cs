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

namespace Admin_Page_News.Admin_Web
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        int queryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                Loadata();
              
              
            }
        }
        protected void Loadata()
        {
            queryId = Convert.ToInt32(Session["userid"]);
            List<Obj_Comment> lstcm = Dao_Comment.getAllComment();
            
            TB_Comment.DataSource = lstcm;
            TB_Comment.DataBind();
        }
        protected void Users_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int User_ID = Convert.ToInt32(TB_Comment.DataKeys[e.RowIndex].Value);
            string strSql = "Delete from TB_Comment where  [CM_ID] = " + User_ID.ToString();
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
            Response.Redirect("/Admin_Web/User_Comment.aspx");
        }
        protected void Users_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            queryId = Convert.ToInt32(Session["userid"]);
            TB_Comment.PageIndex = e.NewPageIndex;
            Loadata() ;
        }
        protected void Btn_Rep_Click(object sender, EventArgs e)
        {
           
            int CMID = Convert.ToInt32(TB_ID.Text);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update TB_Comment set CM_Rep = @CM_Rep , CM_Xem = 0 where CM_ID = @CM_ID", conn);
                cmd.Parameters.AddWithValue("@CM_Rep", message_text.Text);
                cmd.Parameters.AddWithValue("@CM_ID", CMID);
                cmd.ExecuteNonQuery();
                conn.Close();
                Loadata() ;
              //  Response.Redirect("/Admin_Web/User_Comment.aspx");

            }
    }
        
    }
}