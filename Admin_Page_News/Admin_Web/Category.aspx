<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Web/Admin_Web.Master" AutoEventWireup="true" CodeBehind="Category.aspx.cs" Inherits="Admin_Page_News.Admin_Web.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../Content/thongtinnguoidung.css" rel="stylesheet" />
     <style>
        .input-Tag
        {
            margin-bottom:15px;
        }
    </style>
    <div class="col-md-12 d-flex ">
        <div class="row">
        <div class="col-md-3">
         <div class="row">
            
              <%-- ======================================================================== --%>
             <div class=" col-md-12">

              <div class="thaotac">
                   <div class="anhnhap">
                    <asp:Image ID="Image1" runat="server" Width="100%" CssClass="image" ImageUrl="../images/kamen-rider-geats.png" />
                     <div class="overlay">
                       <asp:FileUpload ID="FileUpload1" CssClass="file-upload-input text1" onchange="docURL(this);" runat="server" />
                     </div>
                    </div>
                  </div>

              </div>

              <%-- ======================================================================== --%>
         
           <div class=" col-md-12">
              
             <div class="form-group">
                   <asp:TextBox ID="Tb_Tag_Name" runat="server" placeholder="Thể loại" Width="100%" CssClass="form-control" ></asp:TextBox>           
                 </div>
             <div class="d-flex">
                <asp:Button ID="Bt_Add" runat="server" Text="Thêm" Width="120px" Cssclass=" btn bg-primary-gradient input-Tag" Height="35px" OnClick="Bt_Them_Category_Click" />         
                <asp:Button ID="Bt_Sua" runat="server" Text="Sửa" Width="120px"  Cssclass=" btn bg-primary-gradient input-Tag" Height="35px" OnClick="Bt_Sua_Category_Click"  />         
             </div>
           
               </div>
             </div>
         </div>


         <div class="col-md-9">
           <h3>Danh sách Thể loại</h3>
          <asp:Label ID="Tag_thongbao" runat="server" ></asp:Label>
            <asp:GridView ID="Tags" runat="server" AutoGenerateColumns="False"  Width="100%" EnableViewState="False"
                DataKeyNames="Category_ID"
                OnRowDeleting="Tag_RowDeleting"
                OnRowEditing="Tag_RowEditing"
                OnPageIndexChanging   ="Tags_PageIndexChanging"              
                AllowPaging="True" Height="100%"     
                CssClass="table table-bordered table-hover"            
                >
                <PagerStyle CssClass="pagination-ys" />
                
                <Columns>
                   

                    <asp:TemplateField HeaderText="ID" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%">
                      <ItemTemplate>          
                              <asp:Label ID="Tag_ID" runat="server" Text='<%# Eval("Category_ID") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Tên chuyên mục" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%" >
                       <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Category_Name") %>'></asp:Label>
                        </ItemTemplate>                  
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="Avata" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="13%" >
                       <ItemTemplate>
                            
                           <asp:Image ID="Image1" runat="server" Width="100%" ImageUrl='<%# Eval("Category_Img") %>' />
                        </ItemTemplate>                  
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Số thể loại thuộc chuyên mục" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                        <asp:Label ID="Tag_ID" runat="server"  Text='<%#Eval("Category_Count") %>'></asp:Label>
                       </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:CommandField ControlStyle-CssClass="btn btn-outline-success"  ShowEditButton="true" ButtonType="Button" HeaderText="Sửa" EditText="Sửa" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>

                   <asp:CommandField ControlStyle-CssClass="btn btn-outline-danger" ShowDeleteButton="True" ButtonType="Button" HeaderText="Xóa" DeleteText="Xóa"  HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>
                   
                </Columns>
            </asp:GridView>
              </div>
        </div>
    </div>

     <script>
        function docURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('.nhap1').hide();
                    $('.image').attr('src', e.target.result);
                    $('.image').show();
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
      

     </script>

</asp:Content>
