<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Admin_Page_News.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
     <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/plugins/slick-carousel/slick.css" rel="stylesheet" />

    <link href="Content/css/style.css" rel="stylesheet" />
     <style>
         .block1{
             display: flex;
             justify-content: center;
             align-items: center;
         }
     </style>
</head>
<body class="tn-img">
    <form id="form1" runat="server" >
       
        <%-- ===================================================================================== --%>


        
<section class="login-signup block1 ">
    <div class="container">
        <div class="row align-items-center justify-content-center">
            <div class="col-lg-7">
                <div class="login">
                    <div class="text-center">  <h3 class="mt-4">Login Here</h3></div>

                    
                    <p class="mb-5">Enter your valid mail or user name & password</p>
                    <div class="login-form row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="loginemail">Email</label>
                                 <asp:TextBox ID="tbtaikhoan" runat="server" placeholder="Tài khoản" Height="50px" CssClass="form-control " value ="" required ></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label for="loginPassword">Password</label>
                            <asp:TextBox ID="tbmatkhau" runat="server" placeholder="Mật khẩu" Height="50px" TextMode="Password"  CssClass="form-control " value ="" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                             <asp:Button ID="btndangnhap" runat="server" Text="Đăng nhập" Width="200px" Cssclass="bDangnhap btn btn-info" Height="50px" OnClick="btndangnhap_Click" />
                      <p class="mt-5 mb-0">Not a member yet? <a href="Singup.aspx">Register Here</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
         <script type = "text/javascript">
         function validateForm()  {
             var u = document.getElementById("tbtaikhoan").value;
             var p = document.getElementById("tbmatkhau").value;

             if(u== "") {
                 alert("Hãy nhập Username");
                 return false;
             }
             if(p == "") {
                 alert("Hãy nhập Password");
                 return false;
             }

             return true;
             }

             
         </script>

    </form>
</body>
</html>
