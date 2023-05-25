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

namespace Admin_Page_News
{
    public partial class QTV_NEWS_24H : System.Web.UI.Page
    {
        int queryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            queryId = Convert.ToInt32(Page.Session["userid"]);
            if (!Page.IsPostBack)
            {
                //if (queryId > 0)
                //{

                //    Obj_User objuser = Dao_User.getIDUser(queryId);

                //    Session["User_ID"] = queryId.ToString();
                //    Lb_User_Name_Top.Text = objuser.User_Full_Name;
                //    Lb_Email_Top.Text = objuser.Email;

                //    //Lb_User_ID.Text = queryId.ToString();
                //    //Lb_User_Name.Text = objuser.User_Full_Name; 
                //    //Lb_Password.Text = objuser.Password;
                //    //Lb_Full_Name.Text = objuser.User_Full_Name;
                //    //Lb_Email.Text = objuser.Email;

                //    Tb_User_ID.Text = queryId.ToString();
                //    Tb_User_Name.Text = objuser.User_Name;
                //    Tb_Password.Text = objuser.Password;
                //    Tb_Full_Name.Text = objuser.User_Full_Name;
                //    Tb_Email.Text = objuser.Email;
                //  //  Add_Image.ImageUrl = objuser.User_Avata;
                //}
            }
        }
        //protected void Bnt_Edit_Click(object sender, EventArgs e)
        //{
        //    Tb_User_Name.Enabled = true;
        //    Tb_Password.Enabled = true;

        //    Tb_Full_Name.Enabled = true;
        //    Tb_Email.Enabled = true;
        //    Btn_Sua.Enabled = true;
        //}
        //protected void Bt_Sua_User_Click(object sender, EventArgs e)
        //{
        //    if (Tb_User_Name.Text != "" || Tb_Password.Text != "" || Tb_Full_Name.Text != "" || Tb_Email.Text != "")
        //    {
        //        queryId = Convert.ToInt32(Page.Session["userid"]);
        //        string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
        //        using (SqlConnection conn = new SqlConnection(strConnection))
        //        {

        //            SqlCommand cmd = new SqlCommand
        //            ("update Users set [User_Name]=@User_Name, [Password]=@Password, [User_Full_Name]=@User_Full_Name, [Email]=@Email, [User_Avata]= @User_Avata where User_ID=@User_ID", conn);
        //            conn.Open();
        //            cmd.Parameters.AddWithValue("@User_ID", queryId);
        //            cmd.Parameters.AddWithValue("@User_Name", Tb_User_Name.Text);
        //            cmd.Parameters.AddWithValue("@Password", Tb_Password.Text);
        //            cmd.Parameters.AddWithValue("@User_Full_Name", Tb_Full_Name.Text);
        //            cmd.Parameters.AddWithValue("@Email", Tb_Email.Text);
        //          //  cmd.Parameters.AddWithValue("@User_Avata", Add_Image.ImageUrl);
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //            Response.Redirect("../Home/ThongTinNguoiDung.aspx");

        //        }
        //    }
        //    else
        //    {
        //        Response.Write("<script>alert('Sửa that bai!!!: ') </script>");
        //    }

        //}

    }
}