<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_Web/Admin_Web.Master" AutoEventWireup="true" CodeBehind="User_Comment.aspx.cs" Inherits="Admin_Page_News.Admin_Web.WebForm7" %>
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
      .email-modal{
          color:blue;
      }
      .comment-modal{
          color:red;
      }
      .rep-modal{
          color:black
      }
   </style>
  

<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
          <div class="modal-title ">
                  <asp:TextBox ID="TB_ID"  CssClass="form-control" runat="server"></asp:TextBox>
              
          </div>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        
          <div class="form-group email-modal">
            <label  class="col-form-label">Email:</label>
            <asp:TextBox ID="recipient_email" CssClass="form-control" runat="server"></asp:TextBox>

          </div>
          <div class="form-group comment-modal">
            <label  class="col-form-label">Phan hoi</label>
            <asp:TextBox ID="recipient_comment" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
          <div class="form-group rep-modal">
            <label class="col-form-label">Message:</label>
            <asp:TextBox ID="message_text" TextMode="MultiLine" CssClass="form-control" runat="server"></asp:TextBox>
          </div>
        
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-outline-warning" data-dismiss="modal">Đóng</button>
        <asp:Button ID="Btn_Rep" runat="server" CssClass="btn btn-outline-success " OnClick="Btn_Rep_Click" Text="Phản hồi" />

      </div>
    </div>
  </div>
</div>
    <div>
    <asp:GridView ID="TB_Comment" runat="server" AutoGenerateColumns="False"  Width="100%" EnableViewState="False"
                DataKeyNames="CM_ID" 
                OnRowDeleting="Users_RowDeleting"
                OnPageIndexChanging="Users_PageIndexChanging"             
                AllowPaging="True" Height="100%"   
                CssClass="table table-bordered table-hover"
                >
                <PagerStyle CssClass="pagination-ys" />
                <Columns >
                   

                    <asp:TemplateField HeaderText="ID"  HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="2%" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                         <%#Eval("CM_ID") %>
                       </ItemTemplate>
                    </asp:TemplateField> 

                    <asp:TemplateField HeaderText="Tiêu đề bài viết" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="28%"  >
                       <ItemTemplate>
                       <%#Eval("News_Title") %>
                       </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="10%"  >
                       <ItemTemplate>
                            <%#Eval("CM_Email") %>
                          
                       </ItemTemplate>
                    </asp:TemplateField> 
               
                    <asp:TemplateField HeaderText="Nội dung bình luận" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%" >
                       <ItemTemplate>
                       <%#Eval("CM_Comment") %>
                       </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nội dung phản hồi" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="25%" >
                       <ItemTemplate>
                       <%#Eval("CM_Rep") %>
                       </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Rep" HeaderStyle-HorizontalAlign="Center" ItemStyle-Width="5%" >
                       <ItemTemplate>
                         <button type="button" style="width:100%" class="btn btn-outline-success" data-toggle="modal" data-target="#exampleModal" data-idcm=' <%#Eval("CM_ID") %>' data-emailmodal=' <%#Eval("CM_Email") %>' data-cmcomment=' <%#Eval("CM_Comment") %>'data-cmrep=' <%#Eval("CM_Rep") %>'>Rep</button>
                       </ItemTemplate>
                    </asp:TemplateField> 
    
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" HeaderText="Xóa" DeleteText="Xóa" HeaderStyle-HorizontalAlign="Justify" ItemStyle-Width="5%" ControlStyle-CssClass="btn btn-outline-danger" ItemStyle-HorizontalAlign="Center" ></asp:CommandField>               
                
                </Columns>
            </asp:GridView>
        </div>

     <script>
         $('#exampleModal').on('show.bs.modal', function (event) {
             var button = $(event.relatedTarget) 
             var recipient = button.data('cmcomment')
             var emailmodal = button.data('emailmodal')
             var cmid = button.data('idcm')
             var cmrep = button.data('cmrep')
             var modal = $(this)
             modal.find('.modal-title input').val(cmid)
             modal.find('.comment-modal textarea').val(recipient)
             modal.find('.email-modal input').val(emailmodal)
             modal.find('.rep-modal textarea').val(cmrep)
         })

       
     </script>    
     <script src="../Scripts/jquery-3.3.1.slim.min.js"></script>
    <script src="../Scripts/popper.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</asp:Content>
