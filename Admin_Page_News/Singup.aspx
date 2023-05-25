<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Singup.aspx.cs" Inherits="Admin_Page_News.Singup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SIGNUP </title>
      <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/plugins/slick-carousel/slick.css" rel="stylesheet" />
    <link href="Content/css/style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
       

        <!--===========================================test=========================================-->

        
<section class="login-signup " >
    <div class="container">
        <div class="row align-items-center justify-content-center">
            <div class="col-lg-7">
                <div class="signup">
                    <h3 class="mt-4">Sign Up Here</h3>
                    <p class="mb-5">Join with us and feel better</p>
                    <div  class="signup-form row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="f-name">Tài khoản</label>
                                   <div class="d-flex">
                                   <asp:TextBox ID="tb_User_Name" runat="server" placeholder="User Name"  CssClass="form-control" value ="" required ></asp:TextBox>
                                    </div>
                             </div>
                        </div>
                        
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="l-name">Họ Và Tên</label>
                                  <div class="d-flex">
                                  <asp:TextBox ID="tb_User_Full_Name" runat="server" placeholder="User Full Name" CssClass="form-control" value ="" required></asp:TextBox>
                                 </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="email-address">Email</label>
                                  <div class="d-flex">
                                  <asp:TextBox ID="tb_Email" runat="server" placeholder="Email" TextMode="Email" CssClass="form-control" value ="" required></asp:TextBox>
                                 </div>
                                </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="password-s">Mật Khẩu</label>
                                 <div class="d-flex">
                                  <asp:TextBox ID="tb_Password" runat="server" placeholder="Password" TextMode="Password" CssClass="form-control" value ="" required></asp:TextBox>
                                 </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            
                          
                           <asp:Button ID="btnDangky" runat="server" Text="Đăng ký"  Width="200px" Height="50px" Cssclass="btn btn-primary"  OnClick="btnDangky_Click" />
          
                            <p class="mt-5 mb-0">Bạn đã là thành viên hay chưa? <a href="../Login.aspx">Đăng Nhập</a></p>
                        </div>
                    </div>
                
                 </div>
            </div>
        </div>
    </div>
   
</section>


    </form>
   
</body>

</html>
