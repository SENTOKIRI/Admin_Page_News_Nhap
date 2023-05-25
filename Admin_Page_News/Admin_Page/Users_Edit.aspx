<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Page/Admin.Master" AutoEventWireup="true" CodeBehind="Users_Edit.aspx.cs" Inherits="Admin_Page_News.Admin_Page.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainAdmin" runat="server">
  
     <div >
         <h4 style="padding-right:960px">Thông tin người dùng</h4>
                 
           <h5>User Name</h5>
               <asp:TextBox ID="Tb_User_Name" runat="server" Width="500px" Font-Size="Larger" CssClass="form-control form-control-navbar"></asp:TextBox >
               <asp:RequiredFieldValidator ErrorMessage="Không được để trống!" ControlToValidate="Tb_User_Name" runat="server" CssClass="RequiValidatepass" ForeColor="Red" />
            
         
           <h5>PassWord</h5>                  
              <asp:TextBox ID="Tb_Password" runat="server" Width="500px" Font-Size="Larger" CssClass="form-control form-control-navbar"></asp:TextBox>
              <asp:RequiredFieldValidator ErrorMessage="Không được để trống!" ControlToValidate="Tb_Password" runat="server" CssClass="RequiValidatepass" ForeColor="Red" />
           
        
           <h5>User Full Name</h5>         
               <asp:TextBox ID="Tb_User_Full_Name" runat="server" Width="500px" Font-Size="Larger" CssClass="form-control form-control-navbar"></asp:TextBox>
               <asp:RequiredFieldValidator ErrorMessage="Không được để trống!" ControlToValidate="Tb_User_Full_Name" runat="server" CssClass="RequiValidatepass" ForeColor="Red" />
            
        
           <h5>Email</h5>                 
               <asp:TextBox ID="Tb_Email" runat="server" Width="500px" Font-Size="Larger" TextMode="Email" CssClass="form-control form-control-navbar"></asp:TextBox>
               <asp:RequiredFieldValidator ErrorMessage="Không được để trống!" ControlToValidate="Tb_Email" runat="server" CssClass="RequiValidatepass" ForeColor="Red" />
            
                            
         
          <h5>Admin</h5> 
          <asp:CheckBox ID="Cb_User_Admin" runat="server"  Font-Size="Larger" type="checkbox"   />
            <br />
         <br />
        
        <asp:Button ID="Bt_Sua" runat="server" Text="Sửa" Width="200px" Font-Size="Larger"  Cssclass="btn bg-primary-gradient" Height="40px"  OnClick="Bt_Sua_User_Click"  />
       
            <br />
            <br />
        </div>
</asp:Content>
