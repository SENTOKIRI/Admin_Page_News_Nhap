<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Web/Admin_Web.Master" AutoEventWireup="true" CodeBehind="User_QL.aspx.cs" Inherits="Admin_Page_News.Admin_Web.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
       .reset{
           float:right;
           display:inline-flex;
       }
      .tb-ddl{
            display:inline-flex;
            margin-right:50px;
        }
      .tb-ddl-1{
            display:inline-flex;
            margin-right:5px;
        }
   </style>
    <Script Language = "JavaScript">
        function HienThi() // Khai báo một hàm tên là HienThi
        var check = document.getElementById('Tb_Seach').textContent
        {
            if (check = null) { alert("Bạn hãy nhập vào ô text và thử lại !"); }
           
             }

    </Script>
    <div>
       <div class="tb-ddl-1">
         <asp:TextBox ID="Tb_Seach" runat="server" Width="300px" Height="35px"   placeholder="Tìm kiếm" CssClass="form-group-lg form-control" ></asp:TextBox>                                          
        </div>
       <div class="tb-ddl">
           <asp:Button ID="Bnt_Seach" runat="server" Text="Tìm kiếm" OnClick="Bnt_Seach_Click" onchange= "HienThi()"  CssClass="btn bg-primary-gradient" />
        </div>
       <div class="tb-ddl-1">
          <asp:Label ID="Lb_User_Edit" runat="server" Font-Size="20px" Text="Họ và tên"></asp:Label>
           </div>
       <div class="tb-ddl-1">
          <asp:DropDownList ID="DDL_Phan_Quyen" Width="200px"  Height="35px" runat="server" OnSelectedIndexChanged="DDL_Phan_Quyen_SelectedIndexChanged" AutoPostBack="True" CausesValidation="true">
               <asp:ListItem ID="Phan_quyen"  runat="server" Text="Phân quyền" Value="0"></asp:ListItem>
               <asp:ListItem ID="LI_TBT"  runat="server" Text="Tổng biên tập"  Value="1"></asp:ListItem>
               <asp:ListItem ID="LI_BTV"  runat="server" Text="Biên tập viên"  Value="2"></asp:ListItem>
               <asp:ListItem ID="LI_CTV"  runat="server" Text="Cộng tác viên"  Value="3"></asp:ListItem>
               <asp:ListItem ID="LI_ND"   runat="server" Text="Người dùng"     Value="4"></asp:ListItem>
          </asp:DropDownList>
          </div>
       <div class="tb-ddl">
          <asp:Button ID="btn_sua" runat="server" Text="Cập nhật" OnClick="btn_sua_Click" CssClass="btn bg-success" />
         </div>
       <div class="reset">
          <asp:Button ID="Bnt_Reset" runat="server" Text="Reset" OnClick="Bnt_Reset_Click"  CssClass="btn btn-secondary" />
        </div>
    
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
                   

                    <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="4%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>          
                    
                           <asp:Label ID="Tag_ID" runat="server" Text=' <%#Eval("User_ID") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Tài khoản" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%"  >
                       <ItemTemplate>
                       <%#Eval("User_Name") %>
                       </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Họ và tên" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%"  >
                       <ItemTemplate>
                       <%#Eval("User_Full_Name") %>
                       </ItemTemplate>
                    </asp:TemplateField> 
               
                    <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
                       <ItemTemplate>
                       <%#Eval("Email") %>
                       </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Vai trò người dùng" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="20%" >
 
                       <ItemTemplate>
                     <%# Eval("Admin") %>
                       </ItemTemplate>
                    </asp:TemplateField> 

                   <asp:CommandField  ShowEditButton="true" ButtonType="Button" HeaderText="Sửa" EditText="Sửa" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="8%" ControlStyle-CssClass="btn btn-outline-success" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>
                   <asp:CommandField  ShowDeleteButton="True" ButtonType="Button" HeaderText="Xóa" DeleteText="Xóa" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="8%" ControlStyle-CssClass="btn btn-outline-danger" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>               
                
                </Columns>
            </asp:GridView>
        </div>



</asp:Content>
