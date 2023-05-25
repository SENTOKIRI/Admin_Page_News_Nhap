using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Admin_Page_News.Admin.Dao
{
    public class Dao_User
    {
        public static List<Obj_User> getAllUser(int _id_User)
        {
            List<Obj_User> lstuser = new List<Obj_User>();
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = "SELECT [User_ID], [User_Name],[Password],[User_Full_Name],[Email],[Admin]= (CASE[Admin] WHEN '1' THEN N'Tổng biên tập' WHEN '2' THEN N'Biên tập viên'  WHEN '3' THEN N'Cộng tác viên' WHEN '4' THEN N'Người dùng' END) FROM Users WHERE NOT [User_ID] = @User_ID";
            //string strSQL = "SELECT[User_ID], [User_Name],[Password],[User_Full_Name],[Email],[Admin] FROM Users";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@User_ID", _id_User);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_User objuser = null;
                while (sqlDataReader.Read())
                {
                    objuser = new Obj_User();
                    objuser.User_ID = Convert.ToInt32(sqlDataReader["User_ID"]);
                    objuser.User_Name = Convert.ToString(sqlDataReader["User_Name"]);
                    objuser.Password = Convert.ToString(sqlDataReader["Password"]);
                    objuser.User_Full_Name = Convert.ToString(sqlDataReader["User_Full_Name"]);
                    objuser.Email = Convert.ToString(sqlDataReader["Email"]);
                    objuser.Admin = Convert.ToString(sqlDataReader["Admin"]);
                    lstuser.Add(objuser);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstuser;
            }
        }
        public static Obj_User getIDUser(int _id)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;

            string strSQL = "SELECT [User_ID], [User_Name],[Password],[User_Full_Name],[Email],[Admin],[User_Avata] FROM Users Where  [User_ID]=@User_ID ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue("@User_ID", _id);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_User objuser = null;
                while (sqlDataReader.Read())
                {
                    objuser = new Obj_User();
                    objuser.User_ID = Convert.ToInt32(sqlDataReader["User_ID"]);
                    objuser.User_Name = Convert.ToString(sqlDataReader["User_Name"]);
                    objuser.Password = Convert.ToString(sqlDataReader["Password"]);
                    objuser.User_Full_Name = Convert.ToString(sqlDataReader["User_Full_Name"]);
                    objuser.Email = Convert.ToString(sqlDataReader["Email"]);
                    objuser.Admin_Int = Convert.ToInt32(sqlDataReader["Admin"]);
                    objuser.User_Avata = Convert.ToString(sqlDataReader["User_Avata"]);

                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objuser;
            }
        }
        public static Obj_User GetOneUser(string _taikhoan, string _matkhau)
        {
            Obj_User objUser = null;
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string sql = "SELECT [User_ID], [User_Name], [User_Full_Name],[Password],[Admin], [User_Avata],[Email] FROM Users where [User_Name]=@User_Name  and [Password]=@Password";
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.Add("@User_Name", System.Data.SqlDbType.VarChar).Value = _taikhoan;
             //   sqlCommand.Parameters.Add("@Email", System.Data.SqlDbType.VarChar).Value = _taikhoan;
                sqlCommand.Parameters.Add("@Password", System.Data.SqlDbType.VarChar).Value = _matkhau;
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objUser = new Obj_User();
                    objUser.User_ID = Convert.ToInt32(reader["User_ID"]);
                    objUser.User_Name = Convert.ToString(reader["User_Name"]);
                    objUser.Password = Convert.ToString(reader["Password"]);
                    objUser.User_Full_Name = Convert.ToString(reader["User_Full_Name"]);
                    objUser.Admin_Int = Convert.ToInt32(reader["Admin"]);
                    objUser.User_Avata = Convert.ToString(reader["User_Avata"]);
                    objUser.Email = Convert.ToString(reader["Email"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objUser;
            }

        }
        public static Obj_User CheckIDUser(int _id)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;

            string strSQL = "SELECT [User_ID], [Admin] FROM Users Where  [User_ID]=@User_ID ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue("@User_ID", _id);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_User objuser = null;
                while (sqlDataReader.Read())
                {
                    objuser = new Obj_User();
                    objuser.User_ID = Convert.ToInt32(sqlDataReader["User_ID"]);

                    objuser.Admin_Int = Convert.ToInt32(sqlDataReader["Admin"]);

                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objuser;
            }
        }
        public static List<Obj_User> getUserSeach(string userseach, int _id_User)
        {
            List<Obj_User> lstuser = new List<Obj_User>();
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = "SELECT [User_ID], [User_Name],[Password],[User_Full_Name],[Email],[Admin]= (CASE[Admin] WHEN '1' THEN N'Tổng biên tập' WHEN '2' THEN N'Biên tập viên'  WHEN '3' THEN N'Cộng tác viên' WHEN '4' THEN N'Người dùng' END) FROM Users WHERE [User_Full_Name] LIKE N'%" + userseach + "%' and NOT [User_ID] = @User_ID";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@User_ID", _id_User);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_User objuser = null;
                while (sqlDataReader.Read())
                {
                    objuser = new Obj_User();
                    objuser.User_ID = Convert.ToInt32(sqlDataReader["User_ID"]);
                    objuser.User_Name = Convert.ToString(sqlDataReader["User_Name"]);
                    objuser.Password = Convert.ToString(sqlDataReader["Password"]);
                    objuser.User_Full_Name = Convert.ToString(sqlDataReader["User_Full_Name"]);
                    objuser.Email = Convert.ToString(sqlDataReader["Email"]);
                    objuser.Admin = Convert.ToString(sqlDataReader["Admin"]);
                    lstuser.Add(objuser);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstuser;
            }
        }
        public static List<Obj_User> getIDPqUser(int _iduser, int _admin)
        {
            List<Obj_User> lstuser = new List<Obj_User>();
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = "SELECT [User_ID], [User_Name],[Password],[User_Full_Name],[Email],[Admin]= (CASE[Admin] WHEN '1' THEN N'Tổng biên tập' WHEN '2' THEN N'Biên tập viên'  WHEN '3' THEN N'Cộng tác viên' WHEN '4' THEN N'Người dùng' END),[User_Avata] FROM Users Where [Admin]=@Admin and NOT [User_ID] = @User_ID ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
                {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@User_ID", _iduser);
                sqlCommand.Parameters.AddWithValue("@Admin", _admin);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    Obj_User objuser = null;
                    while (sqlDataReader.Read())
                    {
                        objuser = new Obj_User();
                        objuser.User_ID = Convert.ToInt32(sqlDataReader["User_ID"]);
                        objuser.User_Name = Convert.ToString(sqlDataReader["User_Name"]);
                        objuser.Password = Convert.ToString(sqlDataReader["Password"]);
                        objuser.User_Full_Name = Convert.ToString(sqlDataReader["User_Full_Name"]);
                        objuser.Email = Convert.ToString(sqlDataReader["Email"]);
                        objuser.Admin = Convert.ToString(sqlDataReader["Admin"]);
                        lstuser.Add(objuser);
                    }
                    sqlDataReader.Close();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                    return lstuser;
                }
            }
        }


    }

      
