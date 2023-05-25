<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="code_nhap.aspx.cs" Inherits="Admin_Page_News.Home.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Home" runat="server">
     
       <div class="bg0 p-t-60 p-b-10 ">
    <div class="container">
      <div class="row justify-content-center">
        <div class=" p-b-20  ">
          <div class=" how2 how2-cl4 flex-s-c m-r-10 m-r-0-sr991">
            <h3 class="f1-m-2 cl3 tab01-title"> BÀI VIẾT MỚI </h3>
            
          </div>    
          <div class="row p-t-35">
            <asp:ListView ID="LV_News_All" runat="server" DataKeyNames="News_ID" OnPagePropertiesChanging="LV_News_All_PagePropertiesChanging"  >
              <ItemTemplate>
                <div class="col-sm-3 p-r-25 p-r-15-sr991">
       <!-- Item latest -->	
              
                <div class="m-b-30">
               
                    <a CssClass="wrap-pic-w hov1 trans-03" href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>">
                         <img src="../<%#Eval("News_Avata")%>" style="width:100%;height:150px" alt="IMG">
                    </a>

                  <div class="p-t-16">
                  <h5 class="p-b-5">
                   
                      <a class="f1-m-3 cl2 text-overflow hov-cl10 trans-03" href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>">
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
   
    <asp:DataPager ID="dtpArticles" runat="server" PagedControlID="LV_News_All" PageSize="12" ClientIDMode="Static">
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
 </div>
   
</asp:Content>
