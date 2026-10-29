<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IpassLogin.aspx.cs" Inherits="IpassLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>TS-iPASS</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" type="text/css" href="css/stylelogin.css">
    <link rel="stylesheet" type="text/css" href="css/owl.carousel.css">
    <link rel="stylesheet" type="text/css" href="css/owl.theme.css">
    <link rel="stylesheet" type="text/css" href="css/owl.transitions.css">
    <link rel="stylesheet" type="text/css" href="css/fontello.css">
    <link href='https://fonts.googleapis.com/css?family=Montserrat:400,700' rel='stylesheet'
        type='text/css'>
    <link href='https://fonts.googleapis.com/css?family=Roboto:400,400italic,500,500italic,700,700italic,300italic,300'
        rel='stylesheet' type='text/css'>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">
    <style>
        .find-section {
            top: 10%;
        }

        #slider .item img {
            height: 590px;
        }
    </style>
     <script src="js/MD5.js"></script>
<script>
    function validateUser() {
        var pass;
        passObj = document.getElementById('txtpsw');
        HdnSessionsec = document.getElementById('HdnSession');
        var x = (Math.random() * 2018);
        HdnSessionsec.value = x;
        pass = MD5(passObj.value.trim().toLowerCase() + HdnSessionsec.value);
        passObj.value = pass;

        return true;

    }
</script>
</head>
<body>
     <script type="text/javascript">
         window.onload = function checkSessionInJS() {
             var sessionCount = '<%= Session["uid"] %>';;
             if (sessionCount == "") {
                 //alert('sowjanya');
                 localStorage.setItem("forceLogout", Date.now());
             }
             else {
                 var loggedUser = localStorage.getItem("loggedUser");
                 if (loggedUser) {
                     //alert("User found in localStorage: " + loggedUser);
                     localStorage.setItem("forceLogout", Date.now());

                 }

             }
         };
     </script>
    <div class="slider-bg">
        <div id="slider" class="owl-carousel owl-theme slider">
            <%-- <div class="item slider-shade" >
                <img src="images/slider-1.jpg" class="img-responsive">
            </div>
            <div class="item slider-shade" >
                <img src="images/slider-2.jpg" class="img-responsive">
            </div>--%>
        </div>
        <div class="find-section">
            <div class="container">
                <div class="row">
                    <div class="col-md-offset-3 col-md-6 finder-block">
                        <div class="finder-form-transparent">
                            <div class="well-box">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/logo.jpg" class="img-responsive">
                                <hr>
                                <form runat="server">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <div>
                                        <table style="width: 100%">
                                            <tr>
                                                <td align="center" colspan="8" style="padding: 5px; margin: 5px">
                                                    <div id="success" runat="server" visible="false" class="alert alert-success">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Success!</strong><asp:Label ID="lblmsg" runat="server"></asp:Label>
                                                    </div>
                                                    <div id="Failure" runat="server" visible="false" class="alert alert-danger">
                                                        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Warning!</strong>
                                                        <asp:Label ID="lblmsg0" runat="server"></asp:Label>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtuname" runat="server" placeholder="User name" class="form-control input-md"
                                            required=""></asp:TextBox>
                                    </div>
                                    <br>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtpsw" TextMode="Password" runat="server" placeholder="Password"
                                            class="form-control input-md" required=""></asp:TextBox>
                                         <asp:HiddenField ID="HdnSession" runat="server" />
                                    </div>
                                    <br>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtCaptcha" class="form-control input-md" autocomplete="off" placeholder="Enter Code"
                                            TabIndex="1" runat="server" Width="200px"></asp:TextBox>
                                    </div>
                                    <div class="form-group" style="position: relative; left: 223px; top: -49px;">
                                        <asp:UpdatePanel ID="UP1" runat="server">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td style="padding: 5px; margin: 5px">
                                                            <asp:Image ID="imgCaptcha" runat="server" />
                                                        </td>
                                                        <td style="width: 5px"></td>
                                                        <td style="padding: 5px; margin: 5px" valign="middle">
                                                            <asp:ImageButton ID="btnRefresh" ImageUrl="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/refresh.png" Height="30px" Width="30px"
                                                                runat="server" AlternateText="Refresh" OnClick="btnRefresh_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="lnkbtnLogin" TabIndex="3" title="Login" class="btn btn-primary btn-lg"
                                            runat="server" Text="Login" OnClick="lnkbtnLogin_Click" OnClientClick="validateUser();"  />
                                    </div>
                                    <br>
                                    <a href="forgotpwd.aspx">Forgot your password?</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a
                                        href="TSHome.aspx"><img height="40px" width="40px" src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/Homeimage.png" />
                                        <%--</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="UI/TSiPASS/AddnewuserRegistration.aspx">New
                                    User Registration</a>--%>
                                    </a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="Note_TsIPass.aspx">New
                                    User Registration</a>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="tiny-footer">
        <div class="container">
            <div class="row" style="display: none">
                <div class="col-1 white">
                    <script type="text/javascript">                        document.write("&copy; " + new Date().getFullYear() + ". Copyright " + new Date().getFullYear() + " Government of Telangana. all rights reserved by Industries Chasing Cell..");</script>
                </div>
                <div class="col-1 white">
                    <a href="Contacts.aspx" title="Contact Us" target="_blank" style="color: white">Contact
                        Us</a> | <a href="UI/TSIPASS/TermsConditions.aspx" title="Terms of Use" target="_blank"
                            style="color: white">Terms of Use</a> | <a href="UI/TSIPASS/Privacypolicy.aspx" title="Privacy Policy"
                                target="_blank" style="color: white">Privacy</a>
                </div>
                <div class="col-2 white">
                    <span style="font-weight: bold">
                        <asp:Label ID="lbllastupdat" runat="server" Text=""></asp:Label></span>
                    <%--Designed By <a href="http://www.bitranet.com/" title="Website Designed by BitraNet Pvt. Ltd.," target="_blank">BitraNet</a>--%>
                </div>
            </div>
        </div>
    </div>
    </div>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.flexnav.js" type="text/javascript"></script>
    <script src="js/navigation.js"></script>
    <script src="js/owl.carousel.min.js"></script>
    <script type="text/javascript" src="js/slider.js"></script>
    <script type="text/javascript">
        $(window).scroll(function () {
            if ($(".header-v2").offset().top > 50) {
                $(".navbar-fixed-top").addClass("top-nav-collapse");
            } else {
                $(".navbar-fixed-top").removeClass("top-nav-collapse");
            }
        });
    </script>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            const textboxes = document.querySelectorAll('input[type="text"]');

            textboxes.forEach(function (textBox) {
                textBox.addEventListener('input', function (event) {
                    const inputValue = event.target.value;

                    // Block the entry of '<' and '>' characters
                    if (inputValue.includes('<') || inputValue.includes('>')) {
                        event.target.value = inputValue.replace(/[<>]/g, '');
                    }
                });

                // Prevent paste action for the textbox
                //textBox.addEventListener('paste', function (event) {
                //    event.preventDefault();
                //});
            });
        });
    </script>
</body>
</html>
