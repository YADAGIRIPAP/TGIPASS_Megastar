<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmuserlogin.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: TSiPASS ::</title>
<meta name="viewport" content="width=device-width, initial-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="keywords" content="Realist Responsive web template, Bootstrap Web Templates, Flat Web Templates, Andriod Compatible web template, 
Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>


    <a href="Resource/Styles/Site/fonts/fontawesome-webfont.ttf">Resource/Styles/Site/fonts/fontawesome-webfont.ttf</a>
    <a href="Resource/Styles/Site/fonts/FontAwesome.otf">Resource/Styles/Site/fonts/FontAwesome.otf</a>
    <link href="Resource/Styles/Site/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Styles/Site/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Styles/Site/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script src="Resource/Styles/Site/easyResponsiveTabs.js" type="text/javascript"></script>
    <script src="Resource/Styles/Site/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="Resource/Styles/Site/responsiveslides.min.js" type="text/javascript"></script>
    <link href="Resource/Styles/Site/style.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Styles/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    

   <%-- <a href="Resource/Site/fonts/fontawesome-webfont.ttf">Resource/Site/fonts/fontawesome-webfont.ttf</a>
    <a href="Resource/Site/fonts/FontAwesome.otf">Resource/Site/fonts/FontAwesome.otf</a>    
    <link href="Resource/Site/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Site/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="Resource/Site/easyResponsiveTabs.js" type="text/javascript"></script>
    <link href="Resource/Site/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script src="Resource/Site/jquery-1.11.1.min.js" type="text/javascript"></script>
    <script src="Resource/Site/responsiveslides.min.js" type="text/javascript"></script>
    <link href="Resource/Site/style.css" rel="stylesheet" type="text/css" />
    <link href="Resource/css/bootstrap.min.css" rel="stylesheet" type="text/css" />--%>
    
<script>
    $(function () {
      $("#slider").responsiveSlides({
      	auto: true,
      	nav: true,
      	speed: 500,
        namespace: "callbacks",
        pager: true,
      });
    });
</script>
 
		    <script type="text/javascript">
		        $(document).ready(function() {
		            $('#horizontalTab').easyResponsiveTabs({
		                type: 'default', //Types: default, vertical, accordion           
		                width: 'auto', //auto or any width like 600px
		                fit: true   // 100% fit in a container
		            });
		        });
</script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 100%;
            background-color: #F0F0F0;
            height: 79px;
        }
        .style3
        {
            width: 86%;
        }
        .style4
        {
            width: 253px;
        }
        .style5
        {
            width: 813px;
        }
        .style6
        {
            width: 117px;
        }
        .style7
        {
            width: 407px;
        }
        .style9
        {
            width: 550px;
        }
        .style10
        {
            width: 119px;
        }
    </style>
</head>
<body>
<div class="header">
<nav class="navbar navbar-default navbar-fixed-top" >
	<div class="col-xs-4">
	  <div class="logo">
		<a href="index.aspx"><img src="resource/images/logo.png" alt=""/></a>
	  </div>
	</div>
	<div class="col-xs-8 header_right">
	  <span class="menu"></span>
			<div class="top-menu">
				<ul>
					<li><a class="active scroll" href="index.html"><i class="fa fa-home"> </i>Home</a></li>
					<li><a href="about.html"><i class="fa fa-star"> </i> About</a></li>
					<li><a href="services.html"><i class="fa fa-thumbs-up"> </i>Services</a></li>
					<li><a href="gallery.html"><i class="fa fa-picture-o"> </i>Gallery</a></li>
					<li><a href="contact.html"><i class="fa fa-envelope-o"> </i>Contact</a></li>
					<li><a href="frmuserlogin.aspx"><i class="fa fa-envelope-o"> </i>Login</a></li>
					<div class="clearfix"></div>
				</ul>
			 </div>
			<!-- script for menu -->
				<script>
				$( "span.menu" ).click(function() {
				  $( ".top-menu" ).slideToggle( "slow", function() {
				    // Animation complete.
				  });
				});
			</script>
			<!-- script for menu -->
	</div>
	<div class="clearfix"> </div>
</div>
</nav>

<form id="Form1" runat="server">
<div class="slider" style=" padding-top:56px">
	  <div class="callbacks_container">
	      <ul class="rslides" id="slider">
	        <%--<li><img src="Resource/images/banner.jpg" class="style1" alt="" style="max-width: 100%;"/>
	        
			</li>
	        <li><img src="Resource/images/banner1.jpg" class="style1" alt="" style="max-width: 100%;"/>--%>
	     
	        </li>
	        <li><img src="Resource/images/banner2.jpg" class="style1" alt="" style="max-width: 100%;"/>
	       
			 </li>
			 
			 <li><img src="Resource/images/banner3.jpg" class="style1" alt="" style="max-width: 100%;"/>
	     
			 </li>
	      </ul>
	 </div>
</div>
<table cellpadding="0" cellspacing="0" class="style2">
    <tr>
        <td>
            <table align="center" cellpadding="15" cellspacing="10" class="style3">
                <tr>
                    <td class="style5">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15pt" 
                            ForeColor="#1DB7FF" Text="Login Details"></asp:Label>
                    </td>
                    <td class="style6">
                        <asp:Image ID="Image2" runat="server" 
                            ImageUrl="~/Resource/Images/usericon.png" />
                    </td>
                    <td class="style9">
                        <%--<asp:TextBox ID="txtUserId" runat="server" class="text" value="E-mail address" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'E-mail address';}"></asp:TextBox>--%>
                        
                        <asp:TextBox ID="txtUserId" runat="server" class="form-control txtbox" 
                                                            Height="40px" MaxLength="40"  TabIndex="1" 
                                                            ValidationGroup="group" Width="283px"></asp:TextBox>
                        
                    </td>
                    <td class="style10">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Resource/Images/pwd.png" />
                    </td>
                    <td class="style7">
                        <asp:TextBox ID="txtPwd" runat="server" class="form-control txtbox" 
                                                            Height="40px" MaxLength="40"  TabIndex="1" 
                                                            ValidationGroup="group" Width="283px" 
                            TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
		                <asp:ImageButton ID="btnSignIn" runat="server" 
                            ImageUrl="~/Resource/Images/loginbtn.jpg" onclick="btnSignIn_Click1" />
		
		            </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</form>


</body>
</html>
