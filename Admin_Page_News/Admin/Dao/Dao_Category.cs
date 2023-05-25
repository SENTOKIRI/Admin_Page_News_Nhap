using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Admin_Page_News.Admin.Dao
{
    public class Dao_Category
    {
        public static List<Obj_Category> getAllCategory()
        {
            List<Obj_Category> lstcategory = new List<Obj_Category>();
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL =
            ("SELECT TB_Category.Category_ID,TB_Category.Category_Name,TB_Category.Category_Img, COUNT(Tag.Category_ID) AS Category_Count FROM TB_Category FULL JOIN Tag ON Tag.Category_ID = TB_Category.Category_ID GROUP BY TB_Category.Category_ID,TB_Category.Category_Name,TB_Category.Category_Img ORDER BY TB_Category.Category_ID DESC");
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_Category objcategory = null;
                while (sqlDataReader.Read())
                {
                    objcategory = new Obj_Category();
                    objcategory.Category_ID = Convert.ToInt32(sqlDataReader["Category_ID"]);
                    objcategory.Category_Name = Convert.ToString(sqlDataReader["Category_Name"]);
                    objcategory.Category_Count = Convert.ToInt32(sqlDataReader["Category_Count"]);
                    objcategory.Category_Img = Convert.ToString(sqlDataReader["Category_Img"]);
                    lstcategory.Add(objcategory);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstcategory;
            }
        }
        public static Obj_Category getIDCategory(int _idTag)
        {
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;

            string strSQL = "SELECT [Category_ID],[Category_Name] ,[Category_Img] FROM TB_Category Where Category_ID=@Category_ID  ";
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                sqlConnection.Open();

                sqlCommand.Parameters.AddWithValue("@Category_ID", _idTag);

                SqlDataReader reader = sqlCommand.ExecuteReader();
                Obj_Category objcategory = null;
                while (reader.Read())
                {
                    objcategory = new Obj_Category();
                    objcategory.Category_ID = Convert.ToInt32(reader["Category_ID"]);
                    objcategory.Category_Name = Convert.ToString(reader["Category_Name"]);
                    objcategory.Category_Img = Convert.ToString(reader["Category_Img"]);
                }
                reader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return objcategory;
            }
        }

        public static List<Obj_Category> getAllCategory_VS_Tag()
        {
            List<Obj_Category> lstcategory = new List<Obj_Category>();
            string strConnection = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL =
            ("SELECT TB_Category.Category_ID,TB_Category.Category_Name,TB_Category.Category_Img,Tag.Tag_ID,Tag.Tag_Name FROM TB_Category FULL JOIN Tag ON Tag.Category_ID = TB_Category.Category_ID GROUP BY TB_Category.Category_ID,TB_Category.Category_Name,TB_Category.Category_Img,Tag.Tag_ID,Tag.Tag_Name ORDER BY TB_Category.Category_ID DESC");
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand sqlCommand = new SqlCommand(strSQL, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                Obj_Category objcategory = null;
                while (sqlDataReader.Read())
                {
                    objcategory = new Obj_Category();
                    objcategory.Category_ID = Convert.ToInt32(sqlDataReader["Category_ID"]);
                    objcategory.Category_Name = Convert.ToString(sqlDataReader["Category_Name"]);
                    objcategory.Tag_ID = Convert.ToInt32(sqlDataReader["Tag_ID"]);
                    objcategory.Tag_Name = Convert.ToString(sqlDataReader["Tag_Name"]);
                    objcategory.Category_Img = Convert.ToString(sqlDataReader["Category_Img"]);
                    lstcategory.Add(objcategory);
                }
                sqlDataReader.Close();
                sqlConnection.Close();
                sqlConnection.Dispose();
                return lstcategory;
            }
        }
    }
}