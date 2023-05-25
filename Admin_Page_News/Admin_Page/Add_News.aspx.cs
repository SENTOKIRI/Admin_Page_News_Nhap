using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News
{
   
    public partial class WebForm4 : System.Web.UI.Page
    {
        int queryId = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["userid"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            queryId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
            if (!Page.IsPostBack)
            {
                if (queryId > 0)
                {
                    Obj_News objnews = Dao_News.getIDNews(queryId);
                    Lb_News_ID.Text = queryId.ToString();                 
                    Tb_News_Title.Text = objnews.News_Title;                 
                    Add_Image.ImageUrl= objnews.News_Avata;                     
                    Tb_News_Content.Text = objnews.News_Content;
                   // DDL_Tag.Text = objnews.Tag_Name;
                    News_Status.Checked = Convert.ToBoolean(objnews.News_Status);
                    News_Hot.Checked = Convert.ToBoolean(objnews.News_Hot);
                    Bt_Add_News.Enabled = false;
                }
                else
                {
                    Bt_Sua.Enabled = false; 
                    //ddl_data();
                }
                ddl_data();

            }
        }
        protected void Bt_Add_News_Click(object sender, EventArgs e)
        {
            if (Tb_News_Title.Text == "" && Tb_News_Content.Text == "" )
            {
                Response.Write("<script>alert('Hãy nhập đầy đủ thông tin!!!: ') </script>");
            }
            else
            {

                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                    ("insert into News (News_Title,News_Content,News_Create_Date,News_Avata,News_Edit_Date,News_Views_Count,News_Status,News_Hot,Tag_ID) values (@News_Title,@News_Content,@News_Create_Date,@News_Avata,@News_Edit_Date,0,@News_Status,@News_Hot,@Tag_ID)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@News_ID", Lb_News_ID.Text);
                    cmd.Parameters.AddWithValue("@News_Title", Tb_News_Title.Text);
                    cmd.Parameters.AddWithValue("@Tag_ID", DDL_Tag.Text);
                    cmd.Parameters.AddWithValue("@News_Avata", Add_Image.ImageUrl);
                    cmd.Parameters.AddWithValue("@News_Content", Tb_News_Content.Text);
                    cmd.Parameters.AddWithValue("@News_Create_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@News_Edit_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@News_Status", News_Status.Checked);
                    cmd.Parameters.AddWithValue("@News_Hot", News_Hot.Checked);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("/Admin_Page/News.aspx");
                }
            }          
        }
        private void ddl_data()
        {
            queryId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
           
                
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    string com = "Select Tag_ID,Tag_Name from Tag Order by Tag_Name ASC";
                    SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    DDL_Tag.DataSource = dt;
                    DDL_Tag.DataBind();
                    DDL_Tag.DataTextField = "Tag_Name";
                    DDL_Tag.DataValueField = "Tag_ID";
                    DDL_Tag.DataBind();
                }
            
        }
        protected void Bt_Sua_News_Click(object sender, EventArgs e)
        {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {

                    SqlCommand cmd = new SqlCommand
                   ("update News set News_Title=@News_Title,News_Content=@News_Content ,News_Avata=@News_Avata,News_Edit_Date=@News_Edit_Date,News_Status=@News_Status,News_Hot=@News_Hot,Tag_ID=@Tag_ID  where News_ID=@News_ID", conn);

                    conn.Open();
                    cmd.Parameters.AddWithValue("@News_ID", Lb_News_ID.Text);
                    cmd.Parameters.AddWithValue("@News_Avata",Add_Image.ImageUrl);
                    cmd.Parameters.AddWithValue("@News_Title", Tb_News_Title.Text);
                    cmd.Parameters.AddWithValue("@News_Content", Tb_News_Content.Text);
                    cmd.Parameters.AddWithValue("@Tag_ID", DDL_Tag.Text);
                    cmd.Parameters.AddWithValue("@News_Edit_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@News_Status", News_Status.Checked);
                    cmd.Parameters.AddWithValue("@News_Hot", News_Hot.Checked);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("/Admin_Page/News.aspx");
                }
            
        }
        public void check_image()
        {
            if (Page.IsValid && News_Image.HasFile)
            {
                string fileName = "images/" + News_Image.FileName;
                string filePath = MapPath(fileName);
                News_Image.SaveAs(filePath);
                Add_Image.ImageUrl = fileName;
            }
        }

        protected void Update_Image_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && News_Image.HasFile && CheckFileType(News_Image.FileName))
            {
                string fileName = "../images/" +  News_Image.FileName;
                string filePath = MapPath(fileName);
                News_Image.SaveAs(filePath);
                Add_Image.ImageUrl = fileName;
            }
        }
        bool CheckFileType(string fileName)
        {

            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".gif":
                    return true;
                case ".png":
                    return true;
                case ".jpg":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }
    }
}