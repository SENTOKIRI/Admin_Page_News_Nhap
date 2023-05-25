using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Page_News.Admin.Dao;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services.Description;

namespace Admin_Page_News
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] != null)

                {
                Response.Redirect("Default.aspx");
                }
            }

        }

        protected void btndangnhap_Click(object sender, EventArgs e)
        {
            Obj_User user = Dao_User.GetOneUser(tbtaikhoan.Text, tbmatkhau.Text);
            if (user != null)
            {
                int admin = Convert.ToInt32(user.Admin_Int.ToString());
                if (admin == 1)
                {
                    Page.Session["userid"] = user.User_ID;
                    Page.Session["fullname"] = user.User_Full_Name;
                    Page.Session["avata"] = user.User_Avata;
                    Page.Session["admin"] = 1;
                    Page.Session["email"] = user.Email;
                    Response.Redirect("Admin_Web/List_News_QTV.aspx");
                }
                else if (admin == 2)
                {
                    Page.Session["userid"] = user.User_ID;
                    Page.Session["fullname"] = user.User_Full_Name;
                    Page.Session["avata"] = user.User_Avata;
                    Page.Session["admin"] = 2;
                    Page.Session["email"] = user.Email;
                    Response.Redirect("Admin_Web/List_News.aspx");

                }
                else if (admin == 3)
                {
                    Page.Session["userid"] = user.User_ID;
                    Page.Session["fullname"] = user.User_Full_Name;
                    Page.Session["avata"] = user.User_Avata;
                    Page.Session["admin"] = 3;
                    Page.Session["email"] = user.Email;
                    Response.Redirect("Content_Creator/list_news.aspx");
                }

                else if (admin == 4)
                {
                    Page.Session["userid"] = user.User_ID;
                    Page.Session["name"] = user.User_Name;
                    Page.Session["fullname"] = user.User_Full_Name;
                    Page.Session["avata"] = user.User_Avata;
                    Page.Session["admin"] = 4;
                    Page.Session["email"] = user.Email;
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Tài khoản hoặc mật khẩu không đúng !!!: ') </script>");
                Response.Redirect("Login.aspx");
            }
         
        }

    }
}