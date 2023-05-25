using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;




namespace Admin_Page_News
{
    public partial class WebForm1 : System.Web.UI.Page
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
            queryId = Convert.ToInt32( Session["userid"]);
            List<Obj_User> lstuser = Dao_User.getAllUser(queryId);
            Users.DataSource = lstuser;
            Users.DataBind();
        }

        protected void Users_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int User_ID = Convert.ToInt32(Users.DataKeys[e.RowIndex].Value);

            string strSql = "Delete from Users where  [User_ID] = " + User_ID.ToString();
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
            Response.Redirect("/Admin_Page/Users.aspx");
        }
 
        protected void Users_RowEditing(object sender, GridViewEditEventArgs e )
        {
            int _id = Convert.ToInt32(Users.DataKeys[e.NewEditIndex].Value);
            Obj_User objuser = Dao_User.CheckIDUser(_id);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand ("update Users set [Admin] =@Admin where User_ID = @User_ID", conn);
                cmd.Parameters.AddWithValue("@User_ID",_id);
                if (objuser.Admin_Int == 1)
                {
                    cmd.Parameters.AddWithValue("@Admin", 0);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Admin", 1);
                }
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/Admin_Page/Users.aspx");
            }
        }
        protected void Users_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            queryId = Convert.ToInt32(Session["userid"]);
            Users.PageIndex = e.NewPageIndex;
            List<Obj_User> lstuser = Dao_User.getAllUser(queryId);
            Users.DataSource = lstuser;
            Users.DataBind();
        }

        protected void Bnt_Seach_Click(object sender, EventArgs e)
        {
            queryId = Convert.ToInt32(Session["userid"]);
            List<Obj_User> lstuser1 = Dao_User.getUserSeach(Tb_Seach.Text.Trim(),queryId);
            Users.DataSource = lstuser1;
            Users.DataBind();
        }

        protected void Bnt_Reset_Click(object sender, EventArgs e)
        {
            Loadata();
        }
    }
}