using Admin_Page_News.Admin.Dao;
using Admin_Page_News.Admin.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebGrease;

namespace Admin_Page_News
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                loaddata();
            }
        }

        public void loaddata()
        {
            List<Obj_News> lstnewshot1 = Dao_News.get4News();
            LV_Right.DataSource = lstnewshot1;
            LV_Right.DataBind();

            List<Obj_News> lstnewshot2 = Dao_News.get1News();
            LV_Left.DataSource = lstnewshot2;
            LV_Left.DataBind();

            List<Obj_News> lstnewshot3 = Dao_News.getAll9News();
            LV_News_All.DataSource = lstnewshot3;
            LV_News_All.DataBind();

            List<Obj_News> lstnewshot4 = Dao_News.getAllNewsXemNhieu();
            LV_Xem_Nhieu.DataSource = lstnewshot4;
            LV_Xem_Nhieu.DataBind();

            List<Obj_News> listxahoi = Dao_News.get3NewsXaHoi();
            LV_Xahoi.DataSource = listxahoi;
            LV_Xahoi.DataBind();

            List<Obj_News> listkinhte = Dao_News.get3NewsKinhTe();
            LV_Kinhte.DataSource = listkinhte;
            LV_Kinhte.DataBind();

            List<Obj_News> listthethao = Dao_News.get3NewsTheThao();
            LV_Thethao.DataSource = listthethao;
            LV_Thethao.DataBind();

            List<Obj_News> listgiaoduc = Dao_News.get3NewsGiaoDuc();
            LV_Giaoduc.DataSource = listgiaoduc;
            LV_Giaoduc.DataBind();

            List<Obj_News> listcongnghe = Dao_News.get3NewsCongNghe();
            LV_Congnghe.DataSource = listcongnghe;
            LV_Congnghe.DataBind();

        }

       

        
    }
}