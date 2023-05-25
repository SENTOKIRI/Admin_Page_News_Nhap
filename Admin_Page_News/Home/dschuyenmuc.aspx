<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="dschuyenmuc.aspx.cs" Inherits="Admin_Page_News.Home.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Home" runat="server">
      
     <style>
        .page-item:hover{
            color:black;
            background-color:aqua;
        }
        .phantrang{
            width:500px !important
        }
        .page-link{
            color:black;
            border-radius:5px;
        }
        .page-link:hover{
            background-color:#dc3545!important;
        }
         .text01{
            -webkit-line-clamp: 2;
            -webkit-box-orient: vertical;
             overflow: hidden;
             display: -webkit-box;
             text-overflow: ellipsis;
        }
    </style>

       <!--========================================================== NOI DUNG=========================================================================-->
<!--=======================================hot==========================================-->

     <div class="row justify-content-center p-t-15">
        <div class="col-lg-12" style="padding: 0 !important">
            <div class="related-posts-block m-b-15" >
         <div class=" how2 how2-cl4 flex-s-c m-r-10 m-b-10 m-r-0-sr991" >
            <h3 class="f1-m-2 cl3 tab01-title"> CHUYÊN MỤC </h3>
          </div>
        <div class="news-style-two-slide">
             <asp:ListView ID="LV_ChuyenMuc" runat="server">
                 <ItemTemplate>

            <div class="item">
                <div class="post-block-wrapper clearfix">
                    <div class="post-thumbnail mb-0">
                        <a href="../Home/dschuyenmuc?Category_ID=<%#Eval("Category_ID")%>">
                            <img class="img-fluid"  src="../<%#Eval("Category_Img")%>" style="height:210px; width:100%;" alt="post-thumbnail"/>
                        </a>
                    </div>
                    <a class="post-category" href="../Home/dschuyenmuc?Tag_ID=<%#Eval("Category_ID")%>">
                        <%#Eval("Category_Name")%>
                    </a>
                    <div class="post-content">
                        
                         
                    </div>
                </div>
            </div>  
                 </ItemTemplate>
             </asp:ListView>

        </div>
    </div>
        </div>
  
     </div>

<!--================= ========================================  DANH SACH TIN==================-->

   <div class="bg0 p-t-20 p-b-10 ">
   
      <div class="row justify-content-center">
        <div class=" p-b-20  ">
          <div class=" how2 how2-cl4 flex-s-c m-r-10 m-r-0-sr991">
            <h3 class="f1-m-2 cl3 tab01-title"> BÀI VIẾT MỚI </h3>
            
          </div>    
          <div class="row p-t-35">
            <asp:ListView ID="LV_News_All" runat="server" DataKeyNames="News_ID" OnPagePropertiesChanging="LV_News_All_PagePropertiesChanging"  >
              <ItemTemplate>
                <div class="col-md-3 p-r-25 p-r-15-sr991">
       <!-- Item latest -->	
              
                <div class="m-b-30">
               
                    <a CssClass="wrap-pic-w hov1 trans-03" href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>">
                         <img src="../<%#Eval("News_Avata")%>" style="width:100%;height:160px" alt="IMG">
                    </a>

                  <div class="p-t-16">
                  <h5 class="p-b-5">
                   
                      <a class="f1-m-3 cl2  text01 hov-cl10 trans-03" href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>">
                      <%#Eval("News_Title")%>
                      </a>
                  </h5>

                  <span class="cl8">
                      <span class="f1-s-3">
                     <i class="fa fa-clock-o"></i>
                    </span>
                    <a href="#" class="f1-s-4 cl8 hov-cl10 trans-03">
                      <%#Eval("News_Edit_Date")%>
                        
                    </a>
                  </span>
                </div>
                  </div>
                </div>
              </ItemTemplate>
                <EditItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server"><%#Eval("News_ID")%></asp:LinkButton> 
                </EditItemTemplate>
            </asp:ListView>
<!--===========================phan trang=======================================-->


              </div>

                        
 <div class="pagination-wrapper">
  <div class="pagination justify-content-center d-flex">
   <div class="row">
   
    <asp:DataPager ID="dtpArticles" runat="server" PagedControlID="LV_News_All" PageSize="20" ClientIDMode="Static">
        <Fields>
           <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true" FirstPageText="<<" ShowPreviousPageButton="true" PreviousPageText="<" 
                    ShowNextPageButton="false" ButtonCssClass="page-item page-link"   />
           <asp:NumericPagerField ButtonType="Link" ButtonCount="5" CurrentPageLabelCssClass="page-item page-link bg-danger"
                    NumericButtonCssClass=" page-item page-link" />
           <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="true" NextPageText=">" ShowNextPageButton="true" LastPageText=">>"
                   ShowPreviousPageButton="false" ButtonCssClass="page-item page-link" />
        </Fields>
    </asp:DataPager>
   </div>
  </div>
</div>
            
       </div>
     </div>   
   
 </div>


      <div class="col-lg-12" style="padding: 0 !important">
              
        <div class="how2 how2-cl4 flex-s-c">
            <h3 class="f1-m-2 cl3 tab01-title" style="width:100%">
                THỂ LOẠI
            </h3>
        </div>
        
        <div class="flex-wr-s-s m-rl--5" style="display:flex; justify-content: space-between">
             
            <asp:ListView ID="LV_Theloai" runat="server">
            <ItemTemplate>
                <h2 class="" >
            <a href="../Home/dschuyenmuc?Tag_ID=<%#Eval("Tag_ID")%>" class="flex-c-c size-h-2 bo-1-rad-20 bocl12 f1-s-1 cl8  btn-outline-danger trans-03 p-rl-20 p-tb-5 m-all-5">
             <%#Eval("Tag_Name")%>
            </a>
                </h2>
              </ItemTemplate>
        </asp:ListView>
         </div>	
            
    </div>
        

</asp:Content>
