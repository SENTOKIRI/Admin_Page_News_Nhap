<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="ChiTiet.aspx.cs" Inherits="Admin_Page_News.Home.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Home" runat="server">
    
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
     <div class="single-block-wrapper p-t-10">
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
                    <asp:LinkButton ID="Lb_User_Name" runat="server" OnClick="Lb_User_Name_Click"></asp:LinkButton>
                </span>
              </div>

         </div>
        <!--anh va noi dung-->
        <div class="post-body">
            <div class="post-featured-image">
                <asp:Image ID="Img_anh" runat="server" CssClass="img-fluid" ImageUrl='<%#Eval("News_Avata")%>' />
               <%-- <img src="../<%#Eval("News_Avata")%>" class="img-fluid" alt="featured-image">--%>
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
                
               <asp:LinkButton ID="LB_Tag" runat="server" CssClass="tag-style Color" Text='<%#Eval("Tag_Name")%>' OnClick="LBnt_Tag_Click">LinkButton</asp:LinkButton>  
           </div>
            <asp:Button ID="Btn_luu" runat="server" OnClick="Btn_theo_doi_Click" CssClass="flex-c-c size-h-2 bo-1-rad-20 bocl12 f1-s-1 cl8 btn-outline-danger trans-03 p-rl-10 p-tb-5 m-all-5" Text="Lưu" />
           
        </div>
                     
                   
                    
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
                        <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>">
                            <img class="img-fluid"  src="../<%#Eval("News_Avata")%>" style="height:145px; width:100%" alt="post-thumbnail"/>
                        </a>
                    </div>
                    <a class="post-category" href="../Home/WebForm5?Tag_ID=<%#Eval("Tag_ID")%>">
                        <%#Eval("Tag_Name")%>
                    </a>
                    <div class="post-content">
                        <h2 class="post-title title-sm text01">
                            <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>"> 
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

    <div class="comment-form border-top m-b-25">
        <h3 class="title-normal">PHẢN HỒI </h3>
        <p class="mb-4">Hãy nhập đầy đủ thông tin trước khi phản hồi với chúng tôi*</p>
        <div role="form">
            <div class="row">
                 <div class="col-md-12">
                    <div class="form-group">
                       <asp:TextBox ID="TB_Comment" runat="server" CssClass="form-control" Width="100%" placeholder="Bình luận" Height="100px" TextMode="MultiLine" ></asp:TextBox>    
                   </div>
                </div>
    
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:TextBox ID="TB_Name" runat="server" CssClass="form-control" Width="100%" placeholder="Name"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:TextBox ID="TB_Email" runat="server" CssClass="form-control" Width="100%" placeholder="Email" required></asp:TextBox>
                </div>
                </div>
                
               
                <div class="col-md-12">
                    <asp:Button ID="Btn_Gui" runat="server" CssClass="btn btn-outline-danger " Width="100%"  Text="Gửi" OnClick="Btn_Gui_Click" />
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
                <div class="post-thumbnail" style="height:100px;width:100%;overflow:hidden">
                    <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>">
                        <img class="img-fluid" src="../<%#Eval("News_Avata")%>" style="width:100%;height:100%" alt="post-thumbnail"/>
                    </a>
                </div>
                <div class="post-content">
                    <h2 class="post-title title-sm text01">
                        <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>">
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
    



</asp:Content>
