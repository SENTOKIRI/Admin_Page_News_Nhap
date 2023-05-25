<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Page/Admin.Master" AutoEventWireup="true" CodeBehind="Tag.aspx.cs" Inherits="Admin_Page_News.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainAdmin" runat="server">
    <style>
        .input-Tag
        {
            margin-bottom:15px;
        }
    </style>
    <div style="padding:10px" class="col-md-10 ">
        <asp:Label ID="Lb_check" runat="server" ></asp:Label>
        <div>     
              <asp:TextBox ID="Tb_Tag_Name" runat="server" placeholder="Tag Name" Width="350px" CssClass="form-control form-control-navbar" Font-Size="Larger"></asp:TextBox>
              <asp:RequiredFieldValidator ErrorMessage="Không được để trống!" ControlToValidate="Tb_Tag_Name" runat="server" CssClass="RequiValidatepass" ForeColor="Red" />
            <br />
            <asp:Button ID="Bt_Add" runat="server" Text="Thêm" Width="120px" Cssclass=" btn bg-primary-gradient input-Tag" Height="35px" OnClick="Bt_Them_Tag_Click" />         
            <asp:Button ID="Bt_Sua" runat="server" Text="Sửa" Width="120px"  Cssclass=" btn bg-primary-gradient input-Tag" Height="35px" OnClick="Bt_Sua_Tag_Click"  />         
           <br />
           </div>
           <h3>Danh sách thẻ Tag</h3>
          <asp:Label ID="Tag_thongbao" runat="server" ></asp:Label>
          
            <asp:GridView ID="Tags" runat="server" AutoGenerateColumns="False"  Width="100%" EnableViewState="False"
                DataKeyNames="Tag_ID"
                OnRowDeleting="Tag_RowDeleting"
                OnRowEditing="Tag_RowEditing"
                OnPageIndexChanging   ="Tags_PageIndexChanging"              
                AllowPaging="True" Height="100%"     
                CssClass="table table-bordered table-hover"            
                >
                <PagerStyle CssClass="pagination-ys" />
                
                <Columns>
                   

                    <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px">
                       <ItemStyle HorizontalAlign="Center"   />
                        
                        <ItemTemplate>          
                              <asp:Label ID="Tag_ID" runat="server" Text='<%# Eval("Tag_ID") %>'></asp:Label>
                       </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                       <ItemStyle HorizontalAlign="Center"   />
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Tag Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="700px" >
                    
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Tag_Name") %>'></asp:Label>
                        </ItemTemplate>                               
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                          <ItemStyle Width="700px"></ItemStyle>                  
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Số bài viết" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="500px" >
                        
                       <ItemTemplate>
                      
                        <asp:Label ID="Tag_ID" runat="server" Text='<%#Eval("Tag_Count") %>'></asp:Label>
                           
                       </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                       <ItemStyle HorizontalAlign="Center"   />

                        
                    </asp:TemplateField> 

                    <asp:CommandField ControlStyle-CssClass="input_edit" ShowEditButton="true" ButtonType="Button" HeaderText="Sửa" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="350px" ControlStyle-BackColor="Bisque"  >
                       <ControlStyle CssClass="input_delete"></ControlStyle>
                       <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                         <ItemStyle HorizontalAlign="Center"   />
                         
                    </asp:CommandField>

                 <asp:CommandField ControlStyle-CssClass="input_delete" ShowDeleteButton="True" ButtonType="Button" HeaderText="Xóa" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="350px" ControlStyle-BackColor="Red" >
                    <ControlStyle CssClass="input_edit"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                      <ItemStyle HorizontalAlign="Center"   />
                 </asp:CommandField>
                   
                   
                   
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
