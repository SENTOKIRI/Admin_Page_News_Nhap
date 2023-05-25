using Admin_Page_News.Admin.Dao;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Page_News.Admin.Entity;

namespace Admin_Page_News.Home
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

               
                footerdata();
                name_user();
               
            }       
        }
        
        private void footerdata()
        {
            List<Obj_Tag> objtag1 = Dao_Tag.getAllTagHome();
            DDL_The_Loai.DataSource = objtag1;   
            DDL_The_Loai.DataBind();

            List<Obj_Category> lstcategory = Dao_Category.getAllCategory();
            DDL_Chuyen_Muc.DataSource = lstcategory;
            DDL_Chuyen_Muc.DataBind();
        }

        private void name_user()
        {
            if (Session["name"] != null)
            {

                lb_User_Name.Text = Convert.ToString(Session["name"]).ToString();
            }
            else
            {

                lb_User_Name.Text = "Tài khoản";
            }
        }
        protected void DDL_The_Loai_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Tag_ID_1")
            {
                int _idTag = Convert.ToInt32(DDL_The_Loai.DataKeys[e.Item.ItemIndex].ToString());            
                Obj_Tag objtag2 = Dao_Tag.getIDTag(_idTag);
                string str_Id = objtag2.Tag_ID.ToString();
                Response.Redirect("/Home/dschuyenmuc?Tag_ID=" + str_Id);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        //protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    if (e.CommandName == "Tag_ID_2")
        //    {
        //        int _id = Convert.ToInt32(DDL_The_Loai.DataKeys[e.Item.ItemIndex].ToString());
        //        Obj_Tag objtag2 = Dao_Tag.getIDTag(_id);
        //        string str_Id = objtag2.Tag_ID.ToString();
        //        Response.Redirect("../Home/dschuyenmuc?Tag_ID=" + str_Id);
        //    }
        //    else
        //    {
        //        Response.Redirect("../Default.aspx");
        //    }
        //}

        protected void Bnt_Seach_Click1(object sender, EventArgs e)
        {
            if (Tb_Seach.Text == "")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                string title_news = Tb_Seach.Text.ToString().Trim();
                Response.Redirect("~/Home/timkiemtin?News_Title=" + title_news);
            }
        }

        protected void News_24H_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void DDL_Chuyen_Muc_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "chuyenmuc")
            {
                int _id1 = Convert.ToInt32(DDL_Chuyen_Muc.DataKeys[e.Item.ItemIndex].ToString());
                Obj_Category objcategory = Dao_Category.getIDCategory(_id1);
                string str_Id2 = objcategory.Category_ID.ToString();
                Response.Redirect("/Home/dschuyenmuc?Category_ID="+str_Id2);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        
    }
}