using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Admin_Web
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        int queryCategoryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null && Session["admin"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                loadata();
                ddl_data();
                Bt_Sua.Enabled = false;
            }

        }
        protected void loadata()
        {
            List<Obj_Tag> lsttag = Dao_Tag.getAllTag();
            Tags.DataSource = lsttag;
            Tags.DataBind();
        }
        private void ddl_data()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string com = "Select Category_ID,Category_Name from TB_Category Order by Category_Name ASC";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DDL_Category.DataSource = dt;
                DDL_Category.DataTextField = "Category_Name";
                DDL_Category.DataValueField = "Category_ID";
                DDL_Category.DataBind();
                DDL_Category.Items.Insert(0, new ListItem("Chuyên mục", "0"));
            }

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
                
                Tag_thongbao.Text = "Vẫn còn bài viết thuộc thể loại này! Hãy xóa bài viết trước khi xóa thẻ tag.";
                Response.Redirect("/Admin_Web/Tag_News.aspx");
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
                Response.Redirect("/Admin_Web/Tag_News.aspx");
            }

        }
        protected void Tag_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(Tags.DataKeys[e.NewEditIndex].Value);

            Obj_Tag objtag = Dao_Tag.getIDTag(_id);
            
            Session["Tag_ID"] = objtag.Tag_ID;
            Tb_Tag_Name.Text = objtag.Tag_Name.ToString();
            DDL_Category.SelectedValue = objtag.Category_ID.ToString();
            //DDL_Category.SelectedItem.Text = objtag.Category_Name.ToString();
            Bt_Add.Enabled = false;
            Bt_Sua.Enabled = true;
            DDL_Category.AutoPostBack = false;
            loadata();
        }
        protected void Bt_Sua_Tag_Click(object sender, EventArgs e)
        {

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("update Tag set [Tag_Name] = @Tag_Name , Category_ID =@Category_ID where Tag_ID=@Tag_ID", conn);
                conn.Open();
                //cmd.Parameters.AddWithValue("@Tag_ID", Convert.ToInt32(LbTagId.Text));
                cmd.Parameters.AddWithValue("@Tag_ID", Convert.ToInt32(Session["Tag_ID"]));
                cmd.Parameters.AddWithValue("@Tag_Name", Tb_Tag_Name.Text);
                cmd.Parameters.AddWithValue("@Category_ID", Convert.ToInt32(DDL_Category.SelectedValue));
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/Admin_Web/Tag_News.aspx");
            }
        }
        protected void Bt_Them_Tag_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                int categoryid = Convert.ToInt32(DDL_Category.SelectedValue);
                if (categoryid > 0)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Tag (Tag_Name,Category_ID ) VALUES (@Tag_Name,@Category_ID)");
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Tag_Name", Tb_Tag_Name.Text);
                    cmd.Parameters.AddWithValue("@Category_ID", categoryid);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("/Admin_Web/Tag_News.aspx");
                }
                else
                {
                    Response.Redirect("/Admin_Web/Tag_News.aspx");
                }
               
            }
            

            
            DataBind();
        }
        protected void Tags_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Tags.PageIndex = e.NewPageIndex;
            loadata();

        }
        protected void DDL_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            queryCategoryId = Convert.ToInt32(DDL_Category.SelectedValue);
            if (queryCategoryId == 0)
            {
                loadata();
            }
            else
            {
                List<Obj_Tag> lsttag = Dao_Tag.getAllTagCategory(queryCategoryId);
                Tags.DataSource = lsttag;
                Tags.DataBind();
            }
        }
    }
}