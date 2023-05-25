<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Admin_Page_News._Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Home" runat="server">
     
    <style type="text/css">
        
        .size-a-3{
        height: 390px;
         }
        .text-overflow-01{
         white-space: nowrap;
         text-overflow: ellipsis;
         overflow: hidden;
         display: inherit;
         }
       .text-overflow{
            -webkit-line-clamp: 2;
            -webkit-box-orient: vertical;
             overflow: hidden;
             display: -webkit-box;
             text-overflow: ellipsis;
        }
    </style>

    <%-- ====================================TEST==================================================== --%>



     <div class="bg0">
      <div style="margin-top: 20px;">
        <div class="row m-rl--1">



          <div class="col-md-6 p-rl-2 p-b-1">
              <asp:ListView ID="LV_Left" runat="server">
                <ItemTemplate>
            <div class="bg-img1 size-a-3  how1 pos-relative" style="background-image: url(../<%#Eval("News_Avata")%>);">
              <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="dis-block how1-child1 trans-03"></a>
  
              <div class="flex-col-e-s s-full p-rl-25 p-tb-20">
                <a href="#" class="dis-block how1-child2 f1-s-2 cl0 bo-all-1 bocl0 hov-btn1 trans-03 p-rl-5 p-t-2">
                    <%#Eval("News_Edit_Date")%>
                </a>
  
                <h3 class="how1-child2 m-t-14 m-b-10">
                
                 <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="how-txt1 size-a-6 f1-l-1 cl0 hov-cl10 trans-03">
                     <%#Eval("News_Title")%>
                 </a>
                </h3>       
              </div>
            </div>
                </ItemTemplate>
              </asp:ListView>
          </div>


            <div class="col-md-6 p-rl-1" >
                  <div class="row m-rl--1">
            <asp:ListView ID="LV_Right" runat="server"   >
                <ItemTemplate>
          
            
                <div class="col-sm-6 p-rl-1 p-b-2">
                    <div class="bg-img1 size-a-5 how1 pos-relative" style="background-image: url(../<%#Eval("News_Avata")%>);">
                      <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="dis-block how1-child1 trans-03"></a>
      
                      <div class="flex-col-e-s s-full p-rl-25 p-tb-20">
                        <a href="#" class="dis-block how1-child2 f1-s-2 cl0 bo-all-1 bocl0 hov-btn1 trans-03 p-rl-5 p-t-2">
                          <%#Eval("News_Edit_Date")%>
                        </a>

      
                        <h3 class="how1-child2 m-t-14">
                        
                          <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="how-txt1 size-h-1 f1-m-1 cl0 hov-cl10 trans-03" >
                              <%#Eval("News_Title")%>
                          </a>
                        </h3>
                      </div>
                    </div>
                  </div>
               
            

             </ItemTemplate>
            </asp:ListView>
           </div>
         </div>
        </div>
      </div>
    </div>


   <div class="bg0 p-t-60 p-b-10 ">
    <div class="container">
      <div class="row justify-content-center">
        <div class="col-md-10 col-lg-8 p-b-20  ">
          <div class=" how2 how2-cl4 flex-s-c m-r-10 m-r-0-sr991">
            <h3 class="f1-m-2 cl3 tab01-title"> BÀI VIẾT MỚI </h3>
          <a href="../Home/danhsachtin.aspx" class="tab01-link f1-s-1 cl9 hov-cl10 trans-03" style="margin-left: 63% !important;">
            XEM THEM
            <i class="fs-12 m-l-5 fa fa-caret-right"></i>
          </a>   
          </div>    
          <div class="row p-t-35">
            <asp:ListView ID="LV_News_All" runat="server" DataKeyNames="News_ID"  >
             
                <ItemTemplate>
                <div class="col-sm-4 p-r-25 p-r-15-sr991">
       <!-- Item latest -->	
              
                <div class="m-b-10" >
                   <div style="height:110px;width:100%;overflow:hidden">
                    <a CssClass="wrap-pic-w hov1 trans-03" href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>">
                         <img src="../<%#Eval("News_Avata")%>" style="width:100%;height:100%" alt="IMG">
                    </a>
                  </div>
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
                    <a href="#" class="f1-s-4 cl8 hov-cl10 text-overflow-01 trans-03">
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
              </div>
          </div>


           <div class="col-md-10 col-lg-4">
                <div class="p-l-10 p-rl-0-sr991 p-b-20">
                  <!--  -->
                  <div>
                    <div class="how2 how2-cl4 flex-s-c">
                      <h3 class="f1-m-2 cl3 tab01-title">
                        XEM NHIỀU
                      </h3>
                    </div>
      
                    <ul class="p-t-35">
                      <asp:ListView ID="LV_Xem_Nhieu" runat="server">
                        <ItemTemplate>

                            
                      <li class="flex-wr-sb-s p-b-22">
                        <div class="size-a-8 flex-c-c borad-3 size-a-8 bg9 f1-m-4 cl0 m-b-6">
                          <%#Eval("STT")%>
                        </div>
                          
                          <a class="size-w-3 f1-s-7 cl3 text-overflow hov-cl10 trans-03" href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>">
                             <%#Eval("News_Title")%>
                           </a>
                      </li>
                          </ItemTemplate>
                        </asp:ListView>
                    </ul>
                  </div>
      
                  <!--  -->
                 
                </div>
              </div>



        </div>      
      </div>
    </div>



    
