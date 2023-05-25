<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Page/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Admin_Page_News.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainAdmin" runat="server">
    <style>
       .reset{
           float:right;
           margin-left:610px;
       }
      
   </style>
    <div>       
      <asp:TextBox ID="Tb_Seach" runat="server" Width="400px" Height="36px" placeholder="Tìm kiếm" CssClass="form-group-lg" ></asp:TextBox>                                          
      <asp:Button ID="Bnt_Seach" runat="server" Text="Tìm kiếm" OnClick="Bnt_Seach_Click" CssClass="btn bg-primary-gradient" />
      <asp:Button ID="Bnt_Reset" runat="server" Text="Reset" OnClick="Bnt_Reset_Click" CssClass="btn bg-primary-gradient reset" />
    </div>
    <br />
    <div  >
           <asp:GridView ID="Users" runat="server" AutoGenerateColumns="False"  Width="100%" EnableViewState="False"
                DataKeyNames="User_ID" 
                OnRowDeleting="Users_RowDeleting"
                OnRowEditing="Users_RowEditing" 
                OnPageIndexChanging="Users_PageIndexChanging"             
                AllowPaging="True" Height="100%"   
                CssClass="table table-bordered table-hover"
                >
                <PagerStyle CssClass="pagination-ys" />
                <Columns >
                   

                    <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                       <ItemTemplate>          
                    
                           <asp:Label ID="Tag_ID" runat="server" Text=' <%#Eval("User_ID") %>'></asp:Label>
                       </ItemTemplate> 
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                       <ItemStyle HorizontalAlign="Center"   />
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="User Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="180px"  >
                       <ItemTemplate>
                       <%#Eval("User_Name") %>
                       </ItemTemplate>    
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle Width="180px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="User Full Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="250px"  >
                       <ItemTemplate>
                       <%#Eval("User_Full_Name") %>
                       </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle Width="250px"></ItemStyle>
                    </asp:TemplateField> 
               
                    <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="250px" >
                       <ItemTemplate>
                       <%#Eval("Email") %>
                       </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                         <ItemStyle Width="250px"></ItemStyle>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Admin" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px" >
 
                       <ItemTemplate>
                     <%# Eval("Admin") %>
                       </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                         <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField> 

                    <asp:CommandField ControlStyle-CssClass="input_edit" ShowEditButton="true" ButtonType="Button" HeaderText="Sửa" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" ControlStyle-BackColor="Bisque"  >
                       <ControlStyle CssClass="input_delete"></ControlStyle>
                       <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                       <ItemStyle Width="100px"></ItemStyle>
                    </asp:CommandField>

                 <asp:CommandField ControlStyle-CssClass="input_delete" ShowDeleteButton="True" ButtonType="Button" HeaderText="Xóa" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="100px" ControlStyle-BackColor="Red"  >
                    <ControlStyle CssClass="input_edit"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                     <ItemStyle Width="100px"></ItemStyle>
                 </asp:CommandField>
                   
                   
                   
                </Columns>
            </asp:GridView>
        </div>


</asp:Content>
