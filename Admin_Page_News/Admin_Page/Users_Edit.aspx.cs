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

namespace Admin_Page_News.Admin_Page
{
    public partial class WebForm1 : System.Web.UI.Page
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
                    
                    Session["User_ID"]= queryId.ToString();
                    Tb_User_Name.Text = objuser.User_Name;
                    Tb_Password.Text = objuser.Password;
                    Tb_User_Full_Name.Text = objuser.User_Full_Name;
                    Tb_Email.Text = objuser.Email;
                   // Cb_User_Admin.Checked= objuser.Admin_Int;
                    Cb_User_Admin.Checked = Convert.ToBoolean(objuser.Admin_Int);
                }
                else
                {

                }
               

            }
        }

            protected void Bt_Sua_User_Click(object sender, EventArgs e)
            {

            queryId = Convert.ToInt32(Page.Session["userid"]);

            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand
                    ("update Users set [User_Name]=@User_Name, [Password]=@Password, [User_Full_Name]=@User_Full_Name, [Email]=@Email where User_ID=@User_ID", conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@User_ID", queryId);
                    cmd.Parameters.AddWithValue("@User_Name", Tb_User_Name.Text);
                    cmd.Parameters.AddWithValue("@Password", Tb_Password.Text);
                    cmd.Parameters.AddWithValue("@User_Full_Name", Tb_User_Full_Name.Text);
                    cmd.Parameters.AddWithValue("@Email", Tb_Email.Text);
                    
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Write("<script>alert('Sửa thành công!!!: ') </script>");
                   
            }
            
        }
      

    }
}