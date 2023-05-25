<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Web/Admin_Web.Master" AutoEventWireup="true" CodeBehind="List_News_QTV.aspx.cs" Inherits="Admin_Page_News.Admin_Web.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
       .reset{
           float:right;
           margin-left:610px;
       }
      
   </style>
  
   
    <div>       
        <h3>Tong bien tap</h3>
      <asp:DropDownList ID="DDL_Tag"  Width="200px"  Height="35px"  runat="server" OnSelectedIndexChanged="DDL_Tag_SelectedIndexChanged" AutoPostBack="True" CausesValidation="true" >  </asp:DropDownList>                                          
      |
       <asp:DropDownList ID="DDL_Bai_Viet" runat="server" Width="200px" Height="35px" AutoPostBack="true" OnSelectedIndexChanged="DDL_Bai_Viet_SelectedIndexChanged">
          <asp:ListItem ID="All_News"  runat="server" Text="Tất cả bài viết" Value="0"></asp:ListItem>
          <asp:ListItem ID="News_Hot"  runat="server" Text="Bài viết nổi bật" Value="1"></asp:ListItem>
          <asp:ListItem ID="Da_dang"  runat="server" Text="Bài viết đã đăng" Value="2"></asp:ListItem>
          <asp:ListItem ID="Chua_dang"  runat="server" Text="Bài viết chưa đăng" Value="3"></asp:ListItem>
      </asp:DropDownList>
      
    </div>
    <br />
    <div >

        
         <asp:GridView ID="News_Table" runat="server" AutoGenerateColumns="False"  Width="100%" EnableViewState="False"
                DataKeyNames="News_ID" 
                OnRowDeleting="News_RowDeleting"
                OnRowEditing="News_RowEditing"
                OnPageIndexChanging="News_PageIndexChanging"
                OnSelectedIndexChanging="News_Table_SelectedIndexChanging"
                AllowPaging="True" Height="100%" 
                CssClass="table table-bordered table-hover"
                >
                <PagerStyle CssClass="pagination-ys" />
                
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px">
                        <HeaderTemplate>
                          <asp:CheckBox ID="Ck_All" runat="server" OnCheckedChanged="Ck_All_Rows_CheckedChanged"  />
                        </HeaderTemplate>
                        <ItemTemplate>
                           <asp:CheckBox ID="Ck_One" runat="server" OnCheckedChanged="Ck_One_CheckedChanged"  />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>          
                       <%#Eval("News_ID") %>
                       </ItemTemplate>
                    </asp:TemplateField>             
                   
                    <asp:TemplateField HeaderText="Tiêu đề" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="40%" >
                       <ItemTemplate>
                       <%#Eval("News_Title") %>
                       </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Avata" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" >
                       <ItemTemplate>  
                          <div style="max-height:60px;max-width:100px;overflow:hidden;">
                           <asp:Image ID="Image1" runat="server" ImageUrl=' <%#Eval("News_Avata") %>' Width="100px" />
                          </div>
                       </ItemTemplate>                   
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Thể loại" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" >             
                        <ItemTemplate>
                       <%#Eval("Tag_Name") %>
                       </ItemTemplate>
                    </asp:TemplateField> 
               
                    <asp:TemplateField HeaderText="Ngày viết" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="15%" >
                       <ItemTemplate>
                       <%#Eval("News_Edit_Date") %>
                       </ItemTemplate>
                    </asp:TemplateField>           

                    <asp:TemplateField HeaderText="Hot" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%" >                                                                  
                        <ItemStyle HorizontalAlign="Center"   />
                         <ItemTemplate>
                             <asp:CheckBox ID="CB_Hot" runat="server" Checked='<%# Eval("News_Hot") %>'  />                        
                         </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%" >
                       <ItemStyle HorizontalAlign="Center"   />
                        <ItemTemplate >
                        <asp:CheckBox ID="CB_Status" runat="server" Checked='<%#Eval("News_Status") %>'  />
                       </ItemTemplate>
                    </asp:TemplateField> 

                  <asp:CommandField  ShowSelectButton="true" ButtonType="Button" HeaderText="Xem" SelectText="Xem" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="70px" ControlStyle-CssClass="btn btn-outline-primary" ></asp:CommandField>
                  <asp:CommandField  ShowEditButton="true" ButtonType="Button" HeaderText="Đăng" EditText="Đăng" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="70px" ControlStyle-CssClass="btn  btn-outline-success" ></asp:CommandField>
                  <asp:CommandField  ShowDeleteButton="True" ButtonType="Button" HeaderText="Xóa" DeleteText="Xóa" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="70px" ControlStyle-CssClass="btn btn-outline-danger" ></asp:CommandField>               
                </Columns>
            </asp:GridView>
        </div>
    
</asp:Content>
