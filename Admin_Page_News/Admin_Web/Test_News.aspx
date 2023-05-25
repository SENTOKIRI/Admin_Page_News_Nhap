<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Web/Admin_Web.Master" AutoEventWireup="true" CodeBehind="Test_News.aspx.cs" Inherits="Admin_Page_News.Admin_Web.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



       
   <!--==========================================================test====================================================================-->
    <style>
        .text01{
            -webkit-line-clamp: 3;
            -webkit-box-orient: vertical;
             overflow: hidden;
             display: -webkit-box;
             text-overflow: ellipsis;
        }
    </style>
     <div class="single-block-wrapper section-padding">
      <div class="container">
            <div class="row">
<%-- NOI DUNG  --%>
                <div class="col-lg-8 col-md-12 col-sm-12 col-xs-12">
                   

                    <div class="single-post">
                        <!--tieu de-->
                    <div class="post-header mb-5">
           
            <h2 class="post-title">
                <asp:Label ID="Lb_tieude" runat="server" CssClass="auto-style3 " Text='<%#Eval("News_Title")%>' ></asp:Label>
            
            </h2>
                    </div>
         <!--   tag-->
          <div class="share-block  d-flex justify-content-between align-items-center border-top border-bottom mt-5">
           
            <div class="post-meta">
                 <span class="posted-time">
                     <i class="fa fa-clock-o mr-1"></i>
                     <asp:Label ID="Lb_time" runat="server" Text=' <%#Eval("News_Edit_Date")%>'></asp:Label>
                     |
                     <i class="fa fa-eye"></i>
                     <asp:Label ID="Lb_view" runat="server" Text=' <%#Eval("News_View_Count")%>'></asp:Label>
                 </span>
                
           </div>
              <div class="post-meta flex-row-reverse">
                 <span >
                    <i class="fa fa-pencil-square-o"></i>
                    <asp:LinkButton Enabled="false" ID="Lb_User_Name" runat="server" ></asp:LinkButton>
                </span>
              </div>

         </div>
        <!--anh va noi dung-->
        <div class="post-body">
            <div class="post-featured-image">
                <asp:Image ID="Img_anh" runat="server" CssClass="img-fluid" Width="100%" Height="100%" ImageUrl='<%#Eval("News_Avata")%>' />
              
            </div>
            <div class="entry-content">
                <p>
                   <asp:Label ID="LB_noidung" runat="server"  CssClass="auto-style1" Text='<%#Eval("News_Content")%>' ></asp:Label>
                </p>
    
            </div>
            
           
        </div>
    </div>
                  
         <div class="share-block  d-flex justify-content-between align-items-center border-top border-bottom mt-5">
            <div class="post-tags">
                <span>Tags</span>
                
               <asp:LinkButton Enabled="false" ID="LB_Tag" runat="server" CssClass="tag-style Color" Text='<%#Eval("Tag_Name")%>' >LinkButton</asp:LinkButton>  
           </div>
            <asp:Button ID="Btn_luu" Enabled="false" runat="server"  CssClass="flex-c-c size-h-2 bo-1-rad-20 bocl12 f1-s-1 cl8 btn-outline-danger trans-03 p-rl-10 p-tb-5 m-all-5" Text="Lưu" />
           
        </div>
          <%if (Convert.ToInt32(Session["admin"]) == 2)
              {  %>    
                   
           <asp:Button ID="Bnt_duyet" runat="server" Text="Duyệt" OnClick="Bnt_duyet_Click" Width="49%" CssClass="btn btn-outline-success" />
           <asp:Button ID="Bnt_ko_duyet" runat="server" Text="Không duyệt" OnClick="Bnt_ko_duyet_Click" Width="49%" CssClass="btn btn-outline-danger" />
          <%} else if (Convert.ToInt32(Session["admin"]) == 1)
             {%>
             <div class="form-check">
                 <asp:CheckBox ID="CK_Hot" CssClass="form-check-input" runat="server" />
                 <label class="form-check-label" >Hot</label>
             </div>
                <br />
             <div>
               <asp:Button ID="Btn_dang" runat="server" Text="Đăng" OnClick="Btn_dang_Click" Width="49%" CssClass="btn btn-outline-success" />
               <asp:Button ID="Btn_Khong_dang" runat="server" Text="Không đăng" OnClick="Btn_Khong_dang_Click" Width="49%" CssClass="btn btn-outline-danger" />
             </div>

                  <%} %>
                    
    <div class="related-posts-block m-b-30 ">
        <h3 class="news-title">
            <span>LIÊN QUAN</span>
        </h3>
        <div class="news-style-two-slide">
             <asp:ListView ID="LV_Lienquan" runat="server">
                 <ItemTemplate>

            <div class="item">
                <div class="post-block-wrapper clearfix">
                    <div class="post-thumbnail mb-0">
                        <a href="../Admin_Web/Test_News?News_ID=<%#Eval("News_ID")%>">
                            <img class="img-fluid"  src="../<%#Eval("News_Avata")%>" style="height:145px; width:100%" alt="post-thumbnail"/>
                        </a>
                    </div>
                    <a class="post-category" >
                        <%#Eval("Tag_Name")%>
                    </a>
                    <div class="post-content">
                        <h2 class="post-title title-sm text01">
                            <a href="../Admin_Web/Test_News?News_ID=<%#Eval("News_ID")%>"> 
                                <%#Eval("News_Title")%>

                            </a>
                        </h2>
                         
                    </div>
                </div>
            </div>  
                 </ItemTemplate>
             </asp:ListView>

        </div>
    </div>
    
                
