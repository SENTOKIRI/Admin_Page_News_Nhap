<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Page/Admin.Master" AutoEventWireup="true" CodeBehind="Add_News.aspx.cs" Inherits="Admin_Page_News.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainAdmin" runat="server">
    
    <style>
        .imageAdd{
            margin:auto;
            Width:300px;          
            justify-content:center;
        }
        .News-padding{
            padding: 5px;
        }
        .tb-news{
            max-width:1200px;
            min-width:1120px;
            width:100%;
        }
       
   
    </style>


      <div  style="margin-top:5px;padding:20px;">
         <div class="form-group-lg">        
          <asp:Label ID="Lb_News_ID" runat="server" Text=' <%#Eval("News_ID") %>'> <span style="font-size:x-large">Thêm bài viết mới:</span> </asp:Label>
      </div>
      <br />
      <div class="form-group-lg">
          <h4 style="padding-right:1030px">News Title</h4>
          <asp:TextBox ID="Tb_News_Title" TextMode="MultiLine" runat="server" CssClass="News-padding " Width="100%"  Height="40px" ></asp:TextBox>
              
      </div>
      <div class="form-group-lg">
          <h4>Tag</h4>
          <asp:DropDownList ID="DDL_Tag"  Width="300px" Height="35px"  runat="server"></asp:DropDownList>        
      </div>
      <div class="form-group-lg">
          <h4>Image</h4>
          <div>
          <asp:FileUpload ID="News_Image" runat="server" />
          <asp:Button ID="Update_Image" runat="server" Text="Update" Width="100px" OnClick="Update_Image_Click" />
          <br />
              </div>
          <br />
          
          <div style="margin:auto;">
          <asp:Image ID="Add_Image" runat="server" CssClass="imageAdd" ImageUrl="/images/Image-logo.png" />  
          </div>
      </div>
      <br />
      <div class="form-group-lg ">
          <h4>News Content</h4>          
          <asp:TextBox ID="Tb_News_Content" TextMode="MultiLine" Width="100%" Height="1000px" runat="server"></asp:TextBox>
      
      </div>   
      <div class="form-group-lg ">
          <h4>News Status </h4>                 
           <asp:CheckBox ID="News_Status" runat="server"  />  <span>Đăng ngay</span>  
      </div>                
      <div class="form-group-lg ">
          <h4>News Hot </h4>               
           <asp:CheckBox ID="News_Hot" runat="server"   /><span>Tin Hot</span>
  
      </div> 
      <br /> 
          <br />
          <asp:Button ID="Bt_Add_News" runat="server" Text="Thêm" CssClass="btn bg-primary-gradient" Width="200px" Height="50px"   OnClick="Bt_Add_News_Click"/>   
          <asp:Button ID="Bt_Sua" runat="server" Text="Sửa"  CssClass="btn bg-primary-gradient" Width="200px" Height="50px"   OnClick="Bt_Sua_News_Click"/>
       </div>
    
   <script src="../Content/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" lang="javascript">
        CKEDITOR.replace('<%=Tb_News_Content.ClientID%>');
    </script>
</asp:Content>
