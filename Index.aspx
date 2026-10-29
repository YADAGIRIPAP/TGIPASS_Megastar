<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: TSiPASS ::</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="keywords" content="Industries Telangana" />

    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>

    <link href="Resource/Styles/Site/fonts/fontawesome-webfont.ttf" />
    <link href="Resource/Styles/Site/fonts/FontAwesome.otf" />
    <link href="Resource/Styles/Site/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Styles/Site/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Styles/Site/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <script src="Resource/Styles/Site/easyResponsiveTabs.js" type="text/javascript"></script>

    <script src="Resource/Styles/Site/jquery-1.11.1.min.js" type="text/javascript"></script>

    <script src="Resource/Styles/Site/responsiveslides.min.js" type="text/javascript"></script>

    <link href="Resource/Styles/Site/NewStyle.css" rel="stylesheet" type="text/css" />
    <link href="Resource/Styles/css/bootstrap.minA.css" rel="stylesheet" type="text/css" />
    <style>
        .button
        {
            background-color: #4CAF50; /* Green */
            border: none;
            color: white;
            padding: 16px 5px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            height:60px;
            -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
            cursor: pointer;
        }
        .button1
        {
            background-color: #9b59b6;
            width: 19%;
            color: white;
            border: 1px solid #9b59b6;
        }
        .button1:hover
        {
            background-color: #9b59b6;
            color: white;
        }
        .button2
        {
            background-color: #5659C9;
            width: 20%;
            color: white;
            border: 1px solid #5659C9;
        }
        .button2:hover
        {
            background-color: #5659C9;
            color: white;
        }
        .button3
        {
            background-color: #16a085;
            width: 20%;
            color: white;
            border: 1px solid #16a085;
        }
        .button3:hover
        {
            background-color: #16a085;
            color: white;
        }
        .button4
        {
            background-color: #C63D0F;
            width: 19%;
            color: white;
            border: 1px solid #C63D0F;
        }
        .button4:hover
        {
            background-color: #C63D0F;
        }
        .button5
        {
            background-color: #D8335B;
            width: 19%;
            color: white;
            border: 1px solid #D8335B;
        }
        .button5:hover
        {
            background-color: #D8335B;
            color: white;
        }
    </style>
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

    <%--<style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style3
        {
            width: 60%;
        }
        .style6
        {
            width: 117px;
        }
        .style9
        {
            width: 160px;
            padding: 10px;
        }
        .style10
        {
            width: 83px;
        }
        .style11
        {
            width: 118px;
            padding-right: 10px;
            height: 40px;
        }
        .style12
        {
            width: 1px;
        }
        .style13
        {
            padding: 10px;
        }
    </style>--%>
</head>
<body>
    <form id="Form1" style="width:100%" runat="server">
    <div class="header">
                <table align="center" cellpadding="15" cellspacing="10" class="style3">
                    <tr align="left">
                    <td
                        <a href="index.aspx">
                            <img src="images/Header_logo.png" alt="" /></a>
                            </td>
                            <td>
                            <table align="center" cellpadding="15" cellspacing="10"  style="width: 50%">
                              <tr align="right">
                        <%--<td class="style5">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="15pt" 
                            ForeColor="#1DB7FF" Text="Login Details"></asp:Label>
                    </td>--%>
                        <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Style="color: #d74995;" Font-Size="15pt"
                                ForeColor="#1DB7FF" Text="Username"></asp:Label>
                        </td>
                        <td>
                            <%--<asp:TextBox ID="txtUserId" runat="server" class="text" value="E-mail address" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'E-mail address';}"></asp:TextBox>--%>
                            <asp:TextBox ID="txtUserId" runat="server" class="form-control txtbox" Height="28px"
                                MaxLength="40" TabIndex="1" ValidationGroup="group" Width="150px"></asp:TextBox>
                        </td>
                        <td >
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Style="color: #d74995;" Font-Size="15pt"
                                ForeColor="#1DB7FF" Text="Password"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPwd" runat="server" class="form-control txtbox" Height="28px"
                                MaxLength="40" TabIndex="1" ValidationGroup="group" Width="150px" TextMode="Password"></asp:TextBox>
                            <asp:Label ID="lblmsg" runat="server" CssClass="LBLSTATUS" Font-Size="Small" ForeColor="Red"></asp:Label>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnSignIn" runat="server" ImageUrl="~/Resource/Images/loginbtn.png"
                                OnClick="btnSignIn_Click" Width="114px" />
                        </td>
                        <td class="style12">
                            &nbsp;
                        </td>
                    </tr>
                            </table>
                            </td>
                    </tr>
                    
                  
                </table>
            <%--<div class="col-xs-8 header_right">
	  <span class="menu"></span>
			
			<!-- script for menu -->
				<script>
				$( "span.menu" ).click(function() {
				  $( ".top-menu" ).slideToggle( "slow", function() {
				    // Animation complete.
				  });
				});
			</script>
			<!-- script for menu -->
	</div>--%>
            
    </div>
    <div class="slider" style="width:100%;">
            <ul class="rslides" id="slider">
                <li>
                    <img src="images/ts-ipass1.jpg" class="style1" alt="" style="max-width: 100%;" />
                </li>
                <li>
                    <img src="images/ts-ipass2.jpg" class="style1" alt="" style="max-width: 100%;" />
                </li>
                <li>
                    <img src="images/ts-ipass3.jpg" class="style1" alt="" style="max-width: 100%;" />
                </li>
                <%--<li><img src="images/ts-ipass4.jpg" class="style1" alt="" style="max-width: 100%;"/>--%>
                <li>
                    <img src="images/ts-ipass5.jpg" class="style1" alt="" style="max-width: 100%;" />
                </li>
            </ul>
    </div>
   
    <div style="border: 10px; width: 100%; border-bottom-color: Red;">
        <table style="background-color: #d74995; width: 100%">
            <tr style="width: 100%">
                <button formaction="docs/CFE and CFO Clearances_Revised.pdf" class="button button1">
                    APPROVALS</button>
                <button formaction="#" class="button button2">
                    INCENTIVES</button>
                <button formaction="#" class="button button3">
                    GRIEVANCES</button>
                <button formaction="#" class="button button4">
                    INSPECTION</button>
                <button formaction="#" class="button button5">
                    RAW MATERIAL</button></tr>
        </table>
    </div>
    <table style="width: 100%; background-color: #8F9092;">
        <tr style="width: 100%; background-color: #8F9092;">
            <th scope="row" style="padding: 5px; width: 50%; margin: 7px; background-color: #8F9092;
                font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: 500;
                color: #FFFFFF;" align="left">
                © Copyrights and all rights reserved by TS-iPASS.
            </th>
            <th scope="row" style="padding: 7px; text-align: right; width: 50%; margin: 7px;
                background-color: #8F9092; font-family: arial, Helvetica, sans-serif; font-size: 12px;
                font-weight: 500; color: #FFFFFF;" align="right">
                
            </th>
        </tr>
    </table>
    <script>
        (function(i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function() {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', 'https://www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-77279258-1', 'auto');
        ga('send', 'pageview');

    </script>
 </form>
</body>
</html>
