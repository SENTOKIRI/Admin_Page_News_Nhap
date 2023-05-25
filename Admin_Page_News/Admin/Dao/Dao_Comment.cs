using Admin_Page_News.Admin.Entity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Admin_Page_News.Admin.Dao
{
    public class Dao_Comment
    {
        public static List<Obj_Comment> getAllComment()
        {
            List<Obj_Comment> lstcm = new List<Obj_Comment>();
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = " SELECT TB_Comment.CM_ID,TB_Comment.CM_Comment,News.News_Title,Users.User_Full_Name,TB_Comment.News_ID,TB_Comment.[User_ID],[CM_Email],TB_Comment.CM_Rep" +
                            " FROM TB_Comment LEFT OUTER JOIN News ON TB_Comment.News_ID = News.News_ID LEFT OUTER JOIN Users ON TB_Comment.[User_ID]= Users.[User_ID]" +
                            "  ORDER BY TB_Comment.CM_ID DESC";
                            

           
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_Comment objcm = null;
                while (sqlDataReader.Read())
                {
                    objcm = new Obj_Comment();
                    objcm.CM_ID = Convert.ToInt32(sqlDataReader["CM_ID"]);
                    objcm.User_ID = Convert.ToInt32(sqlDataReader["User_ID"]);
                    objcm.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objcm.User_Full_Name = Convert.ToString(sqlDataReader["User_Full_Name"]);
                    objcm.CM_Comment = Convert.ToString(sqlDataReader["CM_Comment"]);
                    objcm.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objcm.CM_Email = Convert.ToString(sqlDataReader["CM_Email"]);
                    objcm.CM_Rep = Convert.ToString(sqlDataReader["CM_Rep"]);
                    lstcm.Add(objcm);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstcm;
            }
        }
        public static Obj_Comment getCountComment(int _IDND)
        {

           
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            string strSQL = "SELECT COUNT(CM_Rep) AS bai_viet_chua_xem from TB_Comment where CM_Xem = 0 AND User_ID ="+_IDND+"";
;
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_Comment objnews = null;
                while (sqlDataReader.Read())
                {
                    objnews = new Obj_Comment();
                    objnews.bai_viet_chua_xem = Convert.ToInt32(sqlDataReader["bai_viet_chua_xem"]);

                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objnews;
            }
        }
        public static List<Obj_Comment> getContentCreatorComment( int userid)
        {
            List<Obj_Comment> lstcm = new List<Obj_Comment>();
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = " SELECT TB_Comment.CM_ID,TB_Comment.CM_Comment,News.News_Title,Users.User_Full_Name,TB_Comment.News_ID,TB_Comment.[User_ID],[CM_Email],TB_Comment.CM_Rep" +
                            " FROM TB_Comment LEFT OUTER JOIN News ON TB_Comment.News_ID = News.News_ID LEFT OUTER JOIN Users ON TB_Comment.[User_ID]= Users.[User_ID]" +
                            " Where TB_Comment.ID_Content_Creator= '" + userid + "' ORDER BY TB_Comment.CM_ID DESC";

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_Comment objcm = null;
                while (sqlDataReader.Read())
                {
                    objcm = new Obj_Comment();
                    objcm.CM_ID = Convert.ToInt32(sqlDataReader["CM_ID"]);
                    objcm.User_ID = Convert.ToInt32(sqlDataReader["User_ID"]);
                    objcm.News_ID = Convert.ToInt32(sqlDataReader["News_ID"]);
                    objcm.User_Full_Name = Convert.ToString(sqlDataReader["User_Full_Name"]);
                    objcm.CM_Comment = Convert.ToString(sqlDataReader["CM_Comment"]);
                    objcm.News_Title = Convert.ToString(sqlDataReader["News_Title"]);
                    objcm.CM_Email = Convert.ToString(sqlDataReader["CM_Email"]);
                    objcm.CM_Rep = Convert.ToString(sqlDataReader["CM_Rep"]);
                    lstcm.Add(objcm);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstcm;
            }
        }
    }
}