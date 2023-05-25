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

namespace Admin_Page_News.Home
{
    public partial class WebForm4 : System.Web.UI.Page
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
                queryId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
                if (queryId > 0)
                {
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
                    Response.Redirect("../Default.aspx");
                }
                loaddatalienquan();
                update_lich_su();
                Obj_News objnews1 = Dao_News.updateview(queryId);
                TB_Email.Text = Convert.ToString( Session["email"]);
            }
        }
        public void loaddatalienquan()
        {
            List<Obj_News> lstnewshot = Dao_News.get6News();
            LV_Hotnews.DataSource = lstnewshot;
            LV_Hotnews.DataBind(); 

            queryIdTag = Convert.ToInt32(Session["ID_Tag"].ToString());
            if (queryIdTag > 0)
            {
                
                List<Obj_News> lstnewsLQ = Dao_News.get_ID_Tag_News_1(queryIdTag);
                LV_Lienquan.DataSource = lstnewsLQ;
                LV_Lienquan.DataBind();
            }
            quyerycategoryid = Convert.ToInt32(Session["Category_Tag"].ToString());
            if (queryIdTag > 0)
            {
                List<Obj_Tag> lstTag = Dao_Tag.getAllTagCategoryChitiet(quyerycategoryid);
                LV_Theloaichuyenmuc.DataSource = lstTag;
                LV_Theloaichuyenmuc.DataBind();
            }

        }   
        protected void LBnt_Tag_Click(object sender, EventArgs e)
        {
            int _idTag = Convert.ToInt32(Session["ID_Tag"].ToString());
           
           Obj_Tag objtag = Dao_Tag.getIDTag(_idTag);
            string str_IdTag = objtag.Tag_ID.ToString();
            Response.Redirect("/Home/dschuyenmuc?Tag_ID=" + str_IdTag);
        }
        public void update_lich_su()
        {
            queryNewsId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
            queryUserId = Convert.ToInt32(Page.Session["userid"]);
            if (queryUserId != 0)
            {
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                   ("insert into TB_Lichsu (User_ID,News_ID) values (@User_ID,@News_ID)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@News_ID", queryNewsId);
                    cmd.Parameters.AddWithValue("@User_ID", queryUserId);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
            }
           
        }
        protected void Btn_Gui_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            if(Session["userid"] !=null)
            {
                UserID = Convert.ToInt32(Page.Session["userid"]);
            }
            UserID = Convert.ToInt32(Page.Session["userid"]);
            int id_content_creator = Convert.ToInt32(Session["iduser"]);

            queryNewsId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                   ("insert into TB_Comment(CM_Comment,News_ID,User_ID,CM_Email,CM_Rep,CM_Xem,ID_Content_Creator) values (@CM_Comment,@News_ID,@User_ID,@CM_Email,'Rep',1,@id_content_creator)", conn);

                    conn.Open();
                    cmd.Parameters.AddWithValue("@CM_Comment", TB_Comment.Text.ToString());
                    cmd.Parameters.AddWithValue("@CM_Email", TB_Email.Text.ToString());
                    cmd.Parameters.AddWithValue("@News_ID", queryNewsId);
                    cmd.Parameters.AddWithValue("@User_ID", UserID);
                    cmd.Parameters.AddWithValue("@id_content_creator", id_content_creator);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                   Response.Redirect("/Home/ChiTiet?News_ID=" + queryNewsId);

            }
        }
        protected void Btn_theo_doi_Click(object sender, EventArgs e)
        {
            int UserID = 0;
            UserID = Convert.ToInt32(Page.Session["userid"]);
            if (UserID == 0)
            {
                Btn_luu.Enabled = false;
                Btn_luu.EnableViewState=false;
            }
            else
            {
                queryNewsId = Convert.ToInt32(Page.Request.QueryString["News_ID"]);
                string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                   ("insert into TB_Theodoi (News_ID,User_ID) values (@News_ID,@User_ID)", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@News_ID", queryNewsId);
                    cmd.Parameters.AddWithValue("@User_ID", UserID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("/Home/ChiTiet?News_ID=" + queryNewsId);

                }
            }
        }
        protected void Lb_User_Name_Click(object sender, EventArgs e)
        {
            int _idUser = Convert.ToInt32(Session["iduser"].ToString());
            Obj_User objuser = Dao_User.getIDUser(_idUser);
            string str_IdUser = objuser.User_ID.ToString();
            string name =objuser.User_Name.ToString();
            Response.Redirect("/Home/dstincuanguoiviet?User_ID="+str_IdUser+"&User_Name="+name);
        }
    
    }
}