<%@ Page Title="" Language="C#" MasterPageFile="~/Content_Creator/ContentCreator.Master" AutoEventWireup="true" CodeBehind="list_news.aspx.cs" Inherits="Admin_Page_News.Content_Creator.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
      .inline{
          display:inline;
      }
      
   </style>
    <div  >       
        <span style="font-size:25px; margin-bottom:10px;">Danh sách tin của : <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> </span>
        
     <div >
      <asp:DropDownList ID="DDL_Tag" CssClass="inline" Width="200px" Height="35px"  runat="server" OnSelectedIndexChanged="DDL_Tag_SelectedIndexChanged" AutoPostBack="True" CausesValidation="true" >         
      </asp:DropDownList>                                          
      <h3 class="inline">|</h3>
      <asp:DropDownList ID="DDL_Bai_Viet" CssClass="inline" runat="server" Width="200px" Height="35px" AutoPostBack="true" OnSelectedIndexChanged="DDL_Bai_Viet_SelectedIndexChanged">
          <asp:ListItem ID="All_News"   runat="server" Text="Tất cả bài viết" Value="1"></asp:ListItem>
          <asp:ListItem ID="Da_duyet"   runat="server" Text="Bài viết đã duyệt" Value="2"></asp:ListItem>
          <asp:ListItem ID="Chua_duyet" runat="server" Text="Bài viết chưa duyệt" Value="3"></asp:ListItem>
      </asp:DropDownList>
     </div>
           
           
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

                    <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px">
                       <ItemTemplate>          
                       <%#Eval("News_ID") %>
                       </ItemTemplate>
                    </asp:TemplateField>             
                   
                    <asp:TemplateField HeaderText="Tiêu đề" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="450px" >
                       <ItemTemplate>
                       <%#Eval("News_Title") %>
                       </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Avata" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" >
                       <ItemTemplate> 
                          <div style="max-height:60px;max-width:100px;overflow:hidden;">
                           <asp:Image ID="Image1" runat="server" ImageUrl=' <%#Eval("News_Avata") %>' Width="100px"  />
                          </div>
                       </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Thể loại" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="180px" >             
                        <ItemTemplate>
                       <%#Eval("Tag_Name") %>
                       </ItemTemplate>
                    </asp:TemplateField> 
                  
                    <asp:TemplateField HeaderText="Ngày tạo" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="110px" >
                       <ItemTemplate>
                       <%#Eval("News_Create_Date") %>
                       </ItemTemplate>
                    </asp:TemplateField>          

                    <asp:TemplateField HeaderText="Hot" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" >                      
                       <ItemTemplate>
                             <asp:CheckBox ID="CB_Hot" runat="server" Checked='<%# Eval("News_Hot") %>'  />                        
                         </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Đăng" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" >
                       <ItemTemplate>
                        <asp:CheckBox ID="CB_Status" runat="server" Checked='<%#Eval("News_Status") %>'  />
                       </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:TemplateField HeaderText="Duyệt" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" >
                       <ItemTemplate>
                        <asp:CheckBox ID="CB_Duyet" runat="server" Checked='<%#Eval("News_Duyet") %>'  />
                       </ItemTemplate>
                    </asp:TemplateField>

                 <asp:CommandField ControlStyle-CssClass="btn-outline-primary btn"   ShowSelectButton="true" ButtonType="Button" HeaderText="Xem" SelectText="Xem" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>
                      
                  <asp:CommandField ControlStyle-CssClass=" btn-outline-success btn"  ShowEditButton="true" ButtonType="Button" HeaderText="Sửa" EditText="Sửa" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>

                 <asp:CommandField ControlStyle-CssClass=" btn-outline-danger btn" ShowDeleteButton="True" ButtonType="Button" HeaderText="Xóa" DeleteText="Xóa"  HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="5%" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>
                   
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