<div class="bg0 p-t-70">
  <div class="container">
    <div class="row justify-content-center">
        <!-- CHUYEN MUC 1-->

        <div class="col-md-10 col-lg-6">

            <div class=" how2 how2-cl4 bocl12 flex-s-c m-r-10 m-r-0-sr991">
              <!-- Brand tab -->
              <h3 class="f1-m-2 cl12 tab01-title" >
                XA HOI
              </h3>
  
              <a href="../Home/dschuyenmuc?Category_ID=1" class="tab01-link f1-s-1 cl9 hov-cl10 trans-03" style="margin-left:65% !important">
                View all
                <i class="fs-12 m-l-5 fa fa-caret-right"></i>
              </a>
            </div>
            <!-- Tab panes -->
            
                <div class="row p-t-20">
                  <a href="../Home/dschuyenmuc?Category_ID=1" class="col-sm-6 ">
                 <img src="../images/anh-xa-hoi.jpg" style="width:100%;height:230px" alt="IMG">
                    
                  </a>

                  <div class="col-sm-6 p-r-25 p-r-15-sr991">
                    <!-- Item post -->	
                 <asp:ListView ID="LV_Xahoi" runat="server">
                  <ItemTemplate>
                    <div class="flex-wr-sb-s m-b-10">
                      <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="size-w-1 wrap-pic-w hov1 trans-03">
                          <img src="<%#Eval("News_Avata")%>" alt="IMG" style="width:100%; height:auto" />
                      </a>

                      <div class="size-w-2">
                        <h5 class="p-b-5">
                          <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="f1-s-5 cl3 text-overflow hov-cl10 trans-03">
                           <%#Eval("News_Title")%>
                          </a>
                        </h5>

                        <span class="cl8">
                          <a href="#" class="f1-s-6 cl8 hov-cl10 text-overflow-01 trans-03">
                            <i class="fa fa-clock-o"></i>
                            <%#Eval("News_Edit_Date")%>
                          </a>
                        </span>
                      </div>
                    </div>
                     </ItemTemplate>
                 </asp:ListView>
                  </div>
                </div>
           </div>

        
        <!-- Chuyen muc 2-->

          <div class="col-md-10 col-lg-6">

            <div class=" how2 how2-cl4 bocl12 flex-s-c m-r-10 m-r-0-sr991">
              <!-- Brand tab -->
              <h3 class="f1-m-2 cl12 tab01-title" >
                KINH TẾ
              </h3>
  
              <a href="../Home/dschuyenmuc?Category_ID=2" class="tab01-link f1-s-1 cl9 hov-cl10 trans-03" style="margin-left:60% !important">
                View all
                <i class="fs-12 m-l-5 fa fa-caret-right"></i>
              </a>
            </div>
            <!-- Tab panes -->
            
                <div class="row p-t-20">
                <a href="../Home/dschuyenmuc?Category_ID=2" class="col-sm-6 ">
                <img src="../images/anh-kinh-te.jpg" style="width:100%;height:230px" alt="IMG">
                    
                </a>
                <div class="col-sm-6 p-r-25 p-r-15-sr991">
                    <!-- Item post -->
                    
                  <asp:ListView ID="LV_Kinhte" runat="server" >
                    <ItemTemplate>
                 
                           <div class="flex-wr-sb-s m-b-10">
                      <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="size-w-1 wrap-pic-w hov1 trans-03">
                          <img src="<%#Eval("News_Avata")%>" alt="IMG" style="width:100%; height:auto" />
                      </a>

                      <div class="size-w-2">
                        <h5 class="p-b-5">
                          <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="f1-s-5 cl3 text-overflow hov-cl10 trans-03">
                           <%#Eval("News_Title")%>
                          </a>
                        </h5>

                        <span class="cl8">
                          <a href="#" class="f1-s-6 cl8 hov-cl10 text-overflow-01 trans-03">
                            <i class="fa fa-clock-o"></i>
                            <%#Eval("News_Edit_Date")%>
                          </a>
                        </span>
                      </div>
                    </div>
                     </ItemTemplate>
                 </asp:ListView>
                   
                  </div>
                </div>
          </div>
     </div>
  </div>