<%-- ====================comment======================================== --%>

    <div class="comment-form border-top">
        <h3 class="title-normal">PHẢN HỒI </h3>
        <p class="mb-4">Hãy nhập đầy đủ thông tin trước khi phản hồi với chúng tôi*</p>
        <div role="form">
            <div class="row">
                 <div class="col-md-12">
                    <div class="form-group">
                       <asp:TextBox ID="Tb_Comment_Test" runat="server" CssClass="form-control" Width="100%" placeholder="Bình luận" Height="100px" TextMode="MultiLine" ></asp:TextBox>    
                   </div>
                </div>
    
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:TextBox ID="TB_Name" runat="server" CssClass="form-control" Width="100%" placeholder="Name"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:TextBox ID="TB_Email" runat="server" CssClass="form-control" Width="100%" placeholder="Email"></asp:TextBox>
                </div>
                </div>
                
               
                <div class="col-md-12">
                    <asp:Button ID="Btn_Gui" runat="server" CssClass="btn btn-outline-danger" Width="100%"  Text="Gửi"  />
               </div>
            </div>
        </div>
    </div>
    

<%-- ===============================end comment============================ --%>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                    <div class="sidebar sidebar-right">
          <%--hot news--%>        
    <div class="widget">
        <h3 class="news-title">
            <span>Hot News</span>
        </h3>
      <asp:ListView ID="LV_Hotnews" runat="server">
          <ItemTemplate>

      
        <div class="post-list-block">
            <div class="post-block-wrapper post-float ">
                <div class="post-thumbnail">
                    <a href="../Admin_Web/Test_News?News_ID=<%#Eval("News_ID")%>">
                        <img class="img-fluid" src="../<%#Eval("News_Avata")%>" alt="post-thumbnail"/>
                    </a>
                </div>
                <div class="post-content">
                    <h2 class="post-title title-sm text01">
                        <a href="../Admin_Web/Test_News?News_ID=<%#Eval("News_ID")%>">
                             <%#Eval("News_Title")%>
                         </a>
                    </h2>
                    <div class="post-meta text01">
                        <span class="posted-time "><i class="fa fa-clock-o mr-1"></i><%#Eval("News_Edit_Date")%></span>
                    </div>
                </div>
            </div>
          
          
        </div>
              
          </ItemTemplate>
      </asp:ListView>
    </div>
    <!--tag lisst-->
    <div>
        <div class="how2 how2-cl4 flex-s-c m-b-30">
            <h3 class="f1-m-2 cl3 tab01-title">
                THỂ LOẠI CÙNG CHUYÊN MỤC
            </h3>
        </div>
        
        <div class="flex-wr-s-s m-rl--5">
             
            <asp:ListView ID="LV_Theloaichuyenmuc" runat="server">
            <ItemTemplate>
            <a href="../Home/dschuyenmuc?Tag_ID=<%#Eval("Tag_ID") %>" class="flex-c-c size-h-2 bo-1-rad-20 bocl12 f1-s-1 cl8 btn-outline-danger trans-03 p-rl-20 p-tb-5 m-all-5">
             <%#Eval("Tag_Name")%>
            </a>
              </ItemTemplate>
        </asp:ListView>
         </div>	
            
    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

 
<%--           <asp:Button ID="Bnt_duyet" runat="server" Text="Duyệt" OnClick="Bnt_duyet_Click"  CssClass="btn bg-primary-gradient" />
           <asp:Button ID="Bnt_ko_duyet" runat="server" Text="Không duyệt" OnClick="Bnt_ko_duyet_Click" CssClass="btn bg-primary-gradient" />
          --%>
</asp:Content>
