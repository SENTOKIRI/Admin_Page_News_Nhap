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
    public partial class Singup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangky_Click(object sender, EventArgs e)
        {
            try
            {
                string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;

                string strSQL = "INSERT INTO Users([User_Name],[Password],[User_Full_Name],[Email],[Admin]) VALUES(@User_Name,@Password,@User_Full_Name,@Email,4)";
                using (SqlConnection sqlConnection = new SqlConnection(strConnection))
                {
                    SqlCommand cmd = new SqlCommand(strSQL, sqlConnection);
                    sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@User_Name", tb_User_Name.Text);
                    cmd.Parameters.AddWithValue("@Password", tb_Password.Text);
                    cmd.Parameters.AddWithValue("@User_Full_Name", tb_User_Full_Name.Text);
                    cmd.Parameters.AddWithValue("@Email", tb_Email.Text);
                    int rs = cmd.ExecuteNonQuery();

                    if (rs > 0)
                    {
                        Response.Write("<script>alert('Đăng ký tài khoản thành công!!!: ') </script>");
                        Response.Redirect("Login.aspx");
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }

                }
            }
            catch
            {
                Response.Write("<script>alert('Tài khoản đã được đăng ký!!!: ') </script>");
            }
        }
    }
}