</div>




    
<div class="bg0 p-t-70">
  <div class="container">
    <div class="row justify-content-center">
      <div class="col-md-10 col-lg-12">
        <div class="p-b-20 ">
         <div class="row">
            <!-- Business -->
            <div class="col-sm-4 p-r-25 p-r-15-sr991 p-b-25">
              <div class="how2 how2-cl2 flex-sb-c m-b-35">
                <h3 class="f1-m-2 cl13 tab01-title">
                  THỂ THAO
                </h3>

                <a href="../Home/dschuyenmuc?Category_ID=3" class="tab01-link f1-s-1 cl9 hov-cl10 trans-03">
                  View all
                  <i class="fs-12 m-l-5 fa fa-caret-right"></i>
                </a>
              </div>

              <!-- Main Item post -->	
              <div class="m-b-30">
                <a href="../Home/dschuyenmuc?Category_ID=3" class="wrap-pic-w hov1 trans-03">
                 <img src="../images/anh-the-thao.jpg" style="width:100%;height:250px" alt="IMG">
                    
                </a>
              </div>

              <!-- Item post -->
             <asp:ListView ID="LV_Thethao" runat="server">
                 <ItemTemplate>

                    
              <div class="flex-wr-sb-s m-b-30">
                <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="size-w-1 wrap-pic-w hov1 trans-03">
                  <img src="<%#Eval("News_Avata")%>" alt="IMGDonec metus orci, malesuada et lectus vitae">
                </a>

                <div class="size-w-2">
                  <h5 class="p-b-5">
                    <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="f1-s-5 cl3 text-overflow hov-cl10 trans-03">
                        <%#Eval("News_Title")%>
                    </a>
                  </h5>

                  <span class="cl8">
                    <a href="#" class="f1-s-6 cl8 hov-cl10 text-overflow-01 trans-03">
                       <i class="fa fa-clock-o"></i>
                            <%#Eval("News_Edit_Date")%>
                    </a>
                  </span>
                </div>
              </div>

                 </ItemTemplate>
             </asp:ListView>
            
            </div>

            <!-- Technology -->
            <div class="col-sm-4 p-r-25 p-r-15-sr991 p-b-25">
              <div class="how2 how2-cl6 flex-sb-c m-b-35">
                <h3 class="f1-m-2 cl18 tab01-title">
                  GIÁO DỤC
                </h3>
                <a href="../Home/dschuyenmuc?Category_ID=5" class="tab01-link f1-s-1 cl9 hov-cl10 trans-03">
                  View all
                  <i class="fs-12 m-l-5 fa fa-caret-right"></i>
                </a>
              </div>

              <!-- Main Item post -->	
              <div class="m-b-30">
                 <a href="../Home/dschuyenmuc?Category_ID=5" class="wrap-pic-w hov1 trans-03">
                
                     <img src="../images/anh-giao-duc.jpg" style="width:100%;height:250px" alt="IMG">
                    
                 </a>

            
              </div>

              <!-- Item post -->	
               <asp:ListView ID="LV_Giaoduc" runat="server">
                 <ItemTemplate>

                    
              <div class="flex-wr-sb-s m-b-30">
                <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="size-w-1 wrap-pic-w hov1 trans-03">
                  <img src="<%#Eval("News_Avata")%>" alt="IMGDonec metus orci, malesuada et lectus vitae">
                </a>

                <div class="size-w-2">
                  <h5 class="p-b-5">
                    <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="f1-s-5 cl3 text-overflow hov-cl10 trans-03">
                        <%#Eval("News_Title")%>
                    </a>
                  </h5>

                  <span class="cl8">
                    <a href="#" class="f1-s-6 cl8 hov-cl10 text-overflow-01 trans-03">
                       <i class="fa fa-clock-o"></i>
                            <%#Eval("News_Edit_Date")%>
                    </a>
                  </span>
                </div>
              </div>

                 </ItemTemplate>
             </asp:ListView>

              <!-- Item post -->
            
            </div>

            <!-- Life Style -->
            <div class="col-sm-4 p-r-25 p-r-15-sr991 p-b-25">
              <div class="how2 how2-cl5 flex-sb-c m-b-35">
                <h3 class="f1-m-2 cl17 tab01-title">
                  CÔNG NGHỆ
                </h3>
                <a href="../Home/dschuyenmuc?Category_ID=6" class="tab01-link f1-s-1 cl9 hov-cl10 trans-03">
                  View all
                  <i class="fs-12 m-l-5 fa fa-caret-right"></i>
                </a>
              </div>

              <!-- Main Item post -->	
              <div class="m-b-30">
                <a href="../Home/dschuyenmuc?Category_ID=6" class="wrap-pic-w hov1 trans-03">
               
                    <img src="../images/anh-cong-nghe.jpg" style="width:100%;height:250px" alt="IMG">
                    
                </a>
              </div>

              <!-- Item post -->	
              <asp:ListView ID="LV_Congnghe" runat="server">
                 <ItemTemplate>

                    
              <div class="flex-wr-sb-s m-b-30">
                <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="size-w-1 wrap-pic-w hov1 trans-03">
                  <img src="<%#Eval("News_Avata")%>" alt="IMGDonec metus orci, malesuada et lectus vitae">
                </a>

                <div class="size-w-2">
                  <h5 class="p-b-5">
                    <a href="../Home/ChiTiet?News_ID=<%#Eval("News_ID")%>" class="f1-s-5 cl3 text-overflow hov-cl10 trans-03">
                        <%#Eval("News_Title")%>
                    </a>
                  </h5>

                  <span class="cl8">
                    <a href="#" class="f1-s-6 cl8 hov-cl10 text-overflow-01 trans-03">
                       <i class="fa fa-clock-o"></i>
                            <%#Eval("News_Edit_Date")%>
                    </a>
                  </span>
                </div>
              </div>

                 </ItemTemplate>
             </asp:ListView>

              <!-- Item post -->
           
            </div>

            <!-- Fashion -->
         </div>
        </div>
       </div>
     </div>
    </div>
  </div>





     <%-- ==================================== END TEST==================================================== --%>
</asp:Content>
