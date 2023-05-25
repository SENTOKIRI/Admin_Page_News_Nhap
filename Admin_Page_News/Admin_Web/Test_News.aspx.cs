using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Admin_Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int queryId = 0;
        int queryNewsId = 0;
        int queryUserId = 0;
        int queryIdTag = 0;
        int quyerycategoryid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddata();
                loaddatalienquan();
            }
        }

        public void loaddata()
        {
            queryId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
            if (queryId > 0)
            {
                //===============================================================
                Obj_News objnews = Dao_News.getIDNews(queryId);
                Lb_tieude.Text = objnews.News_Title;
                Img_anh.ImageUrl = objnews.News_Avata;
                LB_noidung.Text = objnews.News_Content;
                Lb_time.Text = Convert.ToString(objnews.News_Edit_Date);
                Lb_view.Text = Convert.ToString(objnews.News_Views_Count);
                LB_Tag.Text = objnews.Tag_Name;
                Lb_User_Name.Text = objnews.User_Name + ": Xem thêm >>";
                Session["iduser"] = objnews.User_ID;
                Session["ID_Tag"] = objnews.Tag_ID;
                Session["Category_Tag"] = objnews.Category_ID;
            }
            else
            {
                Response.Redirect("/Admin_web/List_News.aspx");
            }

        }
        public void loaddatalienquan()
        {
                List<Obj_News> lstnewsLQ = Dao_News.get6News();
                LV_Lienquan.DataSource = lstnewsLQ;
                LV_Lienquan.DataBind();

                LV_Hotnews.DataSource = lstnewsLQ;
                LV_Hotnews.DataBind();
            
            quyerycategoryid = Convert.ToInt32(Session["Category_Tag"].ToString());
            if (quyerycategoryid > 0)
            {
                List<Obj_Tag> lstTag = Dao_Tag.getAllTagCategoryChitiet(quyerycategoryid);
                LV_Theloaichuyenmuc.DataSource = lstTag;
                LV_Theloaichuyenmuc.DataBind();
            }

        }
        protected void LBnt_Tag_Click(object sender, EventArgs e)
        {
            int _idTag = Convert.ToInt32(Session["ID_Tag"].ToString());

            Obj_News objnews2 = Dao_News.getIDNews(_idTag);
            string str_IdTag = objnews2.Tag_ID.ToString();
            Response.Redirect("/Home/SeachNews?Tag_ID=" + str_IdTag);
        }
        protected void Bnt_duyet_Click(object sender, EventArgs e)
        {
            queryId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("update News set News_Duyet = 1 , News_Comment = 'đã duyệt' where News_ID=@News_ID", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@News_ID",queryId);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/Admin_Web/List_News.aspx");
            }
        }
        protected void Bnt_ko_duyet_Click(object sender, EventArgs e)
        {
            queryId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
            string tb_comment = null;
            if (tb_comment == "")
            {
                
                tb_comment = "Hãy xem lại bài viết của bạn trước khi gửi";
            }
            else
            {
                tb_comment = Tb_Comment_Test.Text;
            }
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {

                    SqlCommand cmd = new SqlCommand
                   ("update News set News_Duyet = 0, News_Comment = '"+ tb_comment + "' where News_ID=@News_ID", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@News_ID", queryId);
                  

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("/Admin_Web/List_News.aspx");
                }               
            
            
        }

        protected void Btn_dang_Click(object sender, EventArgs e)
        {
            queryId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("update News set News_Status = 1,News_Hot = @newshot  where News_ID=@News_ID", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@News_ID", queryId);
                cmd.Parameters.AddWithValue("@newshot", CK_Hot.Checked);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/Admin_Web/List_News_QTV.aspx");
            }

        }

        protected void Btn_Khong_dang_Click(object sender, EventArgs e)
        {
            queryId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand("update News set News_Status = 0  where News_ID=@News_ID", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@News_ID", queryId);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("/Admin_Web/List_News_QTV.aspx");
            }

        }
    }
}