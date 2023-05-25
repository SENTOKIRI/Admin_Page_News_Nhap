using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Content_Creator
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int queryId = 0;
        int queryTagId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            queryId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
            queryTagId = Convert.ToInt32(Page.Request.QueryString["Tag_ID"]);
            if (!Page.IsPostBack)
            {
                if (queryId > 0 && queryTagId >0)
                {                
                    Obj_News objnew = Dao_News.getIDNews(queryId);
                    Lb_News_ID.Text = queryId.ToString();
                    Tb_News_Title.Text = objnew.News_Title;
                    Image1.ImageUrl = objnew.News_Avata;
                    Tb_News_Content.Text = objnew.News_Content;
                    DDL_Tag.SelectedValue = queryTagId.ToString();
                    Session["image1"] = objnew.News_Avata;
                  
                    Bt_Add_News.Enabled = false;
                }
                else
                {
                   
                    Bt_Sua.Enabled = false;
                   
                }
                ddl_data();

            }
        }
        protected void Bt_Add_News_Click(object sender, EventArgs e)
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

            if (Tb_News_Title.Text == "" && Tb_News_Content.Text == "")
            {
                Response.Write("<script>alert('Hãy nhập đầy đủ thông tin!!!: ') </script>");
            }
            else
            {

               
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                    ("insert into News (News_Title,News_Content,News_Create_Date,News_Avata,News_Edit_Date,News_Views_Count,News_Status,News_Hot,Tag_ID,News_Duyet,User_ID) values (@News_Title,@News_Content,@News_Create_Date,@News_Avata,@News_Edit_Date,0,0,0,@Tag_ID,0,@User_ID)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@News_ID", Lb_News_ID.Text);
                    cmd.Parameters.AddWithValue("@News_Title", Tb_News_Title.Text);
                    cmd.Parameters.AddWithValue("@Tag_ID", DDL_Tag.Text);
                    cmd.Parameters.AddWithValue("@News_Avata", url_img + img_name);
                    cmd.Parameters.AddWithValue("@News_Content", Tb_News_Content.Text);
                    cmd.Parameters.AddWithValue("@News_Create_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@News_Edit_Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@User_ID", Convert.ToInt32(Session["userid"]));
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("/Content_Creator/list_news.aspx");
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
                DDL_Tag.DataTextField = "Tag_Name";
                DDL_Tag.DataValueField = "Tag_ID";
                DDL_Tag.DataBind();
                DDL_Tag.Items.Insert(0, new ListItem("Thể loại", "0"));
            }

        }
        protected void Bt_Sua_News_Click(object sender, EventArgs e)
        {
            string url_img = "../images/";
            string img_name =Convert.ToString( Session["image1"]);
            if (FileUpload1.HasFile)
            {
                img_name = FileUpload1.FileName;
                string add_img = Server.MapPath(url_img + img_name);
                FileUpload1.SaveAs(add_img);
            }
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {

                SqlCommand cmd = new SqlCommand
                   ("update News set News_Title=@News_Title,News_Content=@News_Content ,News_Avata=@News_Avata,News_Create_Date=@News_Create_Date,Tag_ID=@Tag_ID  where News_ID=@News_ID and News_Duyet = '0'", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@News_ID", Lb_News_ID.Text);
                cmd.Parameters.AddWithValue("@News_Avata", url_img + img_name);
                cmd.Parameters.AddWithValue("@News_Title", Tb_News_Title.Text);
                cmd.Parameters.AddWithValue("@News_Content", Tb_News_Content.Text);
                cmd.Parameters.AddWithValue("@Tag_ID", DDL_Tag.Text);
                cmd.Parameters.AddWithValue("@News_Create_Date", DateTime.Now);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/Content_Creator/list_news.aspx");
            }

        }
     
    }
}