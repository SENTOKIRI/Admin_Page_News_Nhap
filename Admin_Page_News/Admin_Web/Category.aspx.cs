using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Admin_Web
{
    public partial class WebForm4 : System.Web.UI.Page
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
            List<Obj_Category> lstcategory = Dao_Category.getAllCategory();
            Tags.DataSource = lstcategory;
            Tags.DataBind();
        }
        protected void Tag_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            int _idCountTag = Convert.ToInt32(Tags.DataKeys[e.RowIndex].Value);
            Obj_Tag objtag = Dao_Tag.getCountTag(_idCountTag);
            int index = Convert.ToInt32(e.RowIndex);
            int Category_ID = Convert.ToInt32(Tags.DataKeys[e.RowIndex].Value);
            int Tag_Count = objtag.Tag_Count;

            if (Tag_Count != 0)
            {

                Tag_thongbao.Text = "Vẫn còn thể loại thuộc chuyên mục này này!";
                Response.Redirect("/Admin_Web/Tag_News.aspx");
            }
            else
            {
                string strSql = "Delete from TB_Category where  [Category_ID] = " + Category_ID.ToString();
                using (SqlConnection sqlConnection = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand(strSql, sqlConnection);
                    cmd.CommandType = System.Data.CommandType.Text;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
                Response.Redirect("/Admin_Web/Category.aspx");
            }

        }
        protected void Tag_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(Tags.DataKeys[e.NewEditIndex].Value);
            Obj_Category objtag = Dao_Category.getIDCategory(_id);
            Session["userName"] = objtag.Category_ID;
            Tb_Tag_Name.Text = objtag.Category_Name.ToString();
            Image1.ImageUrl = objtag.Category_Img.ToString();
            Bt_Add.Enabled = false;
            Bt_Sua.Enabled = true;
            Loadata();
        }
        protected void Bt_Sua_Category_Click(object sender, EventArgs e)
        {
            string url_img = "../images/";
            string img_name = string.Empty;
            if (FileUpload1.HasFile)
            {
                img_name = FileUpload1.FileName;
                string add_img = Server.MapPath(url_img + img_name);
                FileUpload1.SaveAs(add_img);
            }
            else
            {
                img_name = "kamen-rider-geats.png";
            }

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand
                    ("update TB_Category set [Category_Name] = @Category_Name ,  [Category_Img] = @Category_Img where Category_ID=@Category_ID", conn);
                conn.Open();
                //cmd.Parameters.AddWithValue("@Tag_ID", Convert.ToInt32(LbTagId.Text));
                cmd.Parameters.AddWithValue("@Category_ID", Convert.ToInt32(Session["userName"]));
                cmd.Parameters.AddWithValue("@Category_Name", Tb_Tag_Name.Text);
                cmd.Parameters.AddWithValue("@Category_Img", url_img + img_name);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/Admin_Web/Category.aspx");
            }
        }
        protected void Bt_Them_Category_Click(object sender, EventArgs e)
        {
            string url_img = "../images/";
            string img_name = string.Empty;
            if (FileUpload1.HasFile)
            {
                img_name = FileUpload1.FileName;
                string add_img = Server.MapPath(url_img + img_name);
                FileUpload1.SaveAs(add_img);
            }
            else
            {
                img_name = "kamen-rider-geats.png";
            }

            string constr = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TB_Category (Category_Name,Category_Img) VALUES (@Category_Name,@Category_Img)");
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@Category_Name", Tb_Tag_Name.Text);
                cmd.Parameters.AddWithValue("@Category_Img", url_img + img_name);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("/Admin_Web/Category.aspx");
            }
           
        }
        protected void Tags_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Tags.PageIndex = e.NewPageIndex;
            Loadata();

        }
       
    }
}