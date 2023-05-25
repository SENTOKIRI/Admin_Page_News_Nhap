using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Admin_Page_News.Admin.Dao
{
    public class Dao_Tag
    {
        public static List<Obj_Tag> getAllTag()
        {
            List<Obj_Tag> lsttag = new List<Obj_Tag>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL =
            ("SELECT Tag.Tag_ID,Tag.Tag_Name,TB_Category.Category_Name,TB_Category.Category_ID, COUNT(News.Tag_ID) AS Tag_Count FROM  Tag FULL JOIN News ON Tag.Tag_ID=News.Tag_ID LEFT JOIN TB_Category ON Tag.Category_ID = TB_Category.Category_ID GROUP BY Tag.Tag_ID,Tag.Tag_Name,TB_Category.Category_Name,TB_Category.Category_ID ORDER BY Tag.Tag_ID DESC");
           
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
                Obj_Tag objtag = null;
                while (sqlDataReader.Read())
                {
                    objtag = new Obj_Tag();
                   
                    objtag.Tag_ID = Convert.ToInt32(sqlDataReader["Tag_ID"]);
                    objtag.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);
                    objtag.Tag_Count = Convert.ToInt32(sqlDataReader["Tag_Count"]);
                    objtag.Category_ID = Convert.ToInt32(sqlDataReader["Category_ID"]);
                    objtag.Category_Name = Convert.ToString(sqlDataReader["Category_Name"]);

                    lsttag.Add(objtag);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lsttag;
            }
        }
        public static List<Obj_Tag> getAllTagHome()
        {
            List<Obj_Tag> lsttag = new List<Obj_Tag>();
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = ("SELECT Tag_ID,Tag_Name FROM Tag ORDER BY Tag_Name ASC");
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {              
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_Tag objtag = null;
                while (sqlDataReader.Read())
                {
                    objtag = new Obj_Tag();
                    objtag.Tag_ID = Convert.ToInt32(sqlDataReader["Tag_ID"]);
                    objtag.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);               
                    lsttag.Add(objtag);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lsttag;
            }
        }
        public static Obj_Tag getIDTag(int _idTag)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;

            string strSQL = "SELECT [Tag_ID],[Tag_Name],TB_Category.Category_ID,TB_Category.Category_Name  FROM Tag LEFT JOIN TB_Category ON Tag.Category_ID = TB_Category.Category_ID where [Tag_ID]=@Tag_ID  GROUP BY Tag.Tag_ID,Tag.Tag_Name,TB_Category.Category_Name,TB_Category.Category_ID  ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue("@Tag_ID", _idTag);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_Tag objtag = null;
                while (reader.Read())
                {
                    objtag = new Obj_Tag();
                    
                    objtag.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objtag.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objtag.Category_ID = Convert.ToInt32(reader["Category_ID"]);
                    objtag.Category_Name = Convert.ToString(reader["Category_Name"]);
                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objtag;
            }
        }
        public static Obj_Tag getCountTag(int _idCountTag)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = " SELECT COUNT(News.Tag_ID) AS Tag_Count FROM Tag, News WHERE Tag.Tag_ID = News.Tag_ID AND Tag.Tag_ID =@Tag_ID ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Tag_ID", _idCountTag);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_Tag objtag = null;
                while (reader.Read())
                {
                    objtag = new Obj_Tag();             
                    objtag.Tag_Count = Convert.ToInt32(reader["Tag_Count"]);
                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objtag;
            }
        }
        public static List<Obj_Tag> getAllTagCategory( int ID)
        {
            List<Obj_Tag> lsttag = new List<Obj_Tag>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL =
            ("SELECT Tag.Tag_ID,Tag.Tag_Name,TB_Category.Category_Name,TB_Category.Category_ID, COUNT(News.Tag_ID) AS Tag_Count FROM  Tag FULL JOIN News ON Tag.Tag_ID=News.Tag_ID LEFT JOIN TB_Category ON Tag.Category_ID = TB_Category.Category_ID Where TB_Category.Category_ID='"+ID+"' GROUP BY Tag.Tag_ID,Tag.Tag_Name,TB_Category.Category_Name,TB_Category.Category_ID ORDER BY Tag.Tag_ID DESC");

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
                Obj_Tag objtag = null;
                while (sqlDataReader.Read())
                {
                    objtag = new Obj_Tag();

                    objtag.Tag_ID = Convert.ToInt32(sqlDataReader["Tag_ID"]);
                    objtag.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);
                    objtag.Tag_Count = Convert.ToInt32(sqlDataReader["Tag_Count"]);
                    objtag.Category_ID = Convert.ToInt32(sqlDataReader["Category_ID"]);
                    objtag.Category_Name = Convert.ToString(sqlDataReader["Category_Name"]);

                    lsttag.Add(objtag);
                }
                sqlDataReader.Close();//Đóng đối tượng DataReader
                sqlConnection.Close();//Đóng kết nối
                sqlConnection.Dispose();//Giải phóng bộ nhớ
                return lsttag;
            }
        }

        public static List<Obj_Tag> getAllTagCategoryChitiet(int _IDchitiet)
        {
            List<Obj_Tag> lsttag = new List<Obj_Tag>();
            //Lấy thông tin chuỗi kết nối từ Web.config
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            //Viết câu lệnh truy vấn
            string strSQL = " SELECT Tag.Tag_ID,Tag.Tag_Name,TB_Category.Category_Name,TB_Category.Category_ID " +
                            " FROM  Tag LEFT JOIN TB_Category ON Tag.Category_ID = TB_Category.Category_ID  Where Tag.Category_ID = "+ _IDchitiet + 
                            " GROUP BY Tag.Tag_ID,Tag.Tag_Name,TB_Category.Category_Name,TB_Category.Category_ID ORDER BY Tag.Tag_ID DESC ";

            //Định nghĩa đối tượng Connection
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                //Khởi tạo đối tượng Command
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();
                
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_Tag objtag = null;
                while (sqlDataReader.Read())
                {
                    objtag = new Obj_Tag();
                    objtag.Tag_ID = Convert.ToInt32(sqlDataReader["Tag_ID"]);
                    objtag.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);
                    objtag.Category_ID = Convert.ToInt32(sqlDataReader["Category_ID"]);
                    objtag.Category_Name = Convert.ToString(sqlDataReader["Category_Name"]);
                    lsttag.Add(objtag);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lsttag;
            }
        }

        public static Obj_Tag getIDCategoryTag(int _idTag1)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;

            string strSQL = " SELECT Tag.Tag_ID,Tag.Tag_Name,TB_Category.Category_Name,TB_Category.Category_ID " +
                            " FROM  Tag LEFT JOIN TB_Category ON Tag.Category_ID = TB_Category.Category_ID  Where Tag.Category_ID = " + _idTag1 +
                            " GROUP BY Tag.Tag_ID,Tag.Tag_Name,TB_Category.Category_Name,TB_Category.Category_ID ORDER BY Tag.Tag_ID DESC ";

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                //Mở kết nối tới CSDL
                sqlConnection.Open();

              //  sqlCommand.Parameters.AddWithValue("@Tag_ID", _idTag);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_Tag objtag = null;
                while (reader.Read())
                {
                    objtag = new Obj_Tag();

                    objtag.Tag_ID = Convert.ToInt32(reader["Tag_ID"]);
                    objtag.Tag_Name = Convert.ToString(reader["Tag_Name"]);
                    objtag.Category_ID = Convert.ToInt32(reader["Category_ID"]);
                    objtag.Category_Name = Convert.ToString(reader["Category_Name"]);
                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objtag;
            }
        }
    }
}