<%@ Page Title="" Language="C#" MasterPageFile="~/Content_Creator/ContentCreator.Master" AutoEventWireup="true" CodeBehind="create_news.aspx.cs" Inherits="Admin_Page_News.Content_Creator.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link href="../Content/thongtinnguoidung.css" rel="stylesheet" />
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
            

            width:100%;
        }
      

    </style>


      <div  >
                
          <asp:Label ID="Lb_News_ID" runat="server" Text=' <%#Eval("News_ID") %>'> <span style="font-size:x-large">Thêm bài viết mới:</span> </asp:Label>
     
      <br />
      <div class="form-group-lg">
          <h4 >News Title</h4>
          <asp:TextBox ID="Tb_News_Title"  runat="server" CssClass="form-control " Width="100%"  Height="40px" ></asp:TextBox>
              
      </div>
      <div class="form-group-lg">
          <h4>Tag</h4>
          <asp:DropDownList ID="DDL_Tag"  Width="300px" Height="35px"  runat="server"></asp:DropDownList> 
          <asp:Label ID="Label1" runat="server" > </asp:Label>
     
      </div>
      <h4>Image</h4>
            <div class="form-group-lg col-md-3">
          
         <div class="thaotac">
                   <div class="anhnhap">
                    <asp:Image ID="Image1" runat="server" Width="100%" CssClass="image" ImageUrl="../images/kamen-rider-geats.png" />
                    <div class="overlay">
                       <asp:FileUpload ID="FileUpload1" CssClass="file-upload-input text1" onchange="docURL(this);" runat="server" />
                     
                    </div>
                  </div>
               </div>
      </div>
      <br />
      <div class="form-group-lg ">
          <h4>News Content</h4>          
          <asp:TextBox ID="Tb_News_Content" TextMode="MultiLine" Width="100%" Height="1000px" runat="server"></asp:TextBox>
      
      </div>   
     <br />
          <br />
          <asp:Button ID="Bt_Add_News" runat="server" Text="Gửi" CssClass="btn btn-outline-primary" Width="200px" Height="50px"   OnClick="Bt_Add_News_Click"/>   
          <asp:Button ID="Bt_Sua" runat="server" Text="Sửa"  CssClass="btn btn-outline-success" Width="200px" Height="50px"   OnClick="Bt_Sua_News_Click"/>
       </div>
    
    <script>
        function docURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('.nhap1').hide();
                    $('.image').attr('src', e.target.result);

                    $('.image').show();
                };
                reader.readAsDataURL(input.files[0]);
            }
            else {
                removeUpload();
            }


        }
        function readURL(input) {
            if (input.files && input.files[0]) {

                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.image-upload-wrap').hide();

                    $('.file-upload-image').attr('src', e.target.result);
                    $('.file-upload-content').show();

                    $('.image-title').html(input.files[0].name);
                };

                reader.readAsDataURL(input.files[0]);

            } else {
                removeUpload();
            }
        }

        function removeUpload() {
            $('.file-upload-input').replaceWith($('.file-upload-input').clone());
            $('.file-upload-content').hide();
            $('.image-upload-wrap').show();
        }
        $('.image-upload-wrap').bind('dragover', function () {
            $('.image-upload-wrap').addClass('image-dropping');
        });
        $('.image-upload-wrap').bind('dragleave', function () {
            $('.image-upload-wrap').removeClass('image-dropping');
        });

    </script>
    <script src="../Content/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" lang="javascript">
        CKEDITOR.replace('<%=Tb_News_Content.ClientID%>');
    </script>
</asp:Content>
