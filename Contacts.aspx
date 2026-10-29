<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contacts.aspx.cs" Inherits="Gallery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" lang="en-gb" class="no-js">
<head>
    <meta http-equiv="content-Type" content="text/html; charset=utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <title>:: TG-iPASS ::</title>
    <meta name="description" content="">
    <meta name="author" content="">


    <link src="css/style.css" rel="Stylesheet" type="text/css" />
    <link id="default-css" href="css/style.css" rel="stylesheet" type="text/css">
    <link id="shortcodes-css" href="css/shortcodes.css" rel="stylesheet" type="text/css">
    <link href="css/responsive.css" rel="stylesheet" type="text/css">
    <link rel='stylesheet' id='layerslider-css' href="css/layerslider.css" type='text/css'
        media='all' />
    <link href="css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link id="skin-css" href="skins/maroon/style.css" rel="stylesheet" media="all" />
    <link href='http://fonts.googleapis.com/css?family=Merriweather:400,900italic,900,700italic,700,400italic,300italic,300'
        rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Domine:400,700' rel='stylesheet'
        type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Noto+Serif:400,700,400italic,700italic'
        rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800'
        rel='stylesheet' type='text/css'>
    <script src="js/modernizr-2.6.2.min.js"></script>

    <script>
        function UserDeleteConfirmation() {
            return confirm("This is external link. Are you sure you want to continue?");
        }
    </script>
    <style>
                                                                    :lang(te) {
    font-size: 100%;  /* Adjust as needed */
   
                        #main-menu ul.menu  li a {
    padding: 9px 5px 10px;
    font-size: 15px;
}
}
        .tdStyle
        {
            padding-left: 2px;
            padding: 5px; /* text-align: left; */
            font-size: 14px;
            font-weight: normal;
            border: 1px solid #D2D2D2;
        }
        .addrss
        {
            font-weight: 600;
            line-height: 1.8;
            padding-left: 50px;
        }
    </style>
    <style type="text/css">
        #canvasMap
        {
            height: 100%;
            margin: 0px;
            padding: 0px;
            border: 1px solid #D2D2D2;
        }
                       
    </style>
   
