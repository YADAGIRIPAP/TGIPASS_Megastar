<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApplicationStatusForDepts.aspx.cs" Inherits="ApplicationStatusForDepts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta http-equiv="content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>:: TS-iPASS ::</title>
    <meta name="description" content="">
    <meta name="author" content="">
    <link id="default-css" href="css/style.css" rel="stylesheet" type="text/css">
    <link id="shortcodes-css" href="css/shortcodes.css" rel="stylesheet" type="text/css">
    <link href="css/responsive.css" rel="stylesheet" type="text/css">
    <link rel='stylesheet' id='layerslider-css' href="css/layerslider.css" type='text/css' media='all' />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link id="skin-css" href="skins/maroon/style.css" rel="stylesheet" media="all" />

    <link href='http://fonts.googleapis.com/css?family=Merriweather:400,900italic,900,700italic,700,400italic,300italic,300' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Domine:400,700' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Noto+Serif:400,700,400italic,700italic' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>

    <script src="js/modernizr-2.6.2.min.js"></script>

</head>
<body>
    <form id="Form1" runat="server">
        <div class="wrapper">
            <div class="inner-wrapper">
                <header>
                    <div class="top-bar">
                        <div class="container">
                            <span id="clock" style="font-size: 12px;"></span>

                            <div class="dt-sc-contact-number">
                                <ul class="dt-sc-social-icons">
                                    <li><span class="fa fa-phone"></span>Call us: 040-23441636</li>
                                    <li><a href="https://www.facebook.com/profile.php?id=100011131938859" target="_blank" title="Facebook"><span class="fa fa-facebook"></span></a></li>
                                    <li><a href="#" title="Google Plus"><span class="fa fa-google-plus"></span></a></li>
                                    <li><a href="#" title="Youtube"><span class="fa fa-youtube"></span></a></li>
                                </ul>

                            </div>
                        </div>
                    </div>

                    <div class="container">
                        <div class="logo">
                            <a href="index.html">
                                <img src="images/logo.jpg"></a>
                        </div>
                        <div class="top-head">
                            <div class="top-img">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/Revanth Reddy CM.JPG" id="imgcm" runat="server">

                                <h5 class="top-names">Sri. A.Revanth Reddy</h5>
                                <p class="top-names1">Hon'ble Chief Minister</p>
                            </div>
                            <div class="top-img mr0">
                                <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/IT Minister.JPG" id="imgitm" runat="server">

                                <h5 class="top-names">Sri. D.Sridhar Babu</h5>
                                <p class="top-names1">Hon'ble Minister for Industries</p>
                            </div>
                        </div>
                    </div>

                    <div id="menu-container">
                        <div class="container">
                            <nav id="main-menu">
                                <div class="dt-menu-toggle" id="dt-menu-toggle">Menu<span class="dt-menu-toggle-icon"></span></div>
                                <ul id="menu-main-menu" class="menu">
                                    <li><a href="TSHome.aspx">Home</a></li>
                                    <li><a href="about.aspx">About Us</a></li>
                                    <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">Services</a>
                                        <ul class="sub-menu">
                                            <li><a target="_blank" href="UI/TSiPASS/frmCFEcertificateProcess.aspx">TS-iPass Verification</a></li>
                                            <%--<li><a target="_blank" href="UI/TSiPASS/AddNewInspectionUser.aspx">Inspection</a></li>--%>
                                            <li><a target="_blank" href="IncentiveRegistrationViewDocs.aspx">Incentive Check</a></li>
                                            <li><a target="_blank" href="IpassLogin.aspx">Raw Material Allocation</a></li>
                                            <li><a target="_blank" href="UI/TSiPASS/GuestGrievance.aspx">Grievance Registration</a></li>
                                            <li><a target="_blank" href="UI/TSiPASS/GuestInsturction.aspx">Bank Loan Application</a></li>
                                            <li><a target="_blank" href="http://udyogaadhaar.gov.in/">Udyog Aadhaar</a></li>
                                        </ul>
                                    </li>
                                    <li><a href="links.aspx">Related Departments</a></li>
                                    <li><a href="Information.aspx">Information</a></li>

                                    <li class="current_page_item"><a href="Downloads.aspx">Act & Rules</a></li>
                                    <li><a href="UseCommentsOnAmmendments.aspx">Business Regulations</a></li>
                                    <li><a href="Contacts.aspx">Contact us</a></li>
                                    <%-- <li><a href="#x">Related Departments</a></li>
                                <li><a href="#x">Testimonials</a></li>
                                <li><a href="#x">Latest News</a></li>
                                <li><a href="#x">Contact Us</a></li>--%>

                                    <li><a href="IpassLogin.aspx"><i class="fa fa-lock"></i>Login</a></li>
                                    <li><a href="UI/TSiPASS/AddnewuserRegistration.aspx"><i class="fa fa-pencil"></i>Register</a></li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </header>

                <div id="main">
                    <div class="breadcrumb-section">
                        <div class="container">
                            <h1>Application Status</h1>
                            <div class="breadcrumb">
                                <a href="TSHome.aspx">Home </a>
                                <span class="current">Land Bank</span>
                            </div>
                        </div>
                    </div>


                    <div class="container">
                        <section id="primary" class="type2">
                            <aside class="widget widget_categories">
                               <%-- <h3 class="widgettitle"><span class="fa fa-download"></span>Downloads</h3>--%>
                                <ul class="dt-sc-fancy-list caret">
                                    <li style="font-size:13pt; color:black;"><a href="docs/TS-iPASS.pdf" target="_blank">Labour Department</a></li>
                                    <li style="font-size:13pt; color:black;"><a target="_blank" href="docs/TS-iPassupdated.pdf">Factory Department </a></li>
                                    <li style="font-size:13pt; color:black;"><a target="_blank" href="docs/How to apply for clearances under TS.pdf">Fire Department</a></li>
                                    <li style="font-size:13pt; color:black;"><a target="_blank" href="Checklist.aspx">SPDCL Department </a></li>
                                    <li style="font-size:13pt; color:black;"><a target="_blank" href="Checklist.aspx">NPDCL Department </a></li>
                                </ul>
                            </aside>
                        </section>

                        <div class="dt-sc-hr-invisible"></div>
                    </div>

                </div>

                <footer>
                    <div class="copyright">
                        <div class="container">
                            <div class="col-1 white">
                                <script type="text/javascript">document.write("&copy; " + new Date().getFullYear() + ". Copyright 2017 Government of Telangana. all rights reserved by Industries Chasing Cell..");</script>
                            </div>
                            <div class="col-2 white">
                                <%--  Designed By <a href="http://www.bitranet.com/" title="Website Designed by BitraNet Pvt. Ltd.," target="_blank">BitraNet</a>--%>
                            </div>
                        </div>
                    </div>
                </footer>
            </div>
        </div>
    </form>



    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/jquery-migrate.min.js"></script>
    <script type="text/javascript" src="js/jquery.validate.min.js"></script>
    <script type="text/javascript" src="js/jquery-easing-1.3.js"></script>
    <script type="text/javascript" src="js/jquery.sticky.js"></script>
    <script type="text/javascript" src="js/jquery.nicescroll.min.js"></script>
    <script type="text/javascript" src="js/jquery.smartresize.js"></script>
    <script type="text/javascript" src="js/shortcodes.js"></script>
    <script type="text/javascript" src="js/jquery.cookie.js"></script>
    <script type="text/javascript" src="js/custom.js"></script>
    <script type="text/javascript" src="js/date.js"></script>
    <script type="text/javascript" src="js/jquery-transit-modified.js"></script>
    <script type="text/javascript" src="js/layerslider.kreaturamedia.jquery.js"></script>
    <script type='text/javascript' src="js/greensock.js"></script>
    <script type='text/javascript' src="js/layerslider.transitions.js"></script>

    <script type="text/javascript">var lsjQuery = jQuery;</script>
    <script type="text/javascript"> lsjQuery(document).ready(function () { if (typeof lsjQuery.fn.layerSlider == "undefined") { lsShowNotice('layerslider_2', 'jquery'); } else { lsjQuery("#layerslider_2").layerSlider({ responsiveUnder: 1240, layersContainer: 1170, skinsPath: 'js/layerslider/skins/' }) } }); </script>

    <script src="UI/TSIPASS/assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="UI/TSIPASS/assets/js/bootstrap.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="UI/TSIPASS/assets/js/jquery.metisMenu.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="UI/TSIPASS/assets/js/custom.js"></script>

    <link href="UI/TSIPASS/assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="UI/TSIPASS/assets/css/font-awesome.css" rel="stylesheet" />
    <!--CUSTOM BASIC STYLES-->
    <link href="UI/TSIPASS/assets/css/basic.css" rel="stylesheet" />
    <!--CUSTOM MAIN STYLES-->
    <link href="UI/TSIPASS/assets/css/custom.css" rel="stylesheet" />

    <!-- GOOGLE FONTS-->
    <a href="#" title="Go to Top" class="back-to-top"><span class="fa fa-angle-up"></span></a>
</body>
</html>
