using Admin_Page_News.Admin.Entity;
using AjaxControlToolkit;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Admin_Page_News.Admin.Dao
{
    public class Dao_LichSu_Theodoi
    {
        public static List<Obj_News> getAllLichSu( int _userid)
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " WITH cte_1 AS(SELECT LichSu_ID, News_ID, User_ID, ROW_NUMBER() OVER (PARTITION BY News_ID, User_ID ORDER BY LichSu_ID  DESC ) row_num FROM  TB_Lichsu )   " +
                            " DELETE FROM cte_1 WHERE row_num > 1   " +
                            " SELECT News.News_ID,[News_Title],[News_Edit_Date],[News_Avata],[News_Views_Count]   " +
                            " FROM  TB_Lichsu full join News on News.News_ID = TB_Lichsu.News_ID  " +
                            " where TB_Lichsu.User_ID = @User_id ORDER BY LichSu_ID DESC  ";

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@User_id", _userid);
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
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);
                   
                   
                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }
        public static Obj_Lichsu_Theodoi update_lichsu (string _iduser,string _idnews)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            Obj_Lichsu_Theodoi objLS = null;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand("insert into TB_Lichsu (News_ID,User_ID) values (@News_ID,@User_ID)", conn);
                sqlCommand.Parameters.AddWithValue("@News_ID", Convert.ToInt32(_idnews));
                sqlCommand.Parameters.AddWithValue("@User_ID", Convert.ToInt32(_iduser));
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objLS = new Obj_Lichsu_Theodoi();
                    objLS.User_ID = Convert.ToInt32(reader["User_ID"]);
                    objLS.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objLS.LichSu_ID = Convert.ToInt32(reader["LichSu_ID"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objLS;
            }
        }

      


        //==============================THEO DOI=================================================//


        public static List<Obj_News> getAllTheoDoi(int _userid)
        {
            List<Obj_News> lstnews = new List<Obj_News>();
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            string strSQL = " WITH cte_1 AS(SELECT TheoDoi_ID, News_ID, User_ID, ROW_NUMBER() OVER (PARTITION BY News_ID, User_ID ORDER BY TheoDoi_ID  DESC ) row_num FROM  TB_Theodoi )   " +
                            " DELETE FROM cte_1 WHERE row_num > 1   " +
                            " SELECT News.News_ID,[News_Title],[News_Edit_Date],[News_Avata],[News_Views_Count]   " +
                            " FROM  TB_Theodoi full join News on News.News_ID = TB_Theodoi.News_ID  " +
                            " where TB_Theodoi.User_ID = @User_id ORDER BY TheoDoi_ID DESC  ";

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@User_id", _userid);
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
                    objnews.News_Views_Count = Convert.ToInt32(sqlDataReader["News_Views_Count"]);


                    lstnews.Add(objnews);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstnews;
            }
        }

        public static Obj_Lichsu_Theodoi update_theodoi(string _iduser, string _idnews)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            Obj_Lichsu_Theodoi objLS = null;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand("insert into TB_Theodoi (News_ID,User_ID) values (@News_ID,@User_ID)", conn);
                sqlCommand.Parameters.AddWithValue("@News_ID", Convert.ToInt32(_idnews));
                sqlCommand.Parameters.AddWithValue("@User_ID", Convert.ToInt32(_iduser));
                sqlCommand.CommandType = System.Data.CommandType.Text;

                conn.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    objLS = new Obj_Lichsu_Theodoi();
                    objLS.User_ID = Convert.ToInt32(reader["User_ID"]);
                    objLS.News_ID = Convert.ToInt32(reader["News_ID"]);
                    objLS.LichSu_ID = Convert.ToInt32(reader["LichSu_ID"]);
                }
                reader.Close();//Đóng đối tượng DataReader
                conn.Close();//Đóng kết nối
                conn.Dispose();//Giải phóng bộ nhớ
                return objLS;
            }
        }
    }
}