</head>
<body>
    <div class="wrapper">
        <div class="inner-wrapper">
            <header>
                <div class="top-bar">
                    <div class="container">
                        <span id="clock" style="font-size: 12px;"></span>

                        <div class="dt-sc-contact-number">
                            <ul class="dt-sc-social-icons">
                                <li><span class="fa fa-phone"></span>Call us:     040-23441636</li>
                                <li><a href="https://www.facebook.com/profile.php?id=100011131938859" target="_blank" title="Facebook"><span class="fa fa-facebook"></span></a></li>
                                <li><a href="#" title="Google Plus"><span class="fa fa-google-plus"></span></a></li>
                                <li><a href="#" title="Youtube"><span class="fa fa-youtube"></span></a></li>
                                <li><div class="translate d-flex mt-1 rounded"><div id="google_translate_element"></div></div></li>
                            </ul>

                        </div>
                    </div>
                </div>

                <div class="container" >
                    <div class="logo">
                        <a href="index.html">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/logo.jpg"></a>
                    </div>
                    <div class="top-head">
                        <div class="top-img" style="display:none">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/Revanth Reddy CM.JPG" id="imgcm" runat="server">
                             
                            <h5 class="top-names">Sri. A.Revanth Reddy</h5>
                            <p class="top-names1">Hon'ble Chief Minister</p>
                        </div>
                        <div class="top-img mr0" style="display:none">
                            <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/Masterfiles/images/IT Minister.JPG" id="imgitm" runat="server" >
                           
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
                                <li ><a href="TSHome.aspx">Home</a></li>
                                <li ><a href="about.aspx">About Us</a></li>
                                <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">Services</a>
                                    <ul class="sub-menu">
                                       <li><a target="_blank" href="UI/TSiPASS/frmCFEcertificateProcess.aspx">TS-iPass Certificate Verification</a></li>
                                        <%--<li><a target="_blank" href="UI/TSiPASS/AddNewInspectionUser.aspx">Inspection</a></li>--%>
                                        <li><a target="_blank" href="IncentiveRegistrationViewDocsNew.aspx">Incentive</a></li>
                                        <li><a target="_blank" href="UI/TSIPASS/RawMatirialLink.aspx">Raw Material Allocation</a></li>
                                         <li><a target="_blank" href="UI/TSiPASS/GuestGrievance.aspx">Grievance/Feedback</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/IFCHomepage.aspx">Investor Facilitation Cell</a></li>
                                        <%--<li><a target="_blank" href="UI/TSiPASS/GuestInsturction.aspx">Bank Loan Application</a></li>--%>
                                        <li><a target="_blank" onclick="if ( ! UserDeleteConfirmation()) return false;" href="http://udyogaadhaar.gov.in/">Udyog Aadhaar</a></li>
                                        <li><a target="_blank" href="UI/TSiPASS/MisreportDashboard.aspx">Mis Reports</a></li>
                                    </ul>
                                </li>
                                <li><a href="links.aspx">Related Departments</a></li>
                                <li><a href="Information.aspx">Information Wizard</a></li>

                                <li><a href="Downloads.aspx">Repository of Regulations</a></li>
                                <li><a href="UseCommentsOnAmmendments.aspx">Business Regulations</a></li>
                                 <li class="menu-item-simple-parent menu-item-depth-0"><a href="#x">NSWS</a>
                                    <ul class="sub-menu">
                                        <li><a target="_blank" href="docs/NSWS_Note.pdf">About NSWS</a></li>
                                        <li><a target="_blank" href="docs/Approvals_Covered.pdf">Approvals List</a></li>
                                        <li><a target="_blank" href="https://www.nsws.gov.in/">Login</a></li>
                                    </ul>
                                </li>
                                <li class="current_page_item"><a href="Contacts.aspx">Contact us</a></li>

                              
                                 <%-- <li><a href="#x">Related Departments</a></li>
                                <li><a href="#x">Testimonials</a></li>
                                <li><a href="#x">Latest News</a></li>
                                <li><a href="#x">Contact Us</a></li>--%>

                               <li><a href="IpassLogin.aspx"><i class="fa fa-lock"></i>Login</a></li>
                                <%--<li><a href="UI/TSiPASS/AddnewuserRegistration.aspx"><i class="fa fa-pencil"></i>Register</a></li>--%>
                            </ul>
                        </nav>
                    </div>
                </div>
                <div class="clearfix"></div>
            </header>
            <div id="main">
                <div class="breadcrumb-section">
                    <div class="container">
                        <h1>
                            Contact Us
                        </h1>
                        <div class="breadcrumb">
                            <span>You are here </span><a href="TSHome.aspx">Home </a><span class="current">Contact
                                Us </span>
                        </div>
                    </div>
                </div>
                <div class="container">
                    <div style="width: 90%; padding-left: 10px;" class="banner" align="center">
                        <div>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table2">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table2">
                                            <tr style="height: 50px; font-family: oxygen,sans-serif;">
                                                <td colspan="2" class="formheader" align="center">
                                                    <span style="font-size: 16pt; color: black; font-weight: bold"><strong>Commissioner
                                                        of Industries</strong> </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="tdStyle addrss" style="color: black;" width="40%">
                                                    <br />
                                                    <br />
                                                    Commissioner of Industries,<br />
                                                    Chirag Ali Lane, Abids,<br />
                                                    Hyderabad - 500 001<br />
                                                    <font color="Blue">Phone : 91-040-23441666<br />
                                                        Fax : 91-040-23441611<br />
                                                        Help Line : 040-23441666<br />
                                                        Email: ipass.telangana@gmail.com<br />
                                                        Email: coi.inds@telangana.gov.in<br />
                                                        Website: <a style="color: Blue" target="_blank" href="http://www.industries.telangana.gov.in/">
                                                            www.industries.telangana.gov.in</a></font>
                                                    <br />
                                                    <br />
                                                    <br />
                                                </td>
                                                <td style="width: 60%; padding: 15px; margin: auto;">
                                                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1903.698851427584!2d78.47390027493215!3d17.39269159447075!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bcb9762aa1776d1%3A0x6e9a38aa3f2258a3!2sCommissioner+of+Industries!5e0!3m2!1sen!2sin!4v1458362339583"
                                                        width="100%" height="300" frameborder="0" style="border: 1" allowfullscreen>
                                                    </iframe>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table2">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table2">
                                            <tr style="height: 50px; font-family: oxygen,sans-serif;">
                                                <td colspan="2" class="formheader" align="center">
                                                    <span style="font-size: 16pt; color: black; font-weight: bold"><strong>Nodal Officer
                                                        Details</strong> </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="tdStyle addrss" style="color: black;" width="40%">
                                                    <br />
                                                    <br />
                                                    <%--K. Chandra Sekhar Babu B.E--%>
                                                    <br />
                                                    Deputy Director of Industries,
                                                    <br />
                                                    Commissioner of Industries,<br />
                                                    Chirag Ali Lane, Abids,<br />
                                                    Hyderabad - 500 001<br />
                                                    <font color="Blue">Phone : 91-040-23441636<br />
                                                        <%-- Cell : 91-9908077333<br />--%>
                                                        Email: asstdir.sw.inds@telangana.gov.in<br />
                                                        Email: kcsbabu@gmail.com<br />
                                                    </font>
                                                    <br />
                                                    <br />
                                                    <br />
                                                </td>
                                                <td style="width: 60%; padding: 15px; margin: auto;">
                                                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d1903.698851427584!2d78.47390027493215!3d17.39269159447075!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bcb9762aa1776d1%3A0x6e9a38aa3f2258a3!2sCommissioner+of+Industries!5e0!3m2!1sen!2sin!4v1458362339583"
                                                        width="100%" height="300" frameborder="0" style="border: 1" allowfullscreen>
                                                    </iframe>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table2">
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table2">
                                            <tr>
                                                <td colspan="2" class="formheader" align="center">
                                                    <span style="font-size: 16pt; color: black; font-weight: bold"><strong>Industry Chasing
                                                        Cell</strong> </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="tdStyle addrss" style="color: black;" width="40%">
                                                    <br />
                                                    <br />
                                                    Industries Chasing Cell,<br />
                                                    5th Floor, C Block,<br />
                                                    Telangana Secretariat,<br />
                                                    Hyderabad 500022.<br />
                                                    <font color="Blue">Phone : 91-040-23450928<br />
                                                        Email: chasingcell_cmo@telangana.gov.in<br />
                                                    </font>
                                                    <br />
                                                    <br />
                                                </td>
                                                <td style="width: 60%; padding: 15px; margin: auto;">
                                                    <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d15228.514718474602!2d78.47148502117923!3d17.40561120428509!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x6f38da66f08b798d!2sTelangana+Secretariat!5e0!3m2!1sen!2sin!4v1474535890093"
                                                        width="100%" height="300" frameborder="0" style="border: 1" allowfullscreen>
                                                    </iframe>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div>
                            <div class="container">
                                <div class="row">
                                    <section id="primary1" class="page-with-sidebar with-right-sidebar" style="width: 1140px">
                            <h1><b><a href="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/docs/Officers for Grievance.pdf" target="_blank">Sectoral Nodal Officers</a>   </b></h1>
                                </section>
                                </div>
                                <div class="row">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="dt-sc-hr-invisible">
                    </div>
                </div>
            </div>
            <%--<footer>
                <div class="copyright">
                    <div class="container">
                        <div class="col-1 white">
                            <script type="text/javascript">                                document.write("&copy; " + new Date().getFullYear() + ". Copyright " + new Date().getFullYear() + " Government of Telangana. all rights reserved by Industries Chasing Cell..");</script>
                        </div>
                        <div class="col-1 white">
                            <a href="Contacts.aspx" title="Contact Us" target="_blank">Contact Us</a> |
                            <a href="UI/TSIPASS/TermsConditions.aspx" title="Terms of Use" target="_blank">Terms of Use</a> |
                            <a href="UI/TSIPASS/Privacypolicy.aspx" title="Privacy Policy" target="_blank">Privacy</a>  |
                             <a href="UI/TSIPASS/IpassSitemap.aspx" title="Privacy Policy" target="_blank">Site Map</a>
                        </div>
                        <div class="col-2 white">
                             <span style="font-weight: bold"><asp:Label ID="lbllastupdat" runat="server" Text=""></asp:Label></span>
                            
                        </div>
                    </div>
                </div>
            </footer>--%>
                        <footer>
                <div class="copyright">
                    <div class="container">
                        
                        <div class="col-1 white">
                            <a href="Contacts.aspx" title="Contact Us" target="_blank">Contact Us</a> |
                            <a href="UI/TSIPASS/TermsConditions.aspx" title="Terms of Use" target="_blank">Terms of Use</a> |
                            <a href="UI/TSIPASS/Privacypolicy.aspx" title="Privacy Policy" target="_blank">Privacy</a> |
                             <a href="UI/TSIPASS/IpassSitemap.aspx" title="Privacy Policy" target="_blank">Site Map</a> |
                           <%-- <div id="count">View Counts: 0</div>--%>
                             <%--<div id="count" runat="server" clientidmode="Static"></div>--%>
                           <asp:Label ID="lblClickCount" runat="server" Text="Chatbot View Count:"></asp:Label>
                        </div>
                        <div class="col-2 white">
                             <span style="font-weight: bold"><asp:Label ID="lbllastupdat" runat="server" Text=""></asp:Label></span>
                            <%--Designed By <a href="http://www.bitranet.com/" title="Website Designed by BitraNet Pvt. Ltd.," target="_blank">BitraNet</a>--%>
                        </div>
                    </div>
                </div>
            </footer>
            <footer style="background: linear-gradient(45deg, #021331, #044a8c);border: none !important;">
    <div class="copyright">
        <div class="container">
            <div class="col-1 white" style="width: 60% !important;margin-top: 2px;">
                <script type="text/javascript">  document.write("&copy; " + new Date().getFullYear() + ". Copyright " + new Date().getFullYear() + " Government of Telangana. all rights reserved by Industries Chasing Cell..");</script>
            </div>
            
            <div class="col-2 white" style="width: 40% !important;">
                 <span style="font-weight: 500;">Design and Developed by : <img src="viewpdf.aspx?filepathnew=D:/TS-iPASSFinal/images/cmslogo.png" alt="CMS logo" style="width: 16%;margin-top: -5px;"/></span>
                <%--Designed By <a href="http://www.bitranet.com/" title="Website Designed by BitraNet Pvt. Ltd.," target="_blank">BitraNet</a>--%>
            </div>
        </div>
    </div>
</footer>
        </div>
    </div>
    <a href="#" title="Go to Top" class="back-to-top"><span class="fa fa-angle-up"></span>
    </a>
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
                
     
    <script type="text/javascript">        var lsjQuery = jQuery;</script>
    <script type="text/javascript">        lsjQuery(document).ready(function () { if (typeof lsjQuery.fn.layerSlider == "undefined") { lsShowNotice('layerslider_2', 'jquery'); } else { lsjQuery("#layerslider_2").layerSlider({ responsiveUnder: 1240, layersContainer: 1170, skinsPath: 'js/layerslider/skins/' }) } }); </script>
<script type="text/javascript" src="//translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
</body>
</html>
