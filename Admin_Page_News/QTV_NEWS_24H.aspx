<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QTV_NEWS_24H.aspx.cs" Inherits="Admin_Page_News.QTV_NEWS_24H" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link href="../Content/bootstrap.min.css" rel="stylesheet" />
   <%--  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
   --%>
    <link href="../Content/style.css" rel="stylesheet" />
    <link href="../Content/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../Content/plugins/slick-carousel/slick.css" rel="stylesheet" />
    <link href="../Content/plugins/slick-carousel/slick-theme.css" rel="stylesheet" />
    <link href="../Content/css/style.css" rel="stylesheet" />
    <link href="../Content/fontawesome-5.0.8/css/fontawesome-all.min.css" rel="stylesheet" />
    <link href="../Content/iconic/css/material-design-iconic-font.min.css" rel="stylesheet" />
    <link href="../Content/animate/animate.css" rel="stylesheet" />
    <link href="../Content/css-hamburgers/hamburgers.min.css" rel="stylesheet" />
    <link href="../Content/animsition/css/animsition.min.css" rel="stylesheet" />
    <link href="../Content/css/util.min.css" rel="stylesheet" />
    <link href="../Content/css/main.css" rel="stylesheet" />
    
    <link href="Content/thongtinnguoidung.css" rel="stylesheet" />
   


</head>
<body class="tn-img">
    <form id="form1" runat="server">
 <%-- <div class="file-upload">
   
    
      <div class="image-upload-wrap">
        <input class="file-upload-input" type='file' onchange="readURL(this);" accept="image/*" />
        <div class="drag-text">
          <h3>Drag and drop a file or select add Image</h3>
        </div>
      </div>
      <div class="file-upload-content">
        <img class="file-upload-image" src="#" alt="your image" />
        <div class="image-title-wrap">
          <button type="button" onclick="removeUpload()" class="remove-image">Remove <span class="image-title">Uploaded Image</span></button>
        </div>
      </div>
    </div>--%>
 
 <!--==============================================================================================================-->

   <div class="file-upload">
      <div class="image-upload-wrap">
        <input class="file-upload-input" type='file' onchange="readURL(this);" accept="image/*" />
        <div class="drag-text">
          <h3>Drag and drop a file or select add Image</h3>
        </div>
      </div>
      <div class="file-upload-content">
       
          <img class="file-upload-image" src="images/avata_user.png"  alt="your image" />
        <div class="image-title-wrap">
          <button type="button" onclick="removeUpload()" class="remove-image">Remove <span class="image-title">Uploaded Image</span></button>
        </div>
      </div>
    </div>

    </form>
    <script>
        function readURL(input) {
            if (input.files && input.files[0]) {

                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.image-upload-wrap').hide();

                    $('.file-upload-image').attr('src', e.target.result);
                    $('.file-upload-content').show();

                    $('.image-title').html(input.files[0].name);
                };

                reader.readAsDataURL(input.files[0]);

            } else {
                removeUpload();
            }
        }

        
            var iconheart = document.querySelector(".heart-icon")
            iconheart.onclick = function (e) {
                e.target.style.color = 'red'
            }
    
<%--<i class="heart-icon fa-solid fa-heart" ></i>--%>

        function removeUpload() {
            $('.file-upload-input').replaceWith($('.file-upload-input').clone());
            $('.file-upload-content').hide();
            $('.image-upload-wrap').show();
        }
        $('.image-upload-wrap').bind('dragover', function () {
            $('.image-upload-wrap').addClass('image-dropping');
        });
        $('.image-upload-wrap').bind('dragleave', function () {
            $('.image-upload-wrap').removeClass('image-dropping');
        });
    </script>
    <script src="../Content/plugins/jquery/jquery.js"></script>
    <script src="../Content/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="../Content/plugins/slick-carousel/slick.min.js"></script>
    <script src="../Content/plugins/google-map/gmap.js"></script>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCC72vZw-6tGqFyRhhg5CkF2fqfILn2Tsw"></script>
    <script src="../Content/js/custom.js"></script>
    <script src="../Content/jquery/jquery-3.2.1.min.js"></script>
    <script src="../Content/animsition/js/animsition.min.js"></script>
    <script src="../Content/bootstrap/js/popper.js"></script>
    <script src="../Content/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
