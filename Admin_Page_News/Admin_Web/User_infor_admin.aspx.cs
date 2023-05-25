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
    public partial class WebForm8 : System.Web.UI.Page
    {
        int queryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../Login.aspx");
            }
            queryId = Convert.ToInt32(Page.Session["userid"]);
            if (!Page.IsPostBack)
            {
                if (queryId > 0)
                {

                    Obj_User objuser = Dao_User.getIDUser(queryId);

                    Session["User_ID"] = queryId.ToString();
                    Lb_User_Name_Top.Text = objuser.User_Full_Name;
                    Lb_Email_Top.Text = objuser.Email;
                    Tb_User_ID.Text = queryId.ToString();
                    Tb_User_Name.Text = objuser.User_Name;
                    Tb_Password.Text = objuser.Password;
                    Tb_Full_Name.Text = objuser.User_Full_Name;
                    Tb_Email.Text = objuser.Email;
                    Add_Image.ImageUrl = objuser.User_Avata;
                    Session["imageuser"] = objuser.User_Avata;
                }
            }
        }
        protected void Bnt_Edit_Click(object sender, EventArgs e)
        {
            Tb_User_Name.Enabled = true;
            Tb_Password.Enabled = true;

            Tb_Full_Name.Enabled = true;
            Tb_Email.Enabled = true;
            Btn_Sua.Enabled = true;
        }
        protected void Bt_Sua_User_Click(object sender, EventArgs e)
        {
            string url_img = "../images/";
            string img_name = Session["imageuser"].ToString();
            if (FileUpload1.HasFile)
            {
                img_name = FileUpload1.FileName;
                string add_img = Server.MapPath(url_img + img_name);
                FileUpload1.SaveAs(add_img);
            }

            queryId = Convert.ToInt32(Page.Session["userid"]);
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {

                SqlCommand cmd = new SqlCommand
                ("update Users set [User_Name]=@User_Name, [Password]=@Password, [User_Full_Name]=@User_Full_Name, [Email]=@Email, [User_Avata]= @User_Avata where User_ID=@User_ID", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@User_ID", queryId);
                cmd.Parameters.AddWithValue("@User_Name", Tb_User_Name.Text);
                cmd.Parameters.AddWithValue("@Password", Tb_Password.Text);
                cmd.Parameters.AddWithValue("@User_Full_Name", Tb_Full_Name.Text);
                cmd.Parameters.AddWithValue("@Email", Tb_Email.Text);
                cmd.Parameters.AddWithValue("@User_Avata", url_img + img_name);
                cmd.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("../Content_Creator/User_Infor.aspx");

            }


        }
        protected void Btn_chuyenmuc_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin_Web/Category.aspx");

        }
        protected void Btn_theloai_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin_Web/Tag_News.aspx");
        }
        protected void Btn_nguoidung_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin_Web/User_QL.aspx");

        }
        protected void Btn_phanhoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Admin_Web/User_Comment.aspx");
        }
        protected void Btn_thoat_Click(object sender, EventArgs e)
        {
            Page.Session["userid"] = null;
            Page.Session["name"] = null;
            Page.Session["fullname"] = null;
            Page.Session["avata"] = null;
            Page.Session["admin"] = null;
            Page.Session["email"] = null;
            Response.Redirect("../Default.aspx");
        }
    }
}