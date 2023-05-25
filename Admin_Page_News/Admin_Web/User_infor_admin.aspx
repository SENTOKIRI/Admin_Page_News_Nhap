<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Web/Admin_Web.Master" AutoEventWireup="true" CodeBehind="User_infor_admin.aspx.cs" Inherits="Admin_Page_News.Admin_Web.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../Content/thongtinnguoidung.css" rel="stylesheet" />

<div class="container">
<div class="p-t-15 p-b-15">         
      <div class="row">
          <div class="col-md-4">
              <div class="thaotac">
                   <div class="anhnhap">
                    <asp:Image ID="Add_Image" runat="server" CssClass="image" ImageUrl="../images/anh-he-thong/anh-dau-cong.jpg" />
                    <div class="overlay">
                       <asp:FileUpload ID="FileUpload1" CssClass="file-upload-input text1" onchange="docURL(this);" runat="server" />
                     
                    </div>
                  </div>
               </div>

                    </div>
                    <div class="col-md-8">
                        <div class="profile-head">
                                    <h2>
                                        <asp:Label ID="Lb_User_Name_Top" runat="server" Font-Size="26px" ></asp:Label>
                                    </h2>
                                    <h4>
                                        <asp:Label ID="Lb_Email_Top" runat="server" Font-Size="20px" ></asp:Label>
                                    </h4>
                                    <p class="proile-rating">RANKINGS : <span>8/10</span></p>
                            <ul class="nav nav-tabs" id="myTab" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Thông tin người dùng</a>
                                </li>
                               
                            </ul>
                        </div>
                    </div>
                   
                </div>
                <div class="row m-t-10">
                    <div class="col-md-4">
                         <div>
                            <h2>THAO TAC</h2>
                        </div>
                        <div>
                            <asp:Button ID="Btn_edit" runat="server" CssClass="btn btn-outline-dark thaotac m-t-5 " Text="Sửa thông tin" OnClick="Bnt_Edit_Click" />
                            <asp:Button ID="Btn_chuyenmuc" runat="server" CssClass="btn btn-outline-dark thaotac m-t-5 " Text="Chuyên mục" OnClick="Btn_chuyenmuc_Click" />
                            <asp:Button ID="Btn_theloai" runat="server" CssClass="btn btn-outline-dark thaotac m-t-5 " Text="Thể loai" OnClick="Btn_theloai_Click" />
                            <asp:Button ID="Btn_nguoidung" runat="server" CssClass="btn btn-outline-dark thaotac m-t-5 " Text="Người dùng" OnClick="Btn_nguoidung_Click" />
                            <asp:Button ID="Btn_phanhoi" runat="server" CssClass="btn btn-outline-dark thaotac m-t-5 " Text="Phản hồi" OnClick="Btn_phanhoi_Click" />
                       
                        </div>
                       
                        <div>
                             <asp:Button ID="Btn_thoat" runat="server" CssClass="btn btn-danger dangxuat m-t-10" Text="ĐĂNG XUẤT" OnClick="Btn_thoat_Click" />
                        </div>
                    </div>

<!--======================thong tin nguoi dung=====================================-->
                    <div class="col-md-8">
                        <div class="tab-content profile-tab" id="myTabContent">
                            <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                        <div class="row form-group">
                                            <div class="col-md-4">
                                                <label>ID người dùng</label>
                                            </div>
                                            <div class="col-md-8 ">
                                                <asp:TextBox ID="Tb_User_ID" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-md-3">
                                                <label>Tài khoản</label>                                              
                                            </div>
                                             <div class="col-md-1">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validato" runat="server" ErrorMessage="!" ControlToValidate="Tb_User_Name" ForeColor="red"></asp:RequiredFieldValidator>                                           
                                            </div>
                                            <div class="col-md-8">
                                               <asp:TextBox ID="Tb_User_Name" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-md-3">
                                                <label>Mật khẩu</label>
                                            </div>
                                             <div class="col-md-1">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="validato" runat="server" ErrorMessage="!" ControlToValidate="Tb_Password" ForeColor="red"></asp:RequiredFieldValidator>                                           
                                            </div>
                                            <div class="col-md-8 input-group" id="show_hide_password">
                                                <asp:TextBox ID="Tb_Password" Enabled="false"   runat="server" CssClass="form-control"  ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-md-3 ">
                                                <label> Họ và tên</label>
                                            </div>
                                            <div class="col-md-1">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validato" runat="server" ErrorMessage="!" ControlToValidate="Tb_Full_Name" ForeColor="red"></asp:RequiredFieldValidator>                                           
                                            </div>
                                            <div class="col-md-8 ">
                                                
                                                <asp:TextBox ID="Tb_Full_Name" runat="server" Enabled="false" CssClass="form-control"  ></asp:TextBox>                                          
                                            </div>
                                        </div>
                                        <div class="row form-group">
                                            <div class="col-md-3">
                                                <label>Email</label>
                                            </div>
                                             <div class="col-md-1">
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validato" runat="server" ErrorMessage="!" ControlToValidate="Tb_Email" ForeColor="red"></asp:RequiredFieldValidator>                                           
                                            </div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="Tb_Email" TextMode="Email" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                            </div>
                            <div>
                                <asp:Button ID="Btn_Sua" runat="server" Text="Sửa" Enabled="false" Width="100%" CssClass="btn btn-outline-primary" OnClick="Bt_Sua_User_Click" />
                            </div>
                        </div>
                    </div>

<!--======================end thong tin nguoi dung=====================================-->
                </div>
                      
        </div>
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

</asp:Content>
