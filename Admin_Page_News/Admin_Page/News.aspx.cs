using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Admin_Page_News
{
    public partial class WebForm3 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null)
            {
                Response.Redirect("../login.aspx");
            }
            else if (!Page.IsPostBack)
            {
                loadata();
            }

        }
        public void loadata()
        {
            //List<Obj_News> lstnews = Dao_News.getAllNews();
            //News_Table.DataSource = lstnews;
            //News_Table.DataBind();

            string constr = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = "SELECT [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID ORDER BY News_ID DESC";
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
        protected void News_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int index = Convert.ToInt32(e.RowIndex);
            int News_ID = Convert.ToInt32(News_Table.DataKeys[e.RowIndex].Value);

            string strSql = "Delete from News where  [News_ID] = " + News_ID.ToString();
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
            Response.Redirect("/Admin_Page/News.aspx");

        }

        protected void News_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int _id = Convert.ToInt32(News_Table.DataKeys[e.NewEditIndex].Value);
            Obj_News objnews = Dao_News.getIDNews(_id);
            string strId = objnews.News_ID.ToString();
            Response.Redirect("/Admin_Page/Add_News?News_ID=" + strId);

        }

        protected void News_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            News_Table.PageIndex = e.NewPageIndex;
            loadata();

            //List<Obj_News> lstnews = Dao_News.getAllNews();
            //News_Table.DataSource = lstnews;
            //News_Table.DataBind();
        }

        protected void Bnt_Seach_Click(object sender, EventArgs e)
        {
            //List<Obj_News> lstnews = Dao_News.get_Title_News(Tb_Seach.Text.Trim());
            //News_Table.DataSource = lstnews;
            //News_Table.DataBind();
            string constr = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            string strSQL = "SELECT [News_ID],[News_Title],[News_Create_Date],[News_Edit_Date],[News_Avata],[News_Views_Count],[News_Avata],[News_Hot],[News_Status],Tag.Tag_Name,News.Tag_ID  FROM News,Tag Where News.Tag_ID=Tag.Tag_ID and [News_Title] LIKE N'%" + Tb_Seach.Text.Trim() + "%' ORDER BY News_ID DESC";
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

        protected void Bnt_Reset_Click(object sender, EventArgs e)
        {
            Tb_Seach.Text = null;
            loadata();
           
        }
        protected void Save(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["NEWS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "update News set News_Status=@News_Status,News_Hot=@News_Hot  where News_ID=@News_ID";                   
                    cmd.Connection = con;
                    con.Open();
                    foreach (GridViewRow row in News_Table.Rows)
                    {
                        //Get the HobbyId from the DataKey property.
                        int News_ID = Convert.ToInt32(News_Table.DataKeys[row.RowIndex].Values);

                        //Get the checked value of the CheckBox.
                        bool News_Hot = (row.FindControl("CB_Hot") as CheckBox).Checked;
                        bool News_Status = (row.FindControl("CB_Status") as CheckBox).Checked;
                        //Save to database.
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@News_ID", News_ID);
                        cmd.Parameters.AddWithValue("@News_Hot", News_Hot);
                        cmd.Parameters.AddWithValue("@News_Status",News_Status);
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                    Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }

    }
}