<%@ Page Title="" Language="C#" MasterPageFile="~/Home/Home.Master" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="Admin_Page_News.Home.WebForm5" %>


<asp:Content ID="Content_Head" ContentPlaceHolderID="Head_Home" runat="server">
     
    <link href="../Content/user-infor.css" rel="stylesheet" />
    <style>
        .thaotac{
            width:80%;
            height:100%;
            justify-content:left;
            text-align:left;
            padding-left:15px;
        }
  .filename{
      color:red;
  }
    
    </style>
    <div class="p-t-15 "> 
        <div class="row">
            <div class="col-md-4">
                <div class="thaotac">
                   <%--      <div class="file-upload">
      <div class="image-upload-wrap">
        <input class="file-upload-input" type='file' onchange="readURL(this);" accept="image/*" />
        <div class="drag-text">
             <asp:Image ID="Image1" runat="server" CssClass="file-upload-image" alt="your image" ImageUrl="../images/avata_user.png" />
        
        <div class="image-title-wrap d-flex" style="position:absolute; bottom:0; right: 0; padding-bottom:0">
          <button class="btn btn-outline-danger"  type="button" onclick="$('.file-upload-input').trigger( 'click' )">Sửa</button>
        </div>
        </div>
      </div>
      <div class="file-upload-content">

           <asp:Image ID="Add_Image" runat="server" CssClass="file-upload-image" alt="your image" ImageUrl="../images/avata_user.png" />
        
          <div class="image-title-wrap d-flex" style="position:absolute; bottom:0; right: 0; padding-bottom:0">
          <button class="btn btn-outline-danger"  type="button" onclick="$('.file-upload-input').trigger( 'click' )">Sửa</button>
        
        </div>
      </div>
    </div>--%>
 <!--====================================================nhap====================================================-->

                    <style>
                        .anhnhap{
                             position: relative;
                             width: 100%;
                        }

                         
.image {
  display: block;
  width: 100%;
  height: auto;
  border-radius: 5%;
 
  
}
 
.overlay {
  position: absolute;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  height: 100%;
  width: 100%;
  opacity: 0;
  transition: .5s ease;
  background-image:url("../images/anh-he-thong/anh-dau-cong.jpg");
  background-size:cover;
  border-radius: 5%;
}
 
.container:hover .overlay {
  opacity: 0.7;
}
 
.text1 {
  color: white;
  font-size: 20px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
 
  
}
                    </style>
               
                   <div class="anhnhap">
                    <asp:Image ID="Add_Image" runat="server" CssClass="image" ImageUrl="../images/anh-he-thong/anh-dau-cong.jpg" />
                    <div class="overlay">
                      <%--<input class="file-upload-input text1"  type='file' onchange="docURL(this);" accept="image/*" />
                      --%> 
                        
                        <asp:FileUpload ID="FileUpload1" CssClass="file-upload-input text1" onchange="docURL(this);" runat="server" />
                     </div>
                  </div>
               
               </div>
            </div>

                    


                    <div class="col-md-6">
                        <div class="profile-head">
                                    <h2>
                                        <asp:Label ID="Lb_User_Name_Top" runat="server" Font-Size="25px" ></asp:Label>
                                    </h2>
                                    <h4>
                                        <asp:Label ID="Lb_Email_Top" runat="server" Font-Size="20px" ></asp:Label>
                                    </h4><br />

                                    <p class="proile-rating">RANKINGS : <span>8/10</span></p>
                            
                            <ul class="nav nav-tabs" id="myTab" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">About</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Timeline</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="col-md-2">
                       
                        <asp:Button ID="Bnt_Edit" runat="server" Text="Sửa thông tin" CssClass="profile-edit-btn btn-outline-dark" OnClick="Bnt_Edit_Click" />
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

<asp:Content ID="Content1" ContentPlaceHolderID="Home" runat="server">
     <link href="../Content/thongtinnguoidung.css" rel="stylesheet" />
          
    <div class="p-b-20">       
         
                <div class="row">
                    <div class="col-md-4 ">
                        <div>
                            <h2>THAO TAC</h2>
                        </div>
                        <div>
                            <asp:Button ID="Btn_edit" runat="server" CssClass="btn btn-outline-danger thaotac m-t-5 " Text="Sửa thông tin" OnClick="Bnt_Edit_Click" />
                            <asp:Button ID="Btn_lichsu" runat="server" CssClass="btn btn-outline-danger thaotac m-t-5 " Text="Lịch sử đọc" OnClick="Btn_lichsu_Click" />
                            <asp:Button ID="Btn_theodoi" runat="server" CssClass="btn btn-outline-danger thaotac m-t-5 " Text="Theo dõi" OnClick="Btn_theodoi_Click" />
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </div>
                        <hr />
                        <div>
                             <asp:Button ID="Btn_thoat" runat="server" CssClass="btn btn-outline-danger thaotac" Text="ĐĂNG XUẤT" OnClick="Btn_thoat_Click" />
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
 

</asp:Content>
