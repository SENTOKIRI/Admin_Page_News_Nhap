<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Web/Admin_Web.Master" AutoEventWireup="true" CodeBehind="Tag_News.aspx.cs" Inherits="Admin_Page_News.Admin_Web.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .input-Tag
        {
            margin-top:15px;
           text-align:center;
           width:120px;

        }
        .tb-ddl{
            display:inline-flex;
        }
    </style>
    <div style="padding:10px" class="col-md-10 ">
        <asp:Label ID="Lb_check" runat="server" ></asp:Label>
        <div>  
            <div class="tb-ddl">
            <asp:TextBox ID="Tb_Tag_Name" runat="server" placeholder="Thể loại" value ="" required Width="350px" CssClass="input-group form-control" Font-Size="Larger"></asp:TextBox> 
            </div>
            <div class="tb-ddl">
             <asp:DropDownList ID="DDL_Category"  Width="200px"  Height="35px"  runat="server" OnSelectedIndexChanged="DDL_Category_SelectedIndexChanged" AutoPostBack="True" CausesValidation="true" >  </asp:DropDownList> 
            </div>
            <div class="tb-ddl"> 
            </div>
            <div>
            <asp:Button ID="Bt_Add" runat="server" Text="Thêm"  Cssclass=" btn bg-primary-gradient  input-Tag"  Height="35px" OnClick="Bt_Them_Tag_Click" />         
            <asp:Button ID="Bt_Sua" runat="server" Text="Sửa"   Cssclass=" btn bg-success  input-Tag" Height="35px" OnClick="Bt_Sua_Tag_Click"  />         
            </div>
           </div>
            <br />
           </div>
           <h3>Danh sách Thể loại</h3>
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
                        <ItemTemplate>          
                           <asp:Label ID="Tag_ID" runat="server" Text='<%# Eval("Tag_ID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Thể loại" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="700px" >
                       <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Eval("Tag_Name") %>'></asp:Label>
                       </ItemTemplate>  
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Chuyên mục" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="500px" >
                       <ItemTemplate>
                          <asp:Label ID="Label1" runat="server" Text='<%# Eval("Category_Name") %>'></asp:Label>
                       </ItemTemplate>  
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Số bài viết" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="500px" ItemStyle-HorizontalAlign="Center" >               
                       <ItemTemplate>   
                        <asp:Label ID="Tag_ID" runat="server" Text='<%#Eval("Tag_Count") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:CommandField ControlStyle-CssClass="btn btn-outline-success"  ShowEditButton="true" ButtonType="Button" HeaderText="Sửa" EditText="Sửa" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>

                    <asp:CommandField ControlStyle-CssClass="btn btn-outline-danger" ShowDeleteButton="True" ButtonType="Button" HeaderText="Xóa" DeleteText="Xóa"  HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>
                   
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
