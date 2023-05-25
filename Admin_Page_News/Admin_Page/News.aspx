<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Page/Admin.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Admin_Page_News.WebForm3" %>
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
    <div >
         <asp:GridView ID="News_Table" runat="server" AutoGenerateColumns="False"  Width="100%" EnableViewState="False"
                DataKeyNames="News_ID" 
                OnRowDeleting="News_RowDeleting"
                OnRowEditing="News_RowEditing"
                OnPageIndexChanging="News_PageIndexChanging"              
                AllowPaging="True" Height="100%" 
                CssClass="table table-bordered table-hover"
                >
                <PagerStyle CssClass="pagination-ys" />
                
                <Columns>
                    <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="30px">
                       <ItemTemplate>          
                       <%#Eval("News_ID") %>
                       </ItemTemplate>
                          <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                       <ItemStyle HorizontalAlign="Center"   />
                    </asp:TemplateField>             
                   
                    <asp:TemplateField HeaderText="Title" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="450px" >
                       <ItemTemplate>
                       <%#Eval("News_Title") %>
                       </ItemTemplate>
                         <HeaderStyle HorizontalAlign="Center"></HeaderStyle>                  
                      <ItemStyle Width="450px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Avata" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="100px" >
                       <ItemTemplate>                   
                           <asp:Image ID="Image1" runat="server" ImageUrl=' <%#Eval("News_Avata") %>' Width="90" />
                       </ItemTemplate>                   
                         <HeaderStyle HorizontalAlign="Center"></HeaderStyle>                  
                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Tag Name" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="180px" >             
                        <ItemTemplate>
                       <%#Eval("Tag_Name") %>
                       </ItemTemplate>                                           
                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                         <ItemStyle Width="180px"></ItemStyle>
                    </asp:TemplateField> 
                  
                    <asp:TemplateField HeaderText="Create date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="110px" >
                       <ItemTemplate>
                       <%#Eval("News_Create_Date") %>
                       </ItemTemplate>                        
                       <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                        <ItemStyle Width="110px"></ItemStyle>
                    </asp:TemplateField> 
               
                    <asp:TemplateField HeaderText="Edit date" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="110px" >
                       <ItemTemplate>
                       <%#Eval("News_Edit_Date") %>
                       </ItemTemplate>                        
                       <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                         <ItemStyle Width="110px"></ItemStyle>
                    </asp:TemplateField>           

                    <asp:TemplateField HeaderText="Hot" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="70px" >                      
                                             
                        <ItemStyle HorizontalAlign="Center"   />
                         <ItemTemplate>
                             <asp:CheckBox ID="CB_Hot" runat="server" Checked='<%# Eval("News_Hot") %>'  />                        
                         </ItemTemplate>
                       <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="70px" >
                       <ItemTemplate>
                        <asp:CheckBox ID="CB_Status" runat="server" Checked='<%#Eval("News_Status") %>'  />
                       </ItemTemplate>                       
                        <ItemStyle HorizontalAlign="Center"   />
                       <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                    </asp:TemplateField> 

                  <asp:CommandField ControlStyle-CssClass="input_edit btn" ShowEditButton="true" ButtonType="Button" HeaderText="Sửa" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="60px" ControlStyle-BackColor="Bisque" >
                       <ControlStyle CssClass="input_delete"></ControlStyle>
                       <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                       <ItemStyle Width="60px"></ItemStyle>
                    </asp:CommandField>

                 <asp:CommandField ControlStyle-CssClass="input_delete btn" ShowDeleteButton="True" ButtonType="Button" HeaderText="Xóa" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px" ControlStyle-BackColor="Red" >
                    <ControlStyle CssClass="input_edit"></ControlStyle>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>

                     <ItemStyle Width="80px"></ItemStyle>
                 </asp:CommandField>
                   
                   
                   
                </Columns>
            </asp:GridView>
       
    </div>
</asp:Content>
