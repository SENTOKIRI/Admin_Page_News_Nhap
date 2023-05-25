using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null && Session["admin"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                Loadata();
                Bt_Sua.Enabled = false;
            }
    }

        protected void Loadata()
        {
            List<Obj_Tag> lsttag = Dao_Tag.getAllTag();
            Tags.DataSource = lsttag;
            Tags.DataBind();
        }

        protected void Tag_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            int _idCountTag = Convert.ToInt32(Tags.DataKeys[e.RowIndex].Value);
            Obj_Tag objtag = Dao_Tag.getCountTag(_idCountTag);           
            int index = Convert.ToInt32(e.RowIndex);
            int Tag_ID = Convert.ToInt32(Tags.DataKeys[e.RowIndex].Value);        
            int Tag_Count = objtag.Tag_Count;          

            if (Tag_Count != 0)
            {
                //Response.Write("<script language='javascript'>alert('Vẫn còn bài viết thuộc thể loại này! Hãy xóa bài viết trước khi xóa thẻ tag.');</script>");
                Tag_thongbao.Text = "Vẫn còn bài viết thuộc thể loại này! Hãy xóa bài viết trước khi xóa thẻ tag.";
                Response.Redirect("/Admin_Page/Tag.aspx");              
            }
            else
            {
                string strSql = "Delete from Tag where  [Tag_ID] = " + Tag_ID.ToString();             
                using (SqlConnection sqlConnection = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand(strSql, sqlConnection);
                    cmd.CommandType = System.Data.CommandType.Text;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                Response.Redirect("/Admin_Page/Tag.aspx");
            }
            
        }
        protected void Tag_RowEditing(object sender, GridViewEditEventArgs e)
        {       
                int _id = Convert.ToInt32(Tags.DataKeys[e.NewEditIndex].Value);
                Obj_Tag objtag = Dao_Tag.getIDTag(_id);
                Session["userName"] = objtag.Tag_ID;          
                Tb_Tag_Name.Text = objtag.Tag_Name.ToString();
                Bt_Add.Enabled = false;
                Bt_Sua.Enabled = true;
                Loadata();
        }

        protected void Bt_Sua_Tag_Click(object sender, EventArgs e)
        {
  
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("update Tag set [Tag_Name] = @Tag_Name where Tag_ID=@Tag_ID", conn);
                conn.Open();
                //cmd.Parameters.AddWithValue("@Tag_ID", Convert.ToInt32(LbTagId.Text));
                cmd.Parameters.AddWithValue("@Tag_ID", Convert.ToInt32(Session["userName"]));
                cmd.Parameters.AddWithValue("@Tag_Name", Tb_Tag_Name.Text);           
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/Admin_Page/Tag.aspx");
            }
        }

        protected void Bt_Them_Tag_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;          
                using (SqlConnection con = new SqlConnection(constr))
                {
                SqlCommand cmd = new SqlCommand("INSERT INTO Tag (Tag_Name) VALUES (@Tag_Name)");
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@Tag_Name", Tb_Tag_Name.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("/Admin_Page/Tag.aspx");                  
                }         
            DataBind();
        }


        protected void Tags_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Tags.PageIndex = e.NewPageIndex;
            Loadata();
            
        }

    }
}
