using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Admin_Page_News.Admin.Dao
{
    public class Dao_News
    {
        public static List<Obj_News> getAllNews()
        {
            List<Obj_News> lstnews = new List<Obj_News>();          
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;          
            string strSQL = "SELECT [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID ORDER BY News_ID DESC";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {               
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;              
                sqlConnection.Open();               
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Create_Date= Convert.ToDateTime(sqlDataReader["News_Create_Date"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                    objnews.Tag_ID = Convert.ToInt32(sqlDataReader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> getAllNewsStatus()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = "SELECT [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and [News_Status]='1' ORDER BY News_ID DESC";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Create_Date = Convert.ToDateTime(sqlDataReader["News_Create_Date"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                    objnews.Tag_ID = Convert.ToInt32(sqlDataReader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> getAllNewsAdmin()
        {
            List<Obj_News> lstnews = new List<Obj_News>();         
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;           
            string strSQL = "SELECT [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Hot]= (CASE[News_Hot] WHEN 'true' THEN N'YES' WHEN 'false' THEN N'NO' END),[News_Status]=(CASE[News_Status] WHEN 'true' THEN N'Đăng' WHEN 'false' THEN N'Không đăng' END),Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID ORDER BY News_ID DESC";          
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {              
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;               
                sqlConnection.Open();              
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);                
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                   
                    objnews.News_Hot_str = Convert.ToString(sqlDataReader["News_Hot"]);
                    objnews.News_Create_Date = Convert.ToDateTime(sqlDataReader["News_Create_Date"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    
                    objnews.News_Status_str = Convert.ToString(sqlDataReader["News_Status"]);
                    objnews.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static Obj_News getIDNews(int _id)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string strSQL = " SELECT [News_ID],[News_Title],[News_Content],[News_Avata],[News_Edit_Date],[News_Views_Count],[News_Status],[News_Hot],[News_Comment],News.[Tag_ID],Tag.[Tag_Name] ,TB_Category.Category_ID,TB_Category.Category_Name,Users.User_Name,News.User_ID " +
                            " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category on Tag.Category_ID = TB_Category.Category_ID left join Users on News.User_ID = Users.User_ID Where [News_ID] = @News_ID";


            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue("@News_ID", _id);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);                  
                    objnews.News_Title = Convert.ToString(reader["News_Title"]);
                    objnews.News_Avata = Convert.ToString(reader["News_Avata"]);
                    objnews.News_Content = Convert.ToString(reader["News_Content"]);
                    objnews.News_Status = Convert.ToInt32(reader["News_Status"]);
                    objnews.News_Views_Count = Convert.ToInt32(reader["News_Views_Count"]);
                    objnews.News_Hot = Convert.ToInt32(reader["News_Hot"]);
                    objnews.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(reader["News_Edit_Date"]);
                    objnews.News_Comment = Convert.ToString(reader["News_Comment"]);
                    objnews.Category_ID= Convert.ToInt32(reader["Category_ID"]);
                    objnews.Category_Name = Convert.ToString(reader["Category_Name"]);
                    objnews.User_ID = Convert.ToInt32(reader["User_ID"]);
                    objnews.User_Name = Convert.ToString(reader["User_Name"]);


                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objnews;
            }
        }
        public static List<Obj_News> get6News()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT Top 6 [News_ID],[News_Title],Tag_Name,[News_Edit_Date],[News_Avata],[News_Hot],[News_Status]  FROM News left join Tag on News.Tag_ID = Tag.Tag_ID    Where News_Hot='1' and [News_Status]='1' ORDER BY News_ID DESC";
            //Định nghĩa đối tượng Connection
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                //Khởi tạo đối tượng Command
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                //Sử dụng đối tượng DataReader để đọc dữ liệu
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                   
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lstnews;
            }
        }
        public static List<Obj_News> get5News()
        {
            List<Obj_News> lstnews = new List<Obj_News>();          
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;           
            string strSQL = "SELECT Top 4 [News_ID],[News_Title],[News_Edit_Date],[News_Avata],[News_Hot],[News_Status]  FROM News Where News_Hot='1' and [News_Status]='1' ORDER BY News_ID DESC";          
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {              
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;               
                sqlConnection.Open();               
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> get_ID_Tag_News(int _id)
        {
            List<Obj_News> lstobjnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = "SELECT [News_ID],[News_Title],[News_Content],[News_Avata],[News_Edit_Date],[News_Views_Count],[News_Status], News.[Tag_ID],Tag.[Tag_Name]   FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and Tag.Tag_ID=@Tag_ID ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Tag_ID", _id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objnews.News_Title = Convert.ToString(reader["News_Title"]);
                    objnews.News_Avata = Convert.ToString(reader["News_Avata"]);
                    objnews.News_Content = Convert.ToString(reader["News_Content"]);
                    objnews.News_Status = Convert.ToInt32(reader["News_Status"]);
                    objnews.News_Views_Count = Convert.ToInt32(reader["News_Views_Count"]);
                    objnews.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(reader["News_Edit_Date"]);
                    lstobjnews.Add(objnews);

                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstobjnews;
            }
        }
        public static List<Obj_News> get_ID_Tag_News_1(int _id)
        {
            List<Obj_News> lstobjnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = "SELECT TOP 8 [News_ID],[News_Title],[News_Avata],[News_Edit_Date],[News_Status], News.[Tag_ID],Tag.[Tag_Name]   FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and Tag.Tag_ID=@Tag_ID  ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Tag_ID", _id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objnews.News_Title = Convert.ToString(reader["News_Title"]);
                    objnews.News_Avata = Convert.ToString(reader["News_Avata"]);
                    objnews.News_Status = Convert.ToInt32(reader["News_Status"]);
                    objnews.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(reader["News_Edit_Date"]);
                    lstobjnews.Add(objnews);

                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstobjnews;
            }
        }
        public static Obj_News getCountAllNews()
        {
           
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = "SELECT COUNT(News_ID) AS Tong_Bai_Viet from News ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                //Khởi tạo đối tượng Command
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                //Sử dụng đối tượng DataReader để đọc dữ liệu
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.Tong_Bai_Viet = Convert.ToInt32(sqlDataReader["Tong_Bai_Viet"]);
                    
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return objnews;
            }
        }
        public static Obj_News getTittleNews(string _title)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = "SELECT [News_ID],[News_Title],[News_Content],[News_Avata],[News_Edit_Date],[News_Views_Count],[News_Status], News.[Tag_ID],Tag.[Tag_Name]   FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and [News_Title] like '%@News_Title%' and [News_Status]='1'";
            
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@News_Title", _title);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objnews.News_Title = Convert.ToString(reader["News_Title"]);
                    objnews.News_Avata = Convert.ToString(reader["News_Avata"]);
                    objnews.News_Content = Convert.ToString(reader["News_Content"]);
                    objnews.News_Status = Convert.ToInt32(reader["News_Status"]);
                    objnews.News_Views_Count = Convert.ToInt32(reader["News_Views_Count"]);
                    objnews.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(reader["News_Edit_Date"]);


                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objnews;
            }
        }
        public static List<Obj_News> get_Title_News(string _title)
        {
            List<Obj_News> lstobjnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = "SELECT [News_ID],[News_Title],[News_Avata],[News_Edit_Date],[News_Status],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and [News_Title] LIKE N'%" + _title + "%' and [News_Status]='1' ORDER BY News_ID DESC ";

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;          
                sqlConnection.Open();
                //sqlCommand.Parameters.AddWithValue("@News_Title", _title);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);                 
                    objnews.News_Avata = Convert.ToString(reader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(reader["News_Title"]);
                    objnews.News_Status = Convert.ToInt32(reader["News_Status"]);
                    objnews.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(reader["News_Edit_Date"]);
                    lstobjnews.Add(objnews);

                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstobjnews;
            }
        }
        public static Obj_News updateview(int _id)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = "UPDATE News SET News_Views_Count = (News_Views_Count+1)  where News_ID=@News_ID";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@News_ID", _id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objnews.News_Views_Count = Convert.ToInt32(reader["News_Views_Count"]);
                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objnews;
            }
        }



        ///===============================TEST=======================================///
        ///==============LUOT XEM====================/
        public static List<Obj_News> get4News()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT  [News_ID],[News_Title],[News_Edit_Date],[News_Avata],[News_Hot],[News_Status] ,News_Views_Count " +
                            " FROM News Where News_Hot = '1' and[News_Status] = '1' ORDER BY News_ID DESC OFFSET 1 ROWS FETCH NEXT 4 ROWS ONLY ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> get1News()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT top 1 [News_ID],[News_Title],[News_Edit_Date],[News_Avata],[News_Hot],[News_Status] ,News_Views_Count " +
                            " FROM News Where News_Hot = '1' and[News_Status] = '1' ORDER BY News_ID DESC ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> getAll9News()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = "SELECT TOP(9) [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and [News_Status]='1' ORDER BY News_ID DESC";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Create_Date = Convert.ToDateTime(sqlDataReader["News_Create_Date"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                    objnews.Tag_ID = Convert.ToInt32(sqlDataReader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> getAllNewsXemNhieu()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT TOP(10) ROW_NUMBER() OVER(ORDER BY News_Views_Count DESC) AS [STT],[News_ID],[News_Title],[News_Edit_Date],[News_Avata],[News_Hot],[News_Status] ,News_Views_Count "+
                            " FROM News Where News_Hot = '1' and[News_Status] = '1'";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                    objnews.STT = Convert.ToInt32(sqlDataReader["STT"]);
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> get3NewsXaHoi()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT top 3 [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID,TB_Category.Category_ID " +
                            " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category ON Tag.Category_ID = TB_Category.Category_ID where TB_Category.Category_ID = 1 and News_Status = 1 ORDER BY News_ID DESC";
   
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                   
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> get3NewsTheThao()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT top 3 [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID,TB_Category.Category_ID " +
                            " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category ON Tag.Category_ID = TB_Category.Category_ID where TB_Category.Category_ID = 2 and News_Status = 1 ORDER BY News_ID DESC";
            ;
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                   
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> get3NewsKinhTe()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT top 3 [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID,TB_Category.Category_ID " +
                            " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category ON Tag.Category_ID = TB_Category.Category_ID where TB_Category.Category_ID = 3 and News_Status = 1 ORDER BY News_ID DESC";
            ;
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                  
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> get3NewsGiaoDuc()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT top 3 [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID,TB_Category.Category_ID " +
                            " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category ON Tag.Category_ID = TB_Category.Category_ID where TB_Category.Category_ID = 5 and News_Status = 1 ORDER BY News_ID DESC";
            ;
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                   
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> get3NewsCongNghe()
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT top 3 [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID,TB_Category.Category_ID " +
                            " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category ON Tag.Category_ID = TB_Category.Category_ID where TB_Category.Category_ID = 6 and News_Status = 1 ORDER BY News_ID DESC";
            ;
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objnews.News_Avata = Convert.ToString(sqlDataReader["News_Avata"]);
                    objnews.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objnews.News_Hot = Convert.ToInt32(sqlDataReader["News_Hot"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(sqlDataReader["News_Edit_Date"]);
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                    objnews.News_Status = Convert.ToInt32(sqlDataReader["News_Status"]);
                   
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static List<Obj_News> get_Id_Tag_News_ds(int _id)
        {
            List<Obj_News> lstobjnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT [News_ID],[News_Title],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID,TB_Category.Category_ID,TB_Category.Category_Name " +
                            " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category ON Tag.Category_ID = TB_Category.Category_ID where News.Tag_ID = @Tag_ID and News_Status = 1 ORDER BY News_ID DESC";

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Tag_ID", _id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objnews.News_Title = Convert.ToString(reader["News_Title"]);
                    objnews.News_Avata = Convert.ToString(reader["News_Avata"]);
                    objnews.News_Status = Convert.ToInt32(reader["News_Status"]);
                    objnews.News_Views_Count = Convert.ToInt32(reader["News_Views_Count"]);
                    objnews.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objnews.Category_ID = Convert.ToInt32(reader["Category_ID"]);
                    objnews.Category_Name = Convert.ToString(reader["Category_Name"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(reader["News_Edit_Date"]);
                    lstobjnews.Add(objnews);

                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstobjnews;
            }
        }
        public static List<Obj_News> get_Id_Category_News_ds(int _id)
        {
            List<Obj_News> lstobjnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT [News_ID],[News_Title],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID,TB_Category.Category_ID,TB_Category.Category_Name " +
                            " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category ON Tag.Category_ID = TB_Category.Category_ID where Tag.Category_ID = @Category_ID and News_Status = 1 ORDER BY News_ID DESC";

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Category_ID", _id);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objnews.News_Title = Convert.ToString(reader["News_Title"]);
                    objnews.News_Avata = Convert.ToString(reader["News_Avata"]);
                    objnews.News_Status = Convert.ToInt32(reader["News_Status"]);
                    objnews.News_Views_Count = Convert.ToInt32(reader["News_Views_Count"]);
                    objnews.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objnews.Category_ID = Convert.ToInt32(reader["Category_ID"]);
                    objnews.Category_Name = Convert.ToString(reader["Category_Name"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(reader["News_Edit_Date"]);
                    lstobjnews.Add(objnews);

                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstobjnews;
            }
        }
        public static List<Obj_News> getIDUserNews(int _id)
        {
            List<Obj_News> lstobjnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
             string strSQL = " SELECT [News_ID],[News_Title],[News_Content],[News_Avata],[News_Edit_Date],[News_Views_Count],[News_Status],[News_Hot],[News_Comment],News.[Tag_ID],Tag.[Tag_Name] ,TB_Category.Category_ID,TB_Category.Category_Name,Users.User_Name,News.User_ID " +
                            " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category on Tag.Category_ID = TB_Category.Category_ID left join Users on News.User_ID = Users.User_ID Where News.User_ID = @User_ID and News.News_Status = 1";


            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue("@User_ID", _id);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objnews.News_Title = Convert.ToString(reader["News_Title"]);
                    objnews.News_Avata = Convert.ToString(reader["News_Avata"]);
                    objnews.News_Content = Convert.ToString(reader["News_Content"]);
                    objnews.News_Status = Convert.ToInt32(reader["News_Status"]);
                    objnews.News_Views_Count = Convert.ToInt32(reader["News_Views_Count"]);
                    objnews.News_Hot = Convert.ToInt32(reader["News_Hot"]);
                    objnews.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(reader["News_Edit_Date"]);
                    objnews.News_Comment = Convert.ToString(reader["News_Comment"]);
                    objnews.Category_ID = Convert.ToInt32(reader["Category_ID"]);
                    objnews.Category_Name = Convert.ToString(reader["Category_Name"]);
                    objnews.User_ID = Convert.ToInt32(reader["User_ID"]);
                    objnews.User_Name = Convert.ToString(reader["User_Name"]);
                    lstobjnews.Add(objnews);

                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstobjnews;
            }
        }
        public static List<Obj_News> getIDUserNewsTest(int _id)
        {
            List<Obj_News> lstobjnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " SELECT TOP 6 [News_ID],[News_Title],[News_Content],[News_Avata],[News_Edit_Date],[News_Views_Count],[News_Status],[News_Hot],[News_Comment],News.[Tag_ID],Tag.[Tag_Name] ,TB_Category.Category_ID,TB_Category.Category_Name,Users.User_Name,News.User_ID " +
                           " FROM News left join Tag on News.Tag_ID = Tag.Tag_ID left join TB_Category on Tag.Category_ID = TB_Category.Category_ID left join Users on News.User_ID = Users.User_ID Where News.User_ID = @User_ID";


            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue("@User_ID", _id);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_News objnews = null;
                while (reader.Read())
                {
                    objnews = new Obj_News();
                    objnews.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objnews.News_Title = Convert.ToString(reader["News_Title"]);
                    objnews.News_Avata = Convert.ToString(reader["News_Avata"]);
                    objnews.News_Content = Convert.ToString(reader["News_Content"]);
                    objnews.News_Status = Convert.ToInt32(reader["News_Status"]);
                    objnews.News_Views_Count = Convert.ToInt32(reader["News_Views_Count"]);
                    objnews.News_Hot = Convert.ToInt32(reader["News_Hot"]);
                    objnews.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objnews.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objnews.News_Edit_Date = Convert.ToDateTime(reader["News_Edit_Date"]);
                    objnews.News_Comment = Convert.ToString(reader["News_Comment"]);
                    objnews.Category_ID = Convert.ToInt32(reader["Category_ID"]);
                    objnews.Category_Name = Convert.ToString(reader["Category_Name"]);
                    objnews.User_ID = Convert.ToInt32(reader["User_ID"]);
                    objnews.User_Name = Convert.ToString(reader["User_Name"]);
                    lstobjnews.Add(objnews);

                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstobjnews;
            }
        }

        ///==============END LUOT XEM====================/
    }
}