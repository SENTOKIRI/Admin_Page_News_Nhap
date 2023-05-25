using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News.Content_Creator
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        
        int user_id = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            if (!Page.IsPostBack)
            {
                loadata();
                ddl_data();
            }
        }
        public void loadata()
        {
            string ten = Convert.ToString(Session["fullname"]).ToString();
            Label1.Text = ten;
            user_id = Convert.ToInt32(Session["userid"]);
            string constr = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = "SELECT [News_ID],[News_Title],[News_Create_Date],[News_Avata],[News_Avata],[News_Hot],[News_Status],[News_Duyet],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and User_ID = '"+ user_id +"' ORDER BY News_ID DESC";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(strSQL))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            News_Table.DataSource = dt;
                            News_Table.DataBind();
                        }
                    }
                }
            }
        }
        private void ddl_data()
        {
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string com = "Select Tag_ID,Tag_Name from Tag Order by Tag_Name ASC";
                SqlDataAdapter adpt = new SqlDataAdapter(com, conn);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                DDL_Tag.DataSource = dt;
                DDL_Tag.DataBind();
                DDL_Tag.DataTextField = "Tag_Name";
                DDL_Tag.DataValueField = "Tag_ID";
                DDL_Tag.DataBind();               
                DDL_Tag.Items.Insert(0, new ListItem("Thể loại", "0") );
                                          
            }

        }
        protected void News_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int News_ID = Convert.ToInt32(News_Table.DataKeys[e.RowIndex].Value);

            string strSql = "Delete from News where  [News_ID] = " + News_ID.ToString()+"and [News_Status] = '0' ";
            string strConnection = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                SqlCommand cmd = new SqlCommand(strSql, sqlConnection);
                cmd.CommandType = System.Data.CommandType.Text;
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
            Response.Redirect("/Content_Creator/list_news.aspx");

        }
        protected void News_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(News_Table.DataKeys[e.NewEditIndex].Value);
            Obj_News objnews = Dao_News.getIDNews(_id);
            string strId = objnews.News_ID.ToString();
            string strTagId = objnews.Tag_ID.ToString();
            Response.Redirect("/Content_Creator/create_news?News_ID=" + strId+ "&&Tag_ID="+strTagId);
        }
        protected void News_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            News_Table.PageIndex = e.NewPageIndex;
            loadata();
        }      
        protected void DDL_Tag_SelectedIndexChanged(object sender, EventArgs e)
        {
            user_id = Convert.ToInt32(Session["userid"]);
            int queryTagId = Convert.ToInt32(DDL_Tag.SelectedValue);
            if (queryTagId == 0)
            {
                loadata();
            }
            else
            {
                string constr = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
                string strSQL = "SELECT [News_ID],[News_Title],[News_Create_Date],[News_Avata],[News_Duyet],[News_Status],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and News.Tag_ID='" + queryTagId + "' and User_ID ='" + user_id + "' ORDER BY News_ID DESC";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(strSQL))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                News_Table.DataSource = dt;
                                News_Table.DataBind();
                            }
                        }
                    }
                }
            }

        }       
        protected void News_Table_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int _id = Convert.ToInt32(News_Table.DataKeys[e.NewSelectedIndex].Value);
            Obj_News objnews = Dao_News.getIDNews(_id);
            string strId = objnews.News_ID.ToString();
            Response.Redirect("/Content_Creator/Show_News?News_ID=" + strId);
        }
        protected void DDL_Bai_Viet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddl_data();
            user_id = Convert.ToInt32(Session["userid"]);
            string constr = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            int baiviet = Convert.ToInt32(DDL_Bai_Viet.SelectedValue);
            if (baiviet == 1)
            {
                loadata();
                ddl_data();
            }
            else if(baiviet == 2)
            {
                string strSQL = "SELECT [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],[News_Duyet],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and News_Duyet = '1' and User_ID ='" + user_id + "' ORDER BY News_ID DESC";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(strSQL))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                News_Table.DataSource = dt;
                                News_Table.DataBind();
                            }
                        }
                    }
                }
            }
            else
            {
                string strSQL = "SELECT [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],[News_Duyet],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and News_Duyet = '0' and User_ID ='" + user_id + "' ORDER BY News_ID DESC";
                using (SqlConnection con = new SqlConnection(constr))
                {
                    using (SqlCommand cmd = new SqlCommand(strSQL))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.Connection = con;
                            sda.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                sda.Fill(dt);
                                News_Table.DataSource = dt;
                                News_Table.DataBind();
                            }
                        }
                    }
                }
            }
        }
    }